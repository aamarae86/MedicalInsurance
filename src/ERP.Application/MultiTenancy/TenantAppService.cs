using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using Abp.MultiTenancy;
using Abp.Runtime.Security;
using Abp.Runtime.Session;
using Abp.UI;
using ERP._System;
using ERP._System.__PmPropertiesModule._PmContract.BackGroundWorkers;
using ERP._System._TenantFreeModules;
using ERP.Authorization;
using ERP.Authorization.Roles;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Extensions;
using ERP.Editions;
using ERP.Helpers.Core;
using ERP.MultiTenancy.Dto;
using ERP.MultiTenancy.Input;
using ERP.MultiTenancy.Proc;
using ERP.StripeIntegration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace ERP.MultiTenancy
{
    [AbpAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantAppService : AttachBaseAsyncCrudAppService<Tenant, TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto, AttachAuditedEntity>, ITenantAppService
    {

        private readonly IRepository<TenantRenewalHistory, long> _renewalHistoryRepository;
        private readonly IRepository<User, long> _usersRepository;
        private readonly TenantManager _tenantManager;
        private readonly EditionManager _editionManager;
        private readonly IUnitOfWorkManager _uow;
        private readonly IStripeService _stripeService;
        private readonly UserManager _userManager;
        private readonly IPrincipalAccessor _principalAccessor;
        private readonly RoleManager _roleManager;
        private readonly IAbpZeroDbMigrator _abpZeroDbMigrator;
        private readonly IPrepareTenantDataRepository _prepareTenantDataRepository;
        private readonly IPortalUserManager _portalUserManager;
        private readonly IConfiguration _config;
        private readonly ICheckDublicatedEmailAbpUserRepository _checkDublicatedEmailAbpUserRepository;
        private readonly ITenantStore _tenantStore;

        public TenantAppService(
            IRepository<Tenant, int> repository,
            IRepository<TenantRenewalHistory, long> renewalHistoryRepository,
            IRepository<User, long> usersRepository,
            TenantManager tenantManager,
            EditionManager editionManager,
            IUnitOfWorkManager uow,
            IStripeService stripeService,
            UserManager userManager,
             IPrincipalAccessor principalAccessor,
            RoleManager roleManager, ICheckDublicatedEmailAbpUserRepository checkDublicatedEmailAbpUserRepository,
            IAbpZeroDbMigrator abpZeroDbMigrator,
            IPortalUserManager portalUserManager, IConfiguration config,
            ITenantStore tenantStore,
            IPrepareTenantDataRepository prepareTenantDataRepository)
            : base(repository,config)
        {
            _renewalHistoryRepository = renewalHistoryRepository;
            _usersRepository = usersRepository;
            _tenantManager = tenantManager;
            _editionManager = editionManager;
            _uow = uow;
            _stripeService = stripeService;
            _userManager = userManager;
            _principalAccessor = principalAccessor;
            _roleManager = roleManager;
            _abpZeroDbMigrator = abpZeroDbMigrator;
            _prepareTenantDataRepository = prepareTenantDataRepository;
            _checkDublicatedEmailAbpUserRepository = checkDublicatedEmailAbpUserRepository;
            _portalUserManager = portalUserManager;
            _config = config;
            _tenantStore = tenantStore;

            PreFileName = "Tenant_";
            ServiceFolder = "Tenants";
        }
 
        [AbpAllowAnonymous]
        public override async Task<TenantDto> Create(CreateTenantDto input)
        {
            var checkDublicatedEmailAbpUser = await _checkDublicatedEmailAbpUserRepository
                .Execute(new CheckDublicatedEmailAbpUserInput { Email = input.AdminEmailAddress }, "CheckDublicatedEmailAbpUser");

            if (checkDublicatedEmailAbpUser.FirstOrDefault().Dublicated)
                throw new UserFriendlyException("البريد الاليكتروني موجود من قبل");

            //CheckCreatePermission();
            input.IsActive = true;
            // Create tenant
            var tenant = ObjectMapper.Map<Tenant>(input);

            #region DefaultPaymentConditions
            var UserValue = _config.GetValue<decimal>("UserValue");
            var AdminValue = _config.GetValue<decimal>("AdminValue");
            var FreeTrialDaysForNewTenant = _config.GetValue<int>("FreeTrialDaysForNewTenant");

            tenant.SetTenancyName(input.TenancyName);
            tenant.SetPaymentValues(AdminValue, UserValue);
           
            #endregion



            tenant.ConnectionString = input.ConnectionString.IsNullOrEmpty()
                ? null
                : SimpleStringCipher.Instance.Encrypt(input.ConnectionString);

            var defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);
            if (defaultEdition != null)
            {
                tenant.EditionId = defaultEdition.Id;
            }

            await _tenantManager.CreateAsync(tenant);
            await CurrentUnitOfWork.SaveChangesAsync(); // To get new tenant's id.

            // Create tenant database
            _abpZeroDbMigrator.CreateOrMigrateForTenant(tenant);
 
            // We are working entities of new tenant, so changing tenant filter
            using (CurrentUnitOfWork.SetTenantId(tenant.Id))
            {
                // Create static roles for new tenant
                CheckErrors(await _roleManager.CreateStaticRoles(tenant.Id));

                await CurrentUnitOfWork.SaveChangesAsync(); // To get static role ids

                // Grant all permissions to admin role
                var adminRole = _roleManager.Roles.Single(r => r.Name == StaticRoleNames.Tenants.Admin);
                await _roleManager.GrantAllPermissionsAsync(adminRole);

                // Create admin user for the tenant
                var adminUser = User.CreateTenantAdminUser(tenant.Id, input.AdminEmailAddress);

                if (FreeTrialDaysForNewTenant > 0)
                {
                    DateTime expiryDate = DateTime.Now.AddDays(FreeTrialDaysForNewTenant);                    
                    adminUser.SetSubEndDateValue(expiryDate);
                }
                
                await _userManager.InitializeOptionsAsync(tenant.Id);
                CheckErrors(await _userManager.CreateAsync(adminUser, /*input.AdminPassword ??*/ User.DefaultPassword));
                await CurrentUnitOfWork.SaveChangesAsync(); // To get admin user's id

                // Assign admin user to role!
                CheckErrors(await _userManager.AddToRoleAsync(adminUser, adminRole.Name));

                // prepare tenant from template data
                await PrepareTenantDataFromTemplateId(tenant.Id, input.IndustryLkpId, adminUser.Id);
                await CurrentUnitOfWork.SaveChangesAsync();
                await GenerateResetLinkAndSendMail(adminUser, tenant.TenancyName,input.Baseurl);
            }      

            return MapToEntityDto(tenant);
        }

        public async Task<bool> GenerateResetLinkAndSendMail(User user, string subDomain, string hostUrl = null)
        {
            string tenantSubDomain = ResolveTenantName();


            //string ERP_URL = $"{NotifyFor30DaysRemainOnContractWorker.GetBaseURL(_config, null, subDomain)}/Login/ForgetPassword";
            //http://register.tenxerp.com/home/registration

            hostUrl = hostUrl.Replace("register", subDomain.ToLower());

            string ERP_URL = $"{hostUrl}/Login/ForgetPassword";

            string tenantQS = !user.TenantId.HasValue || user.TenantId.Value == 0 ? "" : $"TenantId={user.TenantId}&";
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            string link = $"{ERP_URL}?{tenantQS}Email=";
            resetToken = System.Web.HttpUtility.UrlEncode(resetToken);
            string linkInMail = $"{link}{user.EmailAddress}&ResetToken={resetToken}";

            return await _portalUserManager.TestSendMail(user.EmailAddress, linkInMail);
        }

        private string ResolveTenantName()
        {
            return AbpSession.TenantId.HasValue ?
                _tenantStore.Find(AbpSession.TenantId.Value).TenancyName :
                "Admin";
        }

        protected override IQueryable<Tenant> CreateFilteredQuery(PagedTenantResultRequestDto input)
        {
            return Repository.GetAllIncluding(t => t.FndCountryLkp, t => t.FndIndustryLkp, t => t.Currency)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.TenancyName.Contains(input.Keyword) || x.Name.Contains(input.Keyword))
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);
        }

        //protected override IQueryable<Tenant> CreateFilteredQuery(PagedTenantResultRequestDto input)
        //{
        //    var tenantList = Repository.GetAllIncluding(t => t.FndCountryLkp, t => t.FndIndustryLkp, t => t.Currency)
        //        .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.TenancyName.Contains(input.Keyword) || x.Name.Contains(input.Keyword))
        //        .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);
        //    foreach(var tenant in tenantList)
        //    {

        //    }
        //}
        protected override void MapToEntity(TenantDto updateInput, Tenant entity)
        {
            // Manually mapped since TenantDto contains non-editable properties too.
            entity.Name = updateInput.Name;
            entity.TenancyName = updateInput.TenancyName;
            entity.IsActive = updateInput.IsActive;
        }

        public override async Task Delete(EntityDto<int> input)
        {
            CheckDeletePermission();

            var tenant = await _tenantManager.GetByIdAsync(input.Id);
            await _tenantManager.DeleteAsync(tenant);
        }

        private void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        public async Task<string> PrepareTenantDataFromTemplateId(int tenantId, long IndustryId, long userId)
        {
            var prepareTenantDataInput = new PrepareTenantDataInput { TenantId = tenantId, IndustryLkpId = IndustryId, UserId = userId };

            var result = await _prepareTenantDataRepository.Execute(prepareTenantDataInput, "SpAdminPrepareTenant");

            return result?.FirstOrDefault()?.FinalStatues ?? string.Empty;
        }



        [AbpAuthorize(PermissionNames.Pages_TenantFreeModules)] //host
        public async Task<bool> ChaneTenantPaymentOptions(TenantPaymentOptionsDto input)
        {
            var tenant = await _tenantManager.GetByIdAsync(input.TenantId);
            tenant.SetPaymentValues(input.AdminValue, input.UserValue);
            //tenant.SetSubEndDateValue(DateTimeController.ConvertToDateTime(input.SubEndDate).Value);

            //if (input.AllowedDayes > 0)
            //{
            //    if (tenant.SubEndDate != null && tenant.SubEndDate.Value.ClculateRemainingDays() >= 0)
            //    {
            //        tenant.SetSubEndDateValue(tenant.SubEndDate.Value.AddDays(input.AllowedDayes.Value));
            //    }
            //    else if (tenant.SubEndDate == null || tenant.SubEndDate.Value.ClculateRemainingDays() <= 0)
            //    {
            //        tenant.SetSubEndDateValue(DateTime.Now.AddDays(input.AllowedDayes.Value));
            //    }
            //}

            //_renewalHistoryRepository

            await  ManageRenewalHistoryAsync(input);

            await _tenantManager.UpdateAsync(tenant);



            return true;
        }
 
        [AbpAllowAnonymous]
        public async Task<TenantCheckoutResponseDto> TenantCheckoutHold(TenantCheckoutDto input)
        {
            
            var IsTenentAdmin = _principalAccessor.Principal.Claims.FirstOrDefault(s => s.Type == "IsTenentAdmin").Value;
            if (IsTenentAdmin == "NO")
            {
                throw new UnauthorizedAccessException("Admin only can do this operation");
            }
            DateTime adminSubendDate = await GetAdminSubEndDate(input);

            var ReturnResult = new TenantCheckoutResponseDto();
            var TransactionNo = $"Trx_{new Random().Next(10, int.MaxValue)}_{DateTime.Now.Millisecond}";

            
            //  var SingleRow = input.FirstOrDefault();
            DateTime NewSubEndDate;
            foreach (var row in input.UsersModel)
            {
                    var user = await _usersRepository.FirstOrDefaultAsync(s => s.TenantId == input.TenentId && s.Id == row.UserId);
 
                    NewSubEndDate = user.SubEndDate.CalculateNewSubEndDate(row.NOfMonthes);

                    if(NewSubEndDate > adminSubendDate)
                    {
                        throw new UnauthorizedAccessException("You cannot renew users subscriptions for a period longer than the administrator subscription");
                    }
                    var TenantRenewalHistory = new TenantRenewalHistory();
                    TenantRenewalHistory.SetNewRenewall(input.TenentId, row.UserId, row.Price, NewSubEndDate, input.SessionId);
                    TenantRenewalHistory.SetTransactionNumber(TransactionNo);

                await _renewalHistoryRepository.InsertAsync(TenantRenewalHistory);
            }
            ReturnResult.TransactionNumber = TransactionNo;
            ReturnResult.TenentId = input.TenentId;
            ReturnResult.NOfMonthes = input.UsersModel.Select(s=>s.NOfMonthes).First();

            return ReturnResult;
        }
         
        [AbpAllowAnonymous]
        public async Task<bool> CompleteTenantCheckout(CompleteTenantCheckoutDto input)
        {
            var IsTenentAdmin = _principalAccessor.Principal.Claims.FirstOrDefault(s => s.Type == "IsTenentAdmin").Value;
            if (IsTenentAdmin == "NO")
            {
                throw new UnauthorizedAccessException("Admin only can do this operation");
            }
            var Trxdetails = await _renewalHistoryRepository
                .GetAllListAsync(s => (s.Confirmed != true && s.TransactionNumber == input.TransactionNumber && s.Tenant_ID == input.TenentId));

            if (!Trxdetails.Any())
                throw new Exception($"No Pending Transaction With Number {input.TransactionNumber}");

            if (await _stripeService.CheckIfPaymentSuccess(Trxdetails.FirstOrDefault().SessionId))
            {
               var _tenant = await _tenantManager.GetByIdAsync(input.TenentId);

                foreach (var trx in Trxdetails)
                {
                    var user = await _usersRepository.FirstOrDefaultAsync(s => s.TenantId == trx.Tenant_ID && s.Id == trx.RenewToUserId);
                
                    //if (user.UserName=="admin")
                    //{
                    //    _tenant.SetSubEndDateValue(trx.ExpiryDate);
                    //   await _tenantManager.UpdateAsync(_tenant);
                    //}
                    user.SetSubEndDateValue(trx.ExpiryDate);
                    trx.ChangeHistoryStatus(true);

                    var renewalHistory = _renewalHistoryRepository.UpdateAsync(trx);
                    var updateUsers = _usersRepository.UpdateAsync(user);
               
                    await Task.WhenAll(renewalHistory, updateUsers);
                    Console.WriteLine("Payment Task Completed");
                }
                return true;
            }
            else
            {
                return false;
            }
        }
         
        [AbpAllowAnonymous]
        public async Task<Select2PagedResult> GetTenantsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            return await _tenantManager.GetTenantsSelect2(searchTerm, pageSize, pageNumber, lang);
        }

        [AbpAuthorize(PermissionNames.Pages_TenantFreeModules)]
        private async Task<bool> ManageRenewalHistoryAsync(TenantPaymentOptionsDto input)
        {
            try
            {
                using (_uow.Current.DisableFilter(AbpDataFilters.MayHaveTenant,AbpDataFilters.MustHaveTenant ))
                {
                    var TenentUsers = await _usersRepository.GetAllListAsync(s=>s.TenantId==input.TenantId);
                    foreach (var user in TenentUsers)
                    {
                        var EndDate = DateTimeController.ConvertToDateTime(input.AdminSubEndDate).Value;

                        user.SetSubEndDateValue(EndDate);
                        var TenantRenewalHistory = new TenantRenewalHistory();
                        TenantRenewalHistory.SetNewRenewall(input.TenantId, user.Id, input.UserValue, EndDate,"HostSeassion");
                        await _usersRepository.UpdateAsync(user);
                        await _renewalHistoryRepository.InsertAsync(TenantRenewalHistory);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        public async Task<DateTime> GetAdminSubEndDate(TenantCheckoutDto input)
        {
            DateTime subEndDate;
            var tenentAdmin = await _userManager.FindByNameOrEmailAsync(input.TenentId, "admin");
            var NOfMonthes = input.UsersModel.Where(u => u.UserName == "admin").Select(x => x.NOfMonthes).FirstOrDefault();
            if (NOfMonthes!= 0)
            {
                subEndDate = tenentAdmin.SubEndDate.CalculateNewSubEndDate(NOfMonthes);
            }
            else
            {
                subEndDate = (DateTime)tenentAdmin.SubEndDate;
            }
            return subEndDate;        
        }

        }
}

