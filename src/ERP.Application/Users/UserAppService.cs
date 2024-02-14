using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using Abp.Localization;
using Abp.MultiTenancy;
using Abp.Notifications;
using Abp.Runtime.Session;
using Abp.UI;
using ERP._System.__AidModule._PortalUserUnified.Dto;
using ERP._System.__PmPropertiesModule._PmContract.BackGroundWorkers;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._modules;
using ERP._System._TenantFreeModules;
using ERP._System._TenantFreeModules.Dto;
using ERP.Authorization;
using ERP.Authorization.Accounts;
using ERP.Authorization.Roles;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using ERP.MultiTenancy;
using ERP.Roles.Dto;
using ERP.Users.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Users
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : AsyncCrudAppService<User, UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserEditDto>, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAbpSession _abpSession;
        private readonly LogInManager _logInManager;
        private readonly ICustomUserManager _customUserManager;
        private readonly IPortalUserManager _portalUserManager;
        private readonly IPermissionManager _permissionManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IUserNotificationManager _userNotificationManager;
        private readonly IConfiguration _config;
        private readonly ITenantFreeModulesAppService _tenantFreeModulesAppService;
        private readonly ITenantStore _tenantStore;
        private readonly IModuleManager _moduleManager;
        private readonly IPrincipalAccessor principalAccessor;

        public UserAppService(IRepository<User, long> repository,
            UserManager userManager, RoleManager roleManager,
            IRepository<Role> roleRepository,
            IRepository<Tenant> tenantRepository, 
            IPasswordHasher<User> passwordHasher,

           IModuleManager moduleManager,
           IPrincipalAccessor principalAccessor,
            IAbpSession abpSession, LogInManager logInManager,
            ICustomUserManager customUserManager, IPermissionManager permissionManager,
            IPortalUserManager portalUserManager, IGetCounterRepository getCounterRepository,
            IUserNotificationManager userNotificationManager, IConfiguration config,
            ITenantFreeModulesAppService tenantFreeModulesAppService,
            ITenantStore tenantStore
            ) : base(repository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _tenantRepository = tenantRepository;
            _passwordHasher = passwordHasher;
            _abpSession = abpSession;
            _logInManager = logInManager;
            _customUserManager = customUserManager;
            _portalUserManager = portalUserManager;
            _permissionManager = permissionManager;
            _repoProcCounter = getCounterRepository;
            _userNotificationManager = userNotificationManager;
            _config = config;
            _tenantFreeModulesAppService = tenantFreeModulesAppService;
            _tenantStore = tenantStore;
            _moduleManager = moduleManager;
            this.principalAccessor = principalAccessor;
        }

        private string ResolveTenantName()
        {
            return AbpSession.TenantId.HasValue ?
                _tenantStore.Find(AbpSession.TenantId.Value).TenancyName :
                "Admin";
        }

        [AbpAllowAnonymous]
        public async Task<bool> ForgetPassword(string Email, int TenantId = 0, bool IsPortal = true)
        {
            if (TenantId > 0)
                using (CurrentUnitOfWork.SetTenantId(TenantId))
                    return await ForgetPasswordCommon(Email, IsPortal, TenantId);
            return await ForgetPasswordCommon(Email, IsPortal);
        }

        private async Task<bool> ForgetPasswordCommon(string Email, bool IsPortal, int tenantId = 0)
        {
            var ResetUser = await _userManager.FindByEmailAsync(Email);

            Logger.Info($"Reset password: mail={Email}, user found ={ResetUser != null}");
            Logger.Debug($"Reset password: mail={Email}, user found ={ResetUser != null}");

            if (ResetUser != null)
            {

                Logger.Info($"Reset password: userId={ResetUser.Id}, mail={ResetUser.EmailAddress}");
                Logger.Debug($"Reset password: userId={ResetUser.Id}, mail={ResetUser.EmailAddress}");

                var x = await GenerateResetLinkAndSendMail(ResetUser);

                Logger.Debug($"Reset password: sendMail result={x}");
                Logger.Info($"Reset password: sendMail result={x}");

                return x;
            }
            Logger.Debug($"Reset password: sendMail result=false from the outside block");
            Logger.Info($"Reset password: sendMail result=false from the outside block");
            return false;
        }

        public async Task<bool> GenerateResetLinkAndSendMail(User user, string hostUrl = null)
        {
            string subDomain = ResolveTenantName();

            //hostUrl = hostUrl.Replace("register", subDomain.ToLower());

            string ERP_URL = $"{hostUrl}/Login/ForgetPassword";

            //string ERP_URL = $"{NotifyFor30DaysRemainOnContractWorker.GetBaseURL(_config,null,subDomain)}/Login/ForgetPassword";
            string tenantQS = !user.TenantId.HasValue || user.TenantId.Value == 0 ? "" : $"TenantId={user.TenantId}&";
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            string link = $"{ERP_URL}?{tenantQS}Email=";
            resetToken = System.Web.HttpUtility.UrlEncode(resetToken);
            string linkInMail = $"{link}{user.EmailAddress}&ResetToken={resetToken}";

            return await _portalUserManager.TestSendMail(user.EmailAddress, linkInMail);
        }
        
        [AbpAllowAnonymous]
        public async Task<bool> PostForgetPassword(ForgetPasswordDto ResetToken)
        {
            if (ResetToken.TenantId > 0)
                using (CurrentUnitOfWork.SetTenantId(ResetToken.TenantId))
                    return await PostForgetPasswordCommon(ResetToken);
            return await PostForgetPasswordCommon(ResetToken);
        }

        private async Task<bool> PostForgetPasswordCommon(ForgetPasswordDto ResetToken)
        {
            var ResetUser = await _userManager.FindByEmailAsync(ResetToken.Email);

            if (ResetUser != null)
            {
                CheckErrors(await _userManager.ResetPasswordAsync(ResetUser, ResetToken.ResetToken, ResetToken.NewPassword));
                return true;
            }
            return false;
        }

        public override async Task<UserDto> Create(CreateUserDto input)
        {
            CheckCreatePermission();

            var user = ObjectMapper.Map<User>(input);

            user.TenantId = AbpSession.TenantId;
            user.IsEmailConfirmed = true;

            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            try
            {
                var createuser = await _userManager.CreateAsync(user,"123qwe" /*input.Password*/);
            }
            catch (Exception ex) { 
                CheckErrors(await _userManager.CreateAsync(user, input.Password));
            
            }

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }

            //CurrentUnitOfWork.SaveChanges();
            var generate = await GenerateResetLinkAndSendMail(user, input.BaseUrl);
            //if (!generate)
            //    throw new Exception();

            return MapToEntityDto(user);
        }

        [AbpAllowAnonymous]
        public async Task<PortalUserUnifiedDto> SignUp(PortalUserUnifiedCreateDto input)
        {
            var user = ObjectMapper.Map<User>(input.User);

            user.TenantId = null;
            user.IsEmailConfirmed = true;
            user.IsPortalUser = true;

            await _userManager.InitializeOptionsAsync(tenantId: null);

            CheckErrors(await _userManager.CreateAsync(user, input.User.Password));

            CurrentUnitOfWork.SaveChanges();

            input.User = null;
            input.UserId = user.Id;
            input.CaseNumber = await GetPortalUserNumber();

            var portalUser = ObjectMapper.Map<PortalUser>(input);

            await _portalUserManager.CreateAsync(portalUser);

            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<PortalUserUnifiedDto>(portalUser);
        }

        public override async Task<UserDto> Update(UserEditDto input)
        {
            CheckUpdatePermission();

            var user = await _userManager.GetUserByIdAsync(input.Id);

            input.UserName = user.UserName;

            MapToEntity(input, user);

            CheckErrors(await _userManager.UpdateAsync(user));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }

            return await Get(input);
        }

        public override async Task Delete(EntityDto<long> input)
        {
            var user = await _userManager.GetUserByIdAsync(input.Id);
            await _userManager.DeleteAsync(user);
        }

        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleDto>(ObjectMapper.Map<List<RoleDto>>(roles));
        }

        public async Task ChangeLanguage(ChangeUserLanguageDto input)
        {
            await SettingManager.ChangeSettingForUserAsync(
                AbpSession.ToUserIdentifier(),
                LocalizationSettingNames.DefaultLanguage,
                input.LanguageName
            );
        }

        protected override User MapToEntity(CreateUserDto createInput)
        {
            var user = ObjectMapper.Map<User>(createInput);
            user.SetNormalizedNames();
            return user;
        }

        protected override void MapToEntity(UserEditDto input, User user)
        {
            ObjectMapper.Map(input, user);
            user.SetNormalizedNames();
        }

        protected override UserDto MapToEntityDto(User user)
        {
            var roles = _roleManager.Roles.Where(r => user.Roles.Any(ur => ur.RoleId == r.Id)).Select(r => r.NormalizedName);
            var userDto = base.MapToEntityDto(user);
            userDto.RoleNames = roles.ToArray();
            return userDto;
        }

        protected override IQueryable<User> CreateFilteredQuery(PagedUserResultRequestDto input)
        {
            if (input == null | input.Params == null)
                return Repository.GetAllIncluding(x => x.Roles);

            return Repository.GetAllIncluding(x => x.Roles)
                .WhereIf(!input.Params.UserName.IsNullOrWhiteSpace(), x => x.UserName.Contains(input.Params.UserName))
                .WhereIf(!input.Params.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Params.Name))
                .WhereIf(!input.Params.Surname.IsNullOrWhiteSpace(), x => x.Surname.Contains(input.Params.Surname))
                .WhereIf(!input.Params.FullName.IsNullOrWhiteSpace(), x => x.FullName.Contains(input.Params.FullName)/* || x.Name.Contains(input.Keyword) || x.EmailAddress.Contains(input.Keyword)*/)
                .WhereIf(!input.Params.EmailAddress.IsNullOrWhiteSpace(), x => x.EmailAddress.Contains(input.Params.EmailAddress))
                .WhereIf(input.Params.IsActive.HasValue, x => x.IsActive == input.Params.IsActive);
        }


        public async override Task<PagedResultDto<UserDto>> GetAll(PagedUserResultRequestDto input)
        {
              var returnedModel = new PagedResultDto<UserDto>();
              var Users=await base.GetAll(input);
              var tenent=await _tenantRepository.GetAsync(AbpSession.GetTenantId());
            if (Users != null && tenent!=null)
            {
                foreach (var user in Users.Items)
                {
                    if (user.UserName == "admin")
                    {
                        user.UserValue = tenent.AdminValue.ToString();
                    }
                    else
                    {
                        user.UserValue = tenent.UserValue.ToString()
                            ;
                    }
                }
            }
            returnedModel.TotalCount = Users.TotalCount;
            returnedModel.Items = Users.Items;

            return returnedModel;
        }

        protected override async Task<User> GetEntityByIdAsync(long id)
        {
            var user = await Repository.GetAllIncluding(x => x.Roles).FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new EntityNotFoundException(typeof(User), id);
            }

            return user;
        }

        protected override IQueryable<User> ApplySorting(IQueryable<User> query, PagedUserResultRequestDto input)
        {
            return query.OrderBy(r => r.UserName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        [AbpAllowAnonymous]
        public async Task<bool> ChangePassword(ChangePasswordDto input)
        {
            if (_abpSession.UserId == null)
            {
                throw new UserFriendlyException("Exception0");
                //throw new UserFriendlyException("Please log in before attemping to change password.");
            }
            long userId = _abpSession.UserId.Value;
            var user = await _userManager.GetUserByIdAsync(userId);

            var isCurrentPasswordValid = await _userManager.CheckPasswordAsync(user, input.CurrentPassword);
            if (!isCurrentPasswordValid)
            {
                throw new UserFriendlyException("Current password is incorrect.");
            }
            //var loginAsync = await _logInManager.LoginAsync(user.UserName, input.CurrentPassword, shouldLockout: false);
            //if (loginAsync.Result != AbpLoginResultType.Success)
            //{
                
            //    throw new UserFriendlyException("Exception1");
            //    //throw new UserFriendlyException("Your 'Existing Password' did not match the one on record.  Please try again or contact an administrator for assistance in resetting your password.");
            //}
            if (!new Regex(AccountAppService.PasswordRegex).IsMatch(input.NewPassword))
            {
                throw new UserFriendlyException("Exception2");
                //throw new UserFriendlyException("Passwords must be at least 8 characters, contain a lowercase, uppercase, and number.");
            }
            user.Password = _passwordHasher.HashPassword(user, input.NewPassword);
            CurrentUnitOfWork.SaveChanges();
            return true;
        }

        public async Task<bool> ResetPassword(ResetPasswordDto input)
        {
            if (_abpSession.UserId == null)
            {
                throw new UserFriendlyException("Please log in before attemping to reset password.");
            }
            long currentUserId = _abpSession.UserId.Value;
            var currentUser = await _userManager.GetUserByIdAsync(currentUserId);
            var loginAsync = await _logInManager.LoginAsync(currentUser.UserName, input.AdminPassword, shouldLockout: false);
            if (loginAsync.Result != AbpLoginResultType.Success)
            {
                throw new UserFriendlyException("Your 'Admin Password' did not match the one on record.  Please try again.");
            }
            if (currentUser.IsDeleted || !currentUser.IsActive)
            {
                return false;
            }
            var roles = await _userManager.GetRolesAsync(currentUser);
            if (!roles.Contains(StaticRoleNames.Tenants.Admin))
            {
                throw new UserFriendlyException("Only administrators may reset passwords.");
            }

            var user = await _userManager.GetUserByIdAsync(input.UserId);
            if (user != null)
            {
                user.Password = _passwordHasher.HashPassword(user, input.NewPassword);
                CurrentUnitOfWork.SaveChanges();
            }

            return true;
        }

        [AbpAllowAnonymous]
        public async Task<Select2PagedResult> GetUsersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            return await _customUserManager.GetUsersSelect2(searchTerm, pageSize, pageNumber, lang);
        }

        [AbpAllowAnonymous]
        //[AbpAuthorize]
        public async Task<bool> ResetUserPermissions()
        {
            var user = _abpSession.UserId != null ? _userManager.FindByIdAsync(_abpSession.UserId.ToString()).Result : null;
            await _userManager.ResetAllPermissionsAsync(user);
            return true;
        }

        [AbpAllowAnonymous]
        //[AbpAuthorize]
        public async Task<PermissionsResult> GetMenuPermissions()
        {
            PermissionsResult permissionsResult = null;

        
            var user = _abpSession.UserId != null ? _userManager.FindByIdAsync(_abpSession.UserId.ToString()).Result : null;
            if (user != null)
            {
                var userClaims = principalAccessor.Principal.Claims.ToList();
                var permissions = await _userManager.GetGrantedPermissionsAsync(user);

                permissionsResult = new PermissionsResult()
                {
                    Permissions = permissions?.Where(p => p.Name.Replace("Pages.", "").IndexOf('.') == -1 || p.Name.Replace("ActionPages.", "").IndexOf('.') == -1).Select(p => p.Name).ToList()
                };



                if (AbpSession.MultiTenancySide != MultiTenancySides.Host )
                {

                    var IsTenentSubscriptionValid = userClaims.FirstOrDefault(s => s.Type == "TenentSubscriptionValid").Value;
                    var IsUserSubscriptionValid = userClaims.FirstOrDefault(s => s.Type == "UserSubscriptionValid").Value;
                    var IsTenentAdmin = userClaims.FirstOrDefault(s => s.Type == "IsTenentAdmin").Value;

                    if (IsTenentSubscriptionValid == "NO" || IsUserSubscriptionValid == "NO")
                    {
                        var PermRes = await ManageModulePagesPermissionsAsync(user, permissions.ToList());
                        permissionsResult.Permissions = PermRes;
                    }

                    

                    if (IsTenentAdmin == "YES")
                    {
                        permissionsResult.Permissions.Add("TenentAdmin");
                    }

                    if (IsTenentSubscriptionValid == "YES")
                    {
                        permissionsResult.Permissions.Add("TenentSubscriptionValid");
                    }
                    else
                    {
                        permissionsResult.Permissions.Add("AdminSubInValid");
                    }

                    if (IsUserSubscriptionValid == "YES")
                    {
                        permissionsResult.Permissions.Add("UserSubscriptionValid");
                    }
                    else
                    {
                        permissionsResult.Permissions.Add("UserSubInValid");
                    }








                    //var res = await _tenantFreeModulesAppService.GetTenantAppModules(new EntityDto<long> { Id = (AbpSession.TenantId == null ? 0 : AbpSession.TenantId.Value) });
                    //foreach (var module in res.TenantModules)
                    //{
                    //    foreach (var perm in module.Pages)
                    //    {
                    //        var pagePermission = $"Pages.{perm.Selector}";
                    //        var pageInsertPermission = $"Pages.{perm.Selector}.Insert";
                    //        var pageUpdatePermission = $"Pages.{perm.Selector}.Update";
                    //        var pageDeletePermission = $"Pages.{perm.Selector}.Delete";
                    //        var pagePostPermission = $"Pages.{perm.Selector}.Post";
                    //        var pageUnPostPermission = $"Pages.{perm.Selector}.UnPost";

                    //        if (perm.Selector.Contains("crm"))
                    //        {

                    //        }

                    //        if (module.IsFree)
                    //        {
                    //            if (permissions1.Any(s => s.Name == pagePermission))
                    //            {
                    //                await GrantPermission(pagePermission, user);
                    //                permissionsResult.Permissions.Add(pagePermission);
                    //            }

                    //            if (permissions1.Any(s => s.Name == pageInsertPermission))
                    //            {
                    //                await GrantPermission(pageInsertPermission, user);
                    //                permissionsResult.Permissions.Add(pageInsertPermission);
                    //            }

                    //            if (permissions1.Any(s => s.Name == pageUpdatePermission))
                    //            {
                    //                await GrantPermission(pageUpdatePermission, user);
                    //                permissionsResult.Permissions.Add(pageUpdatePermission);
                    //            }

                    //            if (permissions1.Any(s => s.Name == pageDeletePermission))
                    //            {
                    //                await GrantPermission(pageDeletePermission, user);
                    //                permissionsResult.Permissions.Add(pageDeletePermission);
                    //            }

                    //            if (permissions1.Any(s => s.Name == pagePostPermission))
                    //            {
                    //                await GrantPermission(pagePostPermission, user);
                    //                permissionsResult.Permissions.Add(pagePostPermission);
                    //            }

                    //            if (permissions1.Any(s => s.Name == pageUnPostPermission))
                    //            {
                    //                await GrantPermission(pageUnPostPermission, user);
                    //                permissionsResult.Permissions.Add(pageUnPostPermission);
                    //            }


                    //        }
                    //        else
                    //        {
                    //            if (permissions1.Any(s => s.Name == pagePermission))
                    //            {
                    //                await RevokePermission(pagePermission, user);
                    //                permissionsResult.Permissions.Remove(pagePermission);
                    //            }

                    //            if (permissions1.Any(s => s.Name == pageInsertPermission))
                    //            {
                    //                await RevokePermission(pageInsertPermission, user);
                    //                permissionsResult.Permissions.Remove(pageInsertPermission);
                    //            }

                    //            if (permissions1.Any(s => s.Name == pageUpdatePermission))
                    //            {
                    //                await RevokePermission(pageUpdatePermission, user);
                    //                permissionsResult.Permissions.Remove(pageUpdatePermission);
                    //            }

                    //            if (permissions1.Any(s => s.Name == pageDeletePermission))
                    //            {
                    //                await RevokePermission(pageDeletePermission, user);
                    //                permissionsResult.Permissions.Remove(pageDeletePermission);
                    //            }

                    //            if (permissions1.Any(s => s.Name == pagePostPermission))
                    //            {
                    //                await RevokePermission(pagePostPermission, user);
                    //                permissionsResult.Permissions.Remove(pagePostPermission);
                    //            }

                    //            if (permissions1.Any(s => s.Name == pageUnPostPermission))
                    //            {
                    //                await RevokePermission(pageUnPostPermission, user);
                    //                permissionsResult.Permissions.Remove(pageUnPostPermission);
                    //            }
                    //        }


                    //        // permissionsResult.Permissions.Add($"{module.Selector}_Module_Free");
                    //    }
                    //}

                }




                ////var IsSubscriptionValid =   user.Claims.FirstOrDefault(x => x.ClaimType.Equals("IsSubscriptionValid", StringComparison.OrdinalIgnoreCase)).Value;
                //var UserClaims = await _userManager.GetClaimsAsync(user);
                //var UserRoleClaims = await _userManager.GetRolesAsync(user);



                //var SubscriptionClaim = UserClaims.SingleOrDefault(x => x.Type == "IsSubscriptionValid")?.Value ;

                //if (_app.IsSubscriptionValid )
                //{
                //    permissionsResult.Permissions.Add("SubscriptionValid");
                //}

            }
            return permissionsResult;
        }
        [AbpAllowAnonymous]
        //[AbpAuthorize]
        public async Task<PermissionsResult> GetActionPermissions(string ActionName)
        {
            PermissionsResult permissionsResult = null;
            var user = _abpSession.UserId != null ? _userManager.FindByIdAsync(_abpSession.UserId.ToString()).Result : null;
            if (user != null)
            {
                var permissions = await _userManager.GetGrantedPermissionsAsync(user);
                permissionsResult = new PermissionsResult()
                {
                    Permissions = permissions?.Where(p => p.Name.ToLower().Contains($"{ActionName.ToLower()}.")).Select(p => p.Name).ToList()
                };
            }
            return permissionsResult;
        }



        //to be used to list all available special action Permissions
        public ICollection<string> GetSpecialPermissionsForCurrentAction(string ActionName)
        {
            return _permissionManager.GetAllPermissions().Where(p => p.Name.Contains($"{ActionName}.Detail")).Select(p => p.Name).ToList();
        }

        //to be used to get the user granted special permissions for update purpose
        public async Task<PermissionsResult> GetActionSpecialPermissionsForUserToUpdate(string ActionName, string UserId)
        {
            PermissionsResult permissionsResult = null;
            var user = _userManager.FindByIdAsync(UserId).Result;
            if (user != null)
            {
                var permissions = await _userManager.GetGrantedPermissionsAsync(user);
                permissionsResult = new PermissionsResult()
                {
                    Permissions = permissions?.Where(p => p.Name.ToLower().Contains($"{ActionName.ToLower()}.detail.")).Select(p => p.Name).ToList()
                };
            }
            return permissionsResult;
        }

        public async Task<bool> UpdateSpecialPermissionsForUseInAction(SpecialPermissionInputDto input)
        {
            try
            {
                var user = await _userManager.GetUserByIdAsync(input.UserId);
                foreach (var grantedPermission in input.AllowedPermissions)
                {
                    if (grantedPermission.Contains($"{input.ActionName}.Detail"))
                    {
                        var granted = _permissionManager.GetPermissionOrNull(grantedPermission);

                        await _userManager.GrantPermissionAsync(user, granted);
                    }
                    else
                    {
                        return false;
                    }
                }
                foreach (var ProhibitedPermission in input.DeniedPermissions)
                {
                    if (ProhibitedPermission.Contains($"{input.ActionName}.Detail"))
                    {
                        var granted = _permissionManager.GetPermissionOrNull(ProhibitedPermission);

                        await _userManager.ProhibitPermissionAsync(user, granted);
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        private async Task<string> GetPortalUserNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "PortalUser", TenantId = 0, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }




        [AbpAllowAnonymous]
        public async Task<int> GetNewNotificationsCount()
        {
            var user = _abpSession.UserId != null ? _userManager.FindByIdAsync(_abpSession.UserId.ToString()).Result : null;
            if (user != null)
            {
                return await _userNotificationManager.GetUserNotificationCountAsync(new UserIdentifier(user.TenantId, user.Id), UserNotificationState.Unread);
            }
            return -1;
        }

        [AbpAllowAnonymous]
        public async Task<List<UserNotification>> NotificationsList(int? state = null, int skip = 0, int take = 10)
        {
            var user = _abpSession.UserId != null ? _userManager.FindByIdAsync(_abpSession.UserId.ToString()).Result : null;
            if (user != null)
            {
                return await _userNotificationManager.GetUserNotificationsAsync
                    (new UserIdentifier(user.TenantId, user.Id), (UserNotificationState?)state, skip, take);
            }
            return null;
        }

        private List<UserNotification> CreateFilteredQueryForNotification(NotificationPagedAndSortedDto input, User user)
        {
            int skip = 0;
            int take = 10;

            var pagedInput = input as IPagedResultRequest;
            if (pagedInput != null)
            {
                skip = pagedInput.SkipCount;
                //take = pagedInput.MaxResultCount;
            }

            //Try to limit query result if available
            var limitedInput = input as ILimitedResultRequest;
            if (limitedInput != null)
            {
                take = limitedInput.MaxResultCount;
            }

            List<UserNotification> notifications = _userNotificationManager.GetUserNotifications(new UserIdentifier(user.TenantId, user.Id),
                (UserNotificationState?)input.Params.State, skip, take); // as IQueryable<UserNotification>;

            return notifications; //.Select(n=>n.Notification.Data.Properties);

            //if (input == null | input.Params == null)
            //    return _userNotificationManager.GetUserNotifications(new UserIdentifier(user.TenantId, user.Id), null, skip, take); // as IQueryable<UserNotification>;
            //return _userNotificationManager.GetUserNotifications(new UserIdentifier(user.TenantId, user.Id),
            //    (UserNotificationState?)input.Params.State, skip, take); // as IQueryable<UserNotification>;
            //.WhereIf(!input.Params.Message.IsNullOrWhiteSpace(), x => x.UserName.Contains(input.Params.Message))
            //.WhereIf(!input.Params.FromDate.IsNullOrWhiteSpace()//, x => x.Name.Contains(input.Params.Name))
            //.WhereIf(!input.Params.ToDate.IsNullOrWhiteSpace()//, x => x.Surname.Contains(input.Params.Surname))
            //.WhereIf(input.Params.State.HasValue, x => x.stat.Contains(input.Params.State))
        }

        protected virtual IQueryable<UserNotification> ApplySorting2(IQueryable<UserNotification> query, NotificationPagedAndSortedDto input)
        {
            //Try to sort query if available
            //var sortInput = input as ISortedResultRequest;
            //if (sortInput != null)
            //{
            //    if (!sortInput.Sorting.IsNullOrWhiteSpace())
            //    {
            //        return query.OrderBy(sortInput.Sorting);
            //    }
            //}

            ////IQueryable.Task requires sorting, so we should sort if Take will be used.
            //if (input is ILimitedResultRequest)
            //{
            //    return query.OrderByDescending(e => e.Id);
            //}

            //No sorting
            return query;
        }

        public class UserNotificationDto
        {
            public Guid Id { get; set; }
            public string State { get; set; }
            public string Date { get; set; }
            public Dictionary<string, object> props { get; set; }
        }
        [AbpAllowAnonymous]
        public async Task<PagedResultDto<UserNotificationDto>> GetNotificationsList(NotificationPagedAndSortedDto input) //notificationPagedAndSortedDto)
        {
            var user = _abpSession.UserId != null ? _userManager.FindByIdAsync(_abpSession.UserId.ToString()).Result : null;
            if (user != null)
            {
                var notifications = CreateFilteredQueryForNotification(input, user);

                var totalCount = await _userNotificationManager.GetUserNotificationCountAsync(
                    new UserIdentifier(user.TenantId, user.Id)
                    , (UserNotificationState?) input.Params.State
                    ); //notifications.Count; //await AsyncQueryableExecuter.CountAsync(query);

                //query = ApplySorting2(query, input);

                //var entities = await AsyncQueryableExecuter.ToListAsync(query);
                //x.Notification.Data.Properties.TryGetValue("Message", out string Message);
                return new PagedResultDto<UserNotificationDto>(
                    totalCount,
                    notifications.Select(x =>
                    new UserNotificationDto
                    {
                        Id = x.Id,
                        State = ((UserNotificationState)x.State).ToString(),
                        Date = x.Notification.CreationTime.ToString(Formatters.DateTimeFormat),
                        props = x.Notification.Data.Properties
                    }).ToList()
                );

                //if (notificationPagedAndSortedDto != null)
                //{
                //    return await _userNotificationManager.GetUserNotificationsAsync
                //        (new UserIdentifier(user.TenantId, user.Id), 
                //        (UserNotificationState?)notificationPagedAndSortedDto.Params.State,
                //        notificationPagedAndSortedDto.SkipCount, 
                //        notificationPagedAndSortedDto.MaxResultCount);
                //}
            }
            return null;
        }

        [AbpAllowAnonymous]
        public async Task ChangeNotificationState(string notificationId, int state = (int)UserNotificationState.Read)
        {
            var user = _abpSession.UserId != null ? _userManager.FindByIdAsync(_abpSession.UserId.ToString()).Result : null;
            if (user != null)
            {
                Guid notificationGuid = new Guid(notificationId);
                await _userNotificationManager.UpdateUserNotificationStateAsync(user.TenantId, notificationGuid, (UserNotificationState)state);
            }
        }

        [AbpAllowAnonymous]
        public async Task DeleteNotification(string notificationId)
        {
            var user = _abpSession.UserId != null ? _userManager.FindByIdAsync(_abpSession.UserId.ToString()).Result : null;
            if (user != null)
            {
                Guid notificationGuid = new Guid(notificationId);
                await _userNotificationManager.DeleteUserNotificationAsync(user.TenantId, notificationGuid);
            }
        }


        private async Task RevokePermission(string permission ,User user)
        {
            var _permission = _permissionManager.GetPermission(permission);
            await _userManager.ProhibitPermissionAsync(user, _permission);
        }

        private async Task GrantPermission(string permission, User user)
        {
            var _permission = _permissionManager.GetPermission(permission);
            await _userManager.GrantPermissionAsync(user, _permission);
        }

        private async Task<List<string>> GrantModulePermission(ModuleDto module, User user,IEnumerable<Permission> tenentPermissions)
        {
            var GrantedPerms = new List<string>();
            foreach (var page in module.Pages)
            {

                var pagepageission = $"Pages.{page.Selector}";
                var pageInsertpageission = $"Pages.{page.Selector}.Insert";
                var pageUpdatepageission = $"Pages.{page.Selector}.Update";
                var pageDeletepageission = $"Pages.{page.Selector}.Delete";
                var pagePostpageission = $"Pages.{page.Selector}.Post";
                var pageUnPostpageission = $"Pages.{page.Selector}.UnPost";


                if (tenentPermissions.Any(s => s.Name == pagepageission))
                {
                    await GrantPermission(pagepageission, user);
                    GrantedPerms.Add(pagepageission);
                }

                if (tenentPermissions.Any(s => s.Name == pageInsertpageission))
                {
                    await GrantPermission(pageInsertpageission, user);
                    GrantedPerms.Add(pageInsertpageission);
                }

                if (tenentPermissions.Any(s => s.Name == pageUpdatepageission))
                {
                    await GrantPermission(pageUpdatepageission, user);
                    GrantedPerms.Add(pageUpdatepageission);
                }

                if (tenentPermissions.Any(s => s.Name == pageDeletepageission))
                {
                    await GrantPermission(pageDeletepageission, user);
                    GrantedPerms.Add(pageDeletepageission);
                }

                if (tenentPermissions.Any(s => s.Name == pagePostpageission))
                {
                    await GrantPermission(pagePostpageission, user);
                    GrantedPerms.Add(pagePostpageission);
                }

                if (tenentPermissions.Any(s => s.Name == pageUnPostpageission))
                {
                    await GrantPermission(pageUnPostpageission, user);
                    GrantedPerms.Add(pageUnPostpageission);
                }
            }
            return GrantedPerms;
        }

        private async Task<List<string>> RevokeModulePermission(ModuleDto module, User user, IEnumerable<Permission> tenentPermissions)
        {
            var RevokededPerms = new List<string>();
            foreach (var page in module.Pages)
            {
                var pagepageission = $"Pages.{page.Selector}";
                var pageInsertpageission = $"Pages.{page.Selector}.Insert";
                var pageUpdatepageission = $"Pages.{page.Selector}.Update";
                var pageDeletepageission = $"Pages.{page.Selector}.Delete";
                var pagePostpageission = $"Pages.{page.Selector}.Post";
                var pageUnPostpageission = $"Pages.{page.Selector}.UnPost";

                if (tenentPermissions.Any(s => s.Name == pagepageission))
                {
                    await RevokePermission(pagepageission, user);
                    RevokededPerms.Add(pagepageission);
                }

                if (tenentPermissions.Any(s => s.Name == pageInsertpageission))
                {
                    await RevokePermission(pageInsertpageission, user);
                    RevokededPerms.Add(pageInsertpageission);
                }

                if (tenentPermissions.Any(s => s.Name == pageUpdatepageission))
                {
                    await RevokePermission(pageUpdatepageission, user);
                    RevokededPerms.Add(pageUpdatepageission);
                }

                if (tenentPermissions.Any(s => s.Name == pageDeletepageission))
                {
                    await RevokePermission(pageDeletepageission, user);
                    RevokededPerms.Add(pageDeletepageission);
                }

                if (tenentPermissions.Any(s => s.Name == pagePostpageission))
                {
                    await RevokePermission(pagePostpageission, user);
                    RevokededPerms.Add(pagePostpageission);
                }

                if (tenentPermissions.Any(s => s.Name == pageUnPostpageission))
                {
                    await RevokePermission(pageUnPostpageission, user);
                    RevokededPerms.Add(pageUnPostpageission);
                }
            }
            return RevokededPerms;
        }



        private async Task<List<string>> ManageModulePagesPermissionsAsync(User user,List<Permission> userPerms )
        {
            List<string> Permessions =new List<string>();

          //  var TenentPermissions = _permissionManager.GetAllPermissions(true).ToList();

            var res = await _tenantFreeModulesAppService.GetTenantAppModules(new EntityDto<long> { Id = (AbpSession.TenantId == null ? 0 : AbpSession.TenantId.Value) });
            foreach (var module in res.TenantModules)
            {
                if ((module.IsFree && module.ModuleId != 1) || (module.IsFree &&  user.UserName=="admin"))
                {
                  var GrantedPerms=await  GrantModulePermission(module, user, userPerms);
                  Permessions.AddRange(GrantedPerms);
                }
                else if (module.ModuleId == 1 && user.UserName == "admin")
                {
                    var GrantedPerms = await GrantModulePermission(module, user, userPerms);
                    Permessions.AddRange(GrantedPerms);
                }
                else
                {
                    var RevokedPerms = await RevokeModulePermission(module, user, userPerms);
                   //Permessions.AddRange(RevokedPerms);
                }




                    //foreach (var page in module.Pages)
                    //{
                    //    var pagepageission = $"Pages.{page.Selector}";
                    //    var pageInsertpageission = $"Pages.{page.Selector}.Insert";
                    //    var pageUpdatepageission = $"Pages.{page.Selector}.Update";
                    //    var pageDeletepageission = $"Pages.{page.Selector}.Delete";
                    //    var pagePostpageission = $"Pages.{page.Selector}.Post";
                    //    var pageUnPostpageission = $"Pages.{page.Selector}.UnPost";

                    //    //Not Tenant Admin
                    //    if ( (module.IsFree && module.ModuleId!= 1) || (module.IsFree && res.TenantInfo.Email == user.EmailAddress)  )
                    //    {
                    //        if (TenentPermissions.Any(s => s.Name == pagepageission))
                    //        {
                    //            await GrantPermission(pagepageission, user);
                    //            Permessions.Add(pagepageission);
                    //        }

                    //        if (TenentPermissions.Any(s => s.Name == pageInsertpageission))
                    //        {
                    //            await GrantPermission(pageInsertpageission, user);
                    //            Permessions.Add(pageInsertpageission);
                    //        }

                    //        if (TenentPermissions.Any(s => s.Name == pageUpdatepageission))
                    //        {
                    //            await GrantPermission(pageUpdatepageission, user);
                    //            Permessions.Add(pageUpdatepageission);
                    //        }

                    //        if (TenentPermissions.Any(s => s.Name == pageDeletepageission))
                    //        {
                    //            await GrantPermission(pageDeletepageission, user);
                    //            Permessions.Add(pageDeletepageission);
                    //        }

                    //        if (TenentPermissions.Any(s => s.Name == pagePostpageission))
                    //        {
                    //            await GrantPermission(pagePostpageission, user);
                    //            Permessions.Add(pagePostpageission);
                    //        }

                    //        if (TenentPermissions.Any(s => s.Name == pageUnPostpageission))
                    //        {
                    //            await GrantPermission(pageUnPostpageission, user);
                    //            Permessions.Add(pageUnPostpageission);
                    //        }

                    //    }
                    //    else
                    //    {
                    //        if (TenentPermissions.Any(s => s.Name == pagepageission))
                    //        {
                    //            await RevokePermission(pagepageission, user);
                    //        }

                    //        if (TenentPermissions.Any(s => s.Name == pageInsertpageission))
                    //        {
                    //            await RevokePermission(pageInsertpageission, user);
                    //        }

                    //        if (TenentPermissions.Any(s => s.Name == pageUpdatepageission))
                    //        {
                    //            await RevokePermission(pageUpdatepageission, user);
                    //        }

                    //        if (TenentPermissions.Any(s => s.Name == pageDeletepageission))
                    //        {
                    //            await RevokePermission(pageDeletepageission, user);
                    //        }

                    //        if (TenentPermissions.Any(s => s.Name == pagePostpageission))
                    //        {
                    //            await RevokePermission(pagePostpageission, user);
                    //        }

                    //        if (TenentPermissions.Any(s => s.Name == pageUnPostpageission))
                    //        {
                    //            await RevokePermission(pageUnPostpageission, user);
                    //        }
                    //    }

                    //}

            }


            return Permessions;

        }

    }
}

