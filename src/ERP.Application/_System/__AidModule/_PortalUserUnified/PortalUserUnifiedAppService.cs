using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.UI;
using ERP._System.__AidModule._Portal;
using ERP._System.__AidModule._PortalUserData;
using ERP._System.__AidModule._PortalUserData.Dto;
using ERP._System.__AidModule._PortalUserUnified.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using ERP.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._PortalUserUnified
{
    [AbpAuthorize]
    public class PortalUserUnifiedAppService : AsyncCrudAppService<PortalUser, PortalUserUnifiedDto, long, PortalUserUnifiedPagedDto, PortalUserUnifiedCreateDto, PortalUserUnifiedEditDto>,
        IPortalUserUnifiedAppService
    {
        private readonly IPortalUserDataAppService _portalUserDataAppService;
        private readonly IStoredUserInfoManager _storedUserInfoManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<PortalUserData, long> _repoPortalUserData;
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly UserManager _userManager;

        public PortalUserUnifiedAppService(IRepository<PortalUser, long> repository,
            IRepository<PortalUserData, long> repoPortalUserData,
            IRepository<Tenant> tenantRepository, IStoredUserInfoManager storedUserInfoManager,
            UserManager userManager, IPortalUserDataAppService portalUserDataAppService,
            IGetCounterRepository getCounterRepository) : base(repository)
        {
            _userManager = userManager;
            _repoProcCounter = getCounterRepository;
            _tenantRepository = tenantRepository;
            _repoPortalUserData = repoPortalUserData;
            _storedUserInfoManager = storedUserInfoManager;
            _portalUserDataAppService = portalUserDataAppService;

            CreatePermissionName = PermissionNames.Pages_PortalUser_Insert;
            UpdatePermissionName = PermissionNames.Pages_PortalUser_Update;
            DeletePermissionName = PermissionNames.Pages_PortalUser_Delete;
            GetAllPermissionName = PermissionNames.Pages_PortalUser;
        }

        public async override Task<PagedResultDto<PortalUserUnifiedDto>> GetAll(PortalUserUnifiedPagedDto input)
        {
            CurrentUnitOfWork.SetTenantId(null);

            var queryable = Repository.GetAllIncluding(x => x.GenderFndLookupValues,
                                       x => x.MaritalStatusFndLookupValues, x => x.NationalityFndLookupValues, x => x.QualificationFndLookupValues,
                                       x => x.CityFndLookupValues, x => x.FndCaseCategoryLkp);

            queryable = FilterGetAll(queryable, input);

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            var count = await queryable.CountAsync();

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var dataMapped = ObjectMapper.Map(data, new List<PortalUserUnifiedDto>());

            var PagedResultDto = new PagedResultDto<PortalUserUnifiedDto>()
            {
                Items = dataMapped as IReadOnlyList<PortalUserUnifiedDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<PortalUserUnifiedDto> Create(PortalUserUnifiedCreateDto input)
        {
            if (RepeatedIdNumberForUser(input) || await IdNumberNotRepeatedInDB(input))
                throw new UserFriendlyException("Invalid Data, IdNumber Exist.");

            input.UserId = await CreateIdentityUser(input);
            input.CaseNumber = await GetPortalUserNumber();
            input.User = input.UserId == null ? null : input.User;
            input.TenantCreatorId = AbpSession.TenantId;

            var portalUserUnified = await base.Create(input);

            var mappedPortalUserToPortalUserData = ObjectMapper.Map<PortalUserDataCreateDto>(input);

            mappedPortalUserToPortalUserData.PortalUserId = portalUserUnified.Id;

            await _portalUserDataAppService.CreateMaster(mappedPortalUserToPortalUserData);

            return new PortalUserUnifiedDto { Id = portalUserUnified.Id };
        }

        public async override Task<PortalUserUnifiedDto> Update(PortalUserUnifiedEditDto input)
        {
            var current = await Repository.GetAsync(input.Id);

            if ((current.UserId == AbpSession.UserId && current.HasNoRequests()))
            {
                _ = await UpdateBody(input, current);

                CurrentUnitOfWork.SetTenantId(null);

                var portalUsersData = await _repoPortalUserData.GetAllListAsync(z => z.PortalUserId == current.Id);

                if (portalUsersData?.Count > 0)
                {
                    foreach (var item in portalUsersData)
                    {
                        ObjectMapper.Map(input, item);

                        await _repoPortalUserData.UpdateAsync(item);
                    }
                }

                return null;
            }
            else
            {
                CheckUpdatePermission();

                return await UpdateBody(input, current);
            }
        }

        public async override Task<PortalUserUnifiedDto> Get(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.GenderFndLookupValues,
                                  x => x.MaritalStatusFndLookupValues, x => x.NationalityFndLookupValues, x => x.QualificationFndLookupValues,
                                  x => x.CityFndLookupValues, x => x.FndCaseCategoryLkp)
                                    .Where(z => z.UserId == AbpSession.UserId).FirstOrDefaultAsync();

            return MapToEntityDto(current);

            //if (current.UserId == AbpSession.UserId || !current.User.IsPortalUser)
            //{
            //    returnValue.hasNoRequests = current.HasNoRequests();
            //    return returnValue;
            //}

            //throw new UserFriendlyException("Invalid Data.");
        }

        public async Task<PortalUserUnifiedDto> GetDetailAsync(EntityDto<long> input)
        {
            CurrentUnitOfWork.SetTenantId(null);

            var current = await Repository.GetAllIncluding(x => x.GenderFndLookupValues,
                                  x => x.MaritalStatusFndLookupValues, x => x.NationalityFndLookupValues, x => x.QualificationFndLookupValues,
                                  x => x.CityFndLookupValues, x => x.FndCaseCategoryLkp)
                                    .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var currentDto = ObjectMapper.Map<PortalUserUnifiedDto>(current);

           // await GetSourceAndCreatorNames(currentDto);

            if (currentDto.LastModifierUserId != null)
            {
                var updatedUserInfo = await _storedUserInfoManager.GetUserInfo((long)currentDto.LastModifierUserId);
                currentDto.LastModificationUser = updatedUserInfo?.Name ?? string.Empty;
            }

            return currentDto;
        }

        public async Task<PortalUserUnifiedDto> GetUnifiedUserInfo(EntityDto<long> input)
        {
            CurrentUnitOfWork.SetTenantId(null);

            var current = await Repository.GetAllIncluding(x => x.GenderFndLookupValues,
                                         x => x.MaritalStatusFndLookupValues, x => x.QualificationFndLookupValues, x => x.CityFndLookupValues, x => x.FndCaseCategoryLkp)
                                    .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<PortalUserUnifiedDto>(current);
        }

        public async Task<bool> IdNumberNotRepeatedInDB(CheckIdNumbersDto input)
        {

            var count = await Repository.LongCountAsync(u => u.Id != input.id &&
                ((
                    (input.IdNumber != null &&
                    (
                     u.IdNumber == input.IdNumber
                    || u.IdNumberWifeHusband1 == input.IdNumber
                    || u.IdNumberWife2 == input.IdNumber
                    || u.IdNumberWife3 == input.IdNumber
                    || u.IdNumberWife4 == input.IdNumber)
                    )
                )
                ||
                (
                    (!string.IsNullOrEmpty(input.idNumberWifeHusband1) && (u.IdNumberWifeHusband1 == input.idNumberWifeHusband1 || u.IdNumber == input.idNumberWifeHusband1
                    || u.IdNumberWife2 == input.idNumberWifeHusband1 || u.IdNumberWife3 == input.idNumberWifeHusband1 || u.IdNumberWife4 == input.idNumberWifeHusband1))
                )
                ||
                (
                    (!string.IsNullOrEmpty(input.idNumberWife2) && (u.IdNumberWife2 == input.idNumberWife2 || u.IdNumber == input.idNumberWife2 || u.IdNumberWifeHusband1 == input.idNumberWife2
                    || u.IdNumberWife3 == input.idNumberWife2 || u.IdNumberWife4 == input.idNumberWife2))
                )
                ||
                (
                    (!string.IsNullOrEmpty(input.idNumberWife3) && (u.IdNumberWife3 == input.idNumberWife3 || u.IdNumber == input.idNumberWife3 || u.IdNumberWifeHusband1 == input.idNumberWife3 || u.IdNumberWife2 == input.idNumberWife3
                     || u.IdNumberWife4 == input.idNumberWife3))
                )
                ||
                (
                    (!string.IsNullOrEmpty(input.idNumberWife4) && (u.IdNumberWife4 == input.idNumberWife4 || u.IdNumber == input.idNumberWife4 || u.IdNumberWifeHusband1 == input.idNumberWife4 || u.IdNumberWife2 == input.idNumberWife4
                    || u.IdNumberWife3 == input.idNumberWife4))
                )
                )
            );

            return count != 0;
        }

        public override Task Delete(EntityDto<long> input) => throw new UserFriendlyException("Invalid");

        protected virtual void CheckErrors(IdentityResult identityResult) => identityResult.CheckErrors(LocalizationManager);

        #region Assets Methods

        private IQueryable<PortalUser> FilterGetAll(IQueryable<PortalUser> queryable, PortalUserUnifiedPagedDto input)
        {
            if (input.Params != null && !string.IsNullOrEmpty(input.Params.IdNumber))
                queryable = queryable.Where(q => q.IdNumber.Contains(input.Params.IdNumber) ||
                q.IdNumberWifeHusband1.Contains(input.Params.IdNumber) || q.IdNumberWife2.Contains(input.Params.IdNumber) ||
                q.IdNumberWife3.Contains(input.Params.IdNumber) || q.IdNumberWife4.Contains(input.Params.IdNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PhoneNumber))
                queryable = queryable.Where(q =>
                q.PhoneNumber.Contains(input.Params.PhoneNumber) || q.MobileNumber1.Contains(input.Params.PhoneNumber) ||
                q.MobileNumber2.Contains(input.Params.PhoneNumber)
                );

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.CaseNumber))
                queryable = queryable.Where(q => q.CaseNumber.Contains(input.Params.CaseNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Name))
                queryable = queryable.Where(q => q.Name.Contains(input.Params.Name));

            if (input.Params != null && input.Params.GenderLkpId != null)
                queryable = queryable.Where(q => q.GenderLkpId == input.Params.GenderLkpId);

            if (input.Params != null && input.Params.NationalityLkpId != null)
                queryable = queryable.Where(q => q.NationalityLkpId == input.Params.NationalityLkpId);

            if (input.Params != null && input.Params.CityLkpId != null)
                queryable = queryable.Where(q => q.CityLkpId == input.Params.CityLkpId);

            if (input.Params != null && input.Params.SourceId != null)
                queryable = queryable.Where(q => q.TenantCreatorId == input.Params.SourceId);

            if (input.Params != null && input.Params.CreatorId != null)
                queryable = queryable.Where(q => q.CreatorUserId == input.Params.CreatorId);

            if (input.Params != null && input.Params.CaseCategoryLkpId != null)
                queryable = queryable.Where(q => q.CaseCategoryLkpId == input.Params.CaseCategoryLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FromDate))
                queryable = queryable.Where(q => DateTimeController.ConvertToDateTime(input.Params.FromDate) <= q.CreationTime);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ToDate))
                queryable = queryable.Where(q => DateTimeController.ConvertToDateTime(input.Params.ToDate) >= q.CreationTime);

            return queryable;
        }

        private bool RepeatedIdNumberForUser(PortalUserUnifiedCreateDto input)
        {
            var valid = (
                    (!string.IsNullOrEmpty(input.IdNumber) &&
                        (input.IdNumber == input.IdNumberWifeHusband1 || input.IdNumber == input.IdNumberWife2 || input.IdNumber == input.IdNumberWife3 || input.IdNumber == input.IdNumberWife4)
                    )
                    ||
                    (!string.IsNullOrEmpty(input.IdNumberWifeHusband1) &&
                        (input.IdNumberWifeHusband1 == input.IdNumber || input.IdNumberWifeHusband1 == input.IdNumberWife2 || input.IdNumberWifeHusband1 == input.IdNumberWife3 || input.IdNumberWifeHusband1 == input.IdNumberWife4)
                    )
                    ||
                    (!string.IsNullOrEmpty(input.IdNumberWife2) &&
                        (input.IdNumberWife2 == input.IdNumberWifeHusband1 || input.IdNumberWife2 == input.IdNumber || input.IdNumberWife2 == input.IdNumberWife3 || input.IdNumberWife2 == input.IdNumberWife4)
                    )
                    ||
                    (!string.IsNullOrEmpty(input.IdNumberWife3) &&
                        (input.IdNumberWife3 == input.IdNumber || input.IdNumberWife3 == input.IdNumberWife2 || input.IdNumberWife3 == input.IdNumberWifeHusband1 || input.IdNumberWife3 == input.IdNumberWife4)
                    )
                    ||
                    (!string.IsNullOrEmpty(input.IdNumberWife4) &&
                        (input.IdNumberWife4 == input.IdNumber || input.IdNumberWife4 == input.IdNumberWife2 || input.IdNumberWife4 == input.IdNumberWife3 || input.IdNumberWife4 == input.IdNumberWifeHusband1)
                    )
                );

            return valid;
        }

        private async Task<PortalUserUnifiedDto> UpdateBody(PortalUserUnifiedEditDto input, PortalUser current)
        {
            ObjectMapper.Map(input,current);

            if (current.RepeatedIdNumberForUser() ||
                await IdNumberNotRepeatedInDB(ObjectMapper.Map<PortalUserUnifiedDto>(input)))
                throw new UserFriendlyException("Invalid Data, IdNumber Exist.");

            return ObjectMapper.Map<PortalUserUnifiedDto>(await Repository.UpdateAsync(current));
        }

        private async Task<long?> CreateIdentityUser(PortalUserUnifiedCreateDto input)
        {
            if (input.User != null && !string.IsNullOrEmpty(input.User.UserName) && !string.IsNullOrEmpty(input.User.EmailAddress)
                && !string.IsNullOrEmpty(input.User.Password))
            {
                var user = ObjectMapper.Map<User>(input.User);

                user.TenantId = null;
                user.IsEmailConfirmed = true;
                user.IsActive = true;
                user.IsPortalUser = true;

                using (CurrentUnitOfWork.SetTenantId(null))
                {
                    await _userManager.InitializeOptionsAsync(tenantId: null);

                    CheckErrors(await _userManager.CreateAsync(user, input.User.Password));

                    CurrentUnitOfWork.SaveChanges();

                    return user.Id;
                }
            }
            else
            {
                return null;
            }
        }

        private async Task<bool> IdNumberNotRepeatedInDB(PortalUserUnifiedCreateDto input)
        {
            CheckIdNumbersDto checkIdNumbersDto = new CheckIdNumbersDto()
            {
                IdNumber = input.IdNumber,
                idNumberWifeHusband1 = input.IdNumberWifeHusband1,
                idNumberWife2 = input.IdNumberWife2,
                idNumberWife3 = input.IdNumberWife3,
                idNumberWife4 = input.IdNumberWife4
            };

            var valid = await IdNumberNotRepeatedInDB(checkIdNumbersDto);

            return valid;
        }

        private async Task<bool> IdNumberNotRepeatedInDB(PortalUserUnifiedDto input)
        {
            CheckIdNumbersDto checkIdNumbersDto = new CheckIdNumbersDto()
            {
                id = input.Id,
                IdNumber = input.IdNumber,
                idNumberWifeHusband1 = input.IdNumberWifeHusband1,
                idNumberWife2 = input.IdNumberWife2,
                idNumberWife3 = input.IdNumberWife3,
                idNumberWife4 = input.IdNumberWife4
            };
            return await IdNumberNotRepeatedInDB(checkIdNumbersDto);
        }

        private async Task GetSourceAndCreatorNames(PortalUserUnifiedDto portalUserDto)
        {
            portalUserDto.UserName = portalUserDto?.User?.UserName ?? string.Empty;
            portalUserDto.EmailAddress = portalUserDto?.User?.EmailAddress ?? string.Empty;
            portalUserDto.Source = portalUserDto.SourceCreatorName = "تسجيل اليكتروني";

            if (portalUserDto.TenantCreatorId != null && portalUserDto.TenantCreatorId != 0)
            {
                string creatorName = string.Empty;

                if (portalUserDto.CreatorUserId != null)
                {
                    CurrentUnitOfWork.SetTenantId(portalUserDto.TenantCreatorId);

                    var user = await _userManager.GetUserByIdAsync((long)portalUserDto.CreatorUserId);

                    creatorName = user?.Name;
                }

                CurrentUnitOfWork.SetTenantId(null);

                var tnnt = await _tenantRepository.GetAsync((int)portalUserDto.TenantCreatorId);

                portalUserDto.Source = tnnt?.Name ?? string.Empty;
                portalUserDto.SourceCreatorName = creatorName;
            }
        }

        private async Task<string> GetPortalUserNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "PortalUser", TenantId = 0, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }

        #endregion
    }
}
