using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__AccountModule._Portal.Stored.Dto;
using ERP._System.__AidModule._Portal;
using ERP._System.__AidModule._Portal._PortalFndUsers.Proc;
using ERP._System.__AidModule._Portal._PortalFndUsers.ProcDto;
using ERP._System.__AidModule._Portal._PortalUserAttachments;
using ERP._System.__AidModule._Portal._PortalUserDuties;
using ERP._System.__AidModule._Portal._PortalUserIncomes;
using ERP._System.__AidModule._Portal.Stored.Dto;
using ERP._System.__AidModule._Portal.UserAttachments;
using ERP._System.__AidModule._Portal.UserDuites;
using ERP._System.__AidModule._Portal.UserIncomes;
using ERP._System.__AidModule._PortalUserData.Dto;
using ERP._System.__AidModule._PortalUserUnified.Dto;
using ERP._System._Portal;
using ERP._System._Portal._PortalFndUsers;
using ERP._System._Portal.Stored.Dto;
using ERP._System._Portal.UserRelatives.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using ERP.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._PortalUserData
{
    [AbpAuthorize]
    public class PortalUserDataAppService : AttachBaseAsyncCrudAppService<PortalUserData, PortalUserDataDto, long, PortalUserUnifiedPagedDto, PortalUserDataCreateDto, PortalUserDataEditDto, PortalUserAttachments>,
        IPortalUserDataAppService
    {
        private readonly IPortalUnifiedUsersManager _portalFndUsersManager;
        private readonly IStoredUserInfoManager _storedUserInfoManager;
        private readonly IPortalUserDashboardRepository _dashboardRepository;
        private readonly IGetPortalUserRequestsRepository _getPortalUserRequestsRepository;
        private readonly IGetFndUsersScreenDataRepository _getFndUsersScreenDataRepository;
        private readonly IGetPortalUserRefusedRequestsRepository _getPortalUserRefusedRequestsRepository;
        private readonly IRepository<PortalUserRelatives, long> _repoPortalUserRelatives;
        private readonly IRepository<PortalUserIncomes, long> _repoPortalUserIncomes;
        private readonly IRepository<PortalUserDuties, long> _repoPortalUserDuties;
        private readonly IRepository<PortalUserAttachments, long> _repoPortalUserAttachments;
        private readonly UserManager _userManager;

        public PortalUserDataAppService(IRepository<PortalUserData, long> repository,
            IRepository<PortalUserRelatives, long> relativesRepo, IRepository<PortalUserAttachments, long> repoPortalUserAttachments,
            IRepository<PortalUserDuties, long> repoPortalUserDuties, IRepository<PortalUserIncomes, long> repoPortalUserIncomes,
            IGetPortalUserRequestsRepository getPortalUserRequestsRepository,
            IPortalUserDashboardRepository portalUserDashboardRepository, IGetFndUsersScreenDataRepository getFndUsersScreenDataRepository,
            IGetPortalUserRefusedRequestsRepository getPortalUserRefusedRequestsRepository,
            UserManager userManager, IStoredUserInfoManager storedUserInfoManager,
            IPortalUnifiedUsersManager portalFndUsersManager, IConfiguration config) : base(repository, config)
        {
            _userManager = userManager;
            _repoPortalUserRelatives = relativesRepo;
            _repoPortalUserAttachments = repoPortalUserAttachments;
            _repoPortalUserIncomes = repoPortalUserIncomes;
            _repoPortalUserDuties = repoPortalUserDuties;
            _portalFndUsersManager = portalFndUsersManager;
            _storedUserInfoManager = storedUserInfoManager;
            _dashboardRepository = portalUserDashboardRepository;
            _getFndUsersScreenDataRepository = getFndUsersScreenDataRepository;
            _getPortalUserRequestsRepository = getPortalUserRequestsRepository;
            _getPortalUserRefusedRequestsRepository = getPortalUserRefusedRequestsRepository;

            CreatePermissionName = PermissionNames.Pages_PortalUserData_Insert;
            UpdatePermissionName = PermissionNames.Pages_PortalUserData_Update;
            DeletePermissionName = PermissionNames.Pages_PortalUserData_Delete;
            GetAllPermissionName = PermissionNames.Pages_PortalUserData;

            PreFileName = "Users-Attchs";
            ServiceFolder = "PortalUser/Attachments";
        }

        public async override Task<PagedResultDto<PortalUserDataDto>> GetAll(PortalUserUnifiedPagedDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.GenderFndLookupValues, x => x.PortalUser,
                                       x => x.MaritalStatusFndLookupValues, x => x.QualificationFndLookupValues,
                                       x => x.CityFndLookupValues, x => x.FndCaseCategoryLkp);

            queryable = FilterGetAll(queryable, input);

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            var count = await queryable.CountAsync();

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var dataMapped = ObjectMapper.Map(data, new List<PortalUserDataDto>());

            foreach (var item in dataMapped) await GetSourceAndCreatorNames(item);

            var PagedResultDto = new PagedResultDto<PortalUserDataDto>()
            {
                Items = dataMapped as IReadOnlyList<PortalUserDataDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<PortalUserDataDto> Create(PortalUserDataCreateDto input)
        {
            long entityPK = 0;

            var checkIfCurrentInPortalUserData = await Repository.FirstOrDefaultAsync(z => z.PortalUserId == input.PortalUserId);

            if (checkIfCurrentInPortalUserData != null)
            {
                CheckUpdatePermission();

                entityPK = checkIfCurrentInPortalUserData.Id;

                ObjectMapper.Map(input, checkIfCurrentInPortalUserData);

                await Repository.UpdateAsync(checkIfCurrentInPortalUserData);
            }
            else
            {
                CheckCreatePermission();

                var current = await this.CreateMaster(input);
                entityPK = current.Id;
            }

            if (input.UserRelatives?.Count > 0)
                foreach (var item in input.UserRelatives)
                    await InsertPortalUserRelativesData(item, entityPK);

            if (input.UserIncomes?.Count > 0)
                foreach (var item in input.UserIncomes)
                    await InsertPortalUserIncomesData(item, entityPK);

            if (input.UserDuties?.Count > 0)
                foreach (var item in input.UserDuties)
                    await InsertPortalUserDutiesData(item, entityPK);

            if (input.UserAttachments?.Count > 0)
                foreach (var item in input.UserAttachments)
                    await InsertPortalUserAttachmentsData(item, entityPK);

            return null;
        }

        public async override Task<PortalUserDataDto> Update(PortalUserDataEditDto input)
        {
            _ = await base.Update(input);

            await CRUD_PortalUserRelatives(input.UserRelatives, input.Id);
            await CRUD_PortalUserIncomes(input.UserIncomes, input.Id);
            await CRUD_PortalUserDuties(input.UserDuties, input.Id);
            await CRUD_PortalUserAttachments(input.UserAttachments, input.Id);

            return null;
        }

        public async override Task<PortalUserDataDto> Get(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.PortalUser, x => x.QualificationFndLookupValues, x => x.FndCaseCategoryLkp,
                                  x => x.MaritalStatusFndLookupValues, x => x.GenderFndLookupValues, x => x.CityFndLookupValues)
                                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var currentDto = ObjectMapper.Map<PortalUserDataDto>(current);

            await GetSourceAndCreatorNames(currentDto);

            if (currentDto.LastModifierUserId != null)
            {
                var updatedUserInfo = await _storedUserInfoManager.GetUserInfo((long)currentDto.LastModifierUserId);
                currentDto.LastModificationUser = updatedUserInfo?.Name ?? string.Empty;
            }

            return currentDto;
        }

        public async Task<PortalUserDataDto> GetPortalUserInfo(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.PortalUser, x => x.PortalUser.NationalityFndLookupValues,
                                  x => x.QualificationFndLookupValues, x => x.MaritalStatusFndLookupValues, x => x.CityFndLookupValues,
                                  x => x.PortalUserIncomes, x => x.PortalUserDuties)
                                .Where(z => z.PortalUserId == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<PortalUserDataDto>(current);
        }

        public async Task<List<PortalUserRelativesDto>> GetAllRelativesDetails(EntityDto<long> input)
            => ObjectMapper.Map<List<PortalUserRelativesDto>>(await _repoPortalUserRelatives.GetAllIncluding(z => z.GenderFndLookupValues, x => x.NationalityFndLookupValues,
                    x => x.QualificationFndLookupValues, x => x.RelativesFndLookupValues, x => x.MaritalStatusFndLookupValues).Where(d => d.PortalUserDataId == input.Id).ToListAsync());

        public async Task<List<PortalUserIncomesDto>> GetAllIncomesDetails(EntityDto<long> input)
            => ObjectMapper.Map<List<PortalUserIncomesDto>>(await _repoPortalUserIncomes.GetAll().Where(d => d.PortalUserDataId == input.Id).ToListAsync());

        public async Task<List<PortalUserDutiesDto>> GetAllDutiesDetails(EntityDto<long> input)
            => ObjectMapper.Map<List<PortalUserDutiesDto>>(await _repoPortalUserDuties.GetAll().Where(d => d.PortalUserDataId == input.Id).ToListAsync());

        public async Task<List<PortalUserAttachmentsDto>> GetAllAttachments(EntityDto<long> input)
            => ObjectMapper.Map<List<PortalUserAttachmentsDto>>(await _repoPortalUserAttachments.GetAllIncluding().Where(d => d.PortalUserDataId == input.Id).ToListAsync());

        protected async override Task<PortalUserAttachments> GetAttachmentEntityAsync(long ParentId, long Id, string filePath)
               => await _repoPortalUserAttachments.FirstOrDefaultAsync(att => att.Id == Id && att.PortalUserDataId == ParentId && att.FilePath == filePath);

        public async Task<Select2PagedResult> GetUnifiedPortalUsersFromPortalUsersDataSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _portalFndUsersManager.GetUnifiedPortalUsersFromPortalUsersDataSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetUnifiedPortalUsersFromPortalsersDataWithRelativesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _portalFndUsersManager.GetUnifiedPortalUsersFromPortalsersDataWithRelativesSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetPortalUnfiedUsersForUsersDataSelect2(int tenantId, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _portalFndUsersManager.GetPortalUnfiedUsersForUsersDataSelect2((int)AbpSession.TenantId, searchTerm, pageSize, pageNumber, lang);

        public async Task<PortalUserDataDto> CreateMaster(PortalUserDataCreateDto input) => await base.Create(input);

        public override Task Delete(EntityDto<long> input) => throw new UserFriendlyException("Invalid");

        #region StoredMethods

        public async Task<List<UsersRefusedRequestsOutputDto>> GetPortalRefusedRequests(UsersAidsInputDto input)
        {
            var result = await _getPortalUserRefusedRequestsRepository.Execute(input, "GetPortalUserRequestsRefused");

            return result.ToList();
        }

        public async Task<List<FndUsersScreenDataOutput>> GetFndUsersScreenData(IdLangInputDto input)
        {
            var result = await _getFndUsersScreenDataRepository.Execute(input, "GetFndUsersScreenData");

            return result.ToList();
        }

        public async Task<DashboardOutput> GetDashBoardData()
        {
            DashboardDto input = new DashboardDto();

            if (AbpSession.UserId.HasValue)
            {
                var currentPortalUser = Repository.GetAllIncluding(x => x.PortalUser).FirstOrDefault(p => p.PortalUser.UserId == AbpSession.UserId.Value);
                input.PortalUserId = currentPortalUser?.Id ?? -1;
            }

            var postResult = await _dashboardRepository.Execute(input, "GetPortalUserDashboard");

            return postResult.FirstOrDefault();
        }

        public async Task<List<UsersAidsOutputDto>> GetPortalUserRequests(UsersAidsInputDto input)
        {
            var result = await _getPortalUserRequestsRepository.Execute(input, "GetPortalUserRequests");

            return result.ToList();
        }

        #endregion

        #region Assets Methods

        private async Task InsertPortalUserDutiesData(PortalUserDutiesDto userDutiesDto, long parentId)
        {
            userDutiesDto.PortalUserDataId = parentId;

            var userDuties = ObjectMapper.Map<PortalUserDuties>(userDutiesDto);

            _ = await _repoPortalUserDuties.InsertAsync(userDuties);
        }

        private async Task InsertPortalUserIncomesData(PortalUserIncomesDto userIncomesDto, long parentId)
        {
            userIncomesDto.PortalUserDataId = parentId;

            var userIncomes = ObjectMapper.Map<PortalUserIncomes>(userIncomesDto);

            _ = await _repoPortalUserIncomes.InsertAsync(userIncomes);
        }

        private async Task InsertPortalUserRelativesData(PortalUserRelativesDto userRelativesDto, long parentId)
        {
            userRelativesDto.PortalUserDataId = parentId;

            var userRelatives = ObjectMapper.Map<PortalUserRelatives>(userRelativesDto);

            _ = await _repoPortalUserRelatives.InsertAsync(userRelatives);
        }

        private async Task InsertPortalUserAttachmentsData(PortalUserAttachmentsDto userAttachmentsDto, long parentId)
        {
            userAttachmentsDto.PortalUserDataId = parentId;

            var userAttachments = ObjectMapper.Map<PortalUserAttachments>(userAttachmentsDto);

            _ = await _repoPortalUserAttachments.InsertAsync(userAttachments);
        }

        private async Task CRUD_PortalUserDuties(ICollection<PortalUserDutiesDto> userDutiesDtos, long parentId)
        {
            if (userDutiesDtos?.Count > 0)
            {
                foreach (var item in userDutiesDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var line = await _repoPortalUserDuties.GetAsync((long)item.Id);

                        item.PortalUserDataId = parentId;

                        ObjectMapper.Map(item, line);

                        _ = await _repoPortalUserDuties.UpdateAsync(line);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertPortalUserDutiesData(item, parentId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoPortalUserDuties.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        private async Task CRUD_PortalUserIncomes(ICollection<PortalUserIncomesDto> userIncomesDtos, long parentId)
        {
            if (userIncomesDtos?.Count > 0)
            {
                foreach (var item in userIncomesDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var line = await _repoPortalUserIncomes.GetAsync((long)item.Id);

                        item.PortalUserDataId = parentId;

                        ObjectMapper.Map(item, line);

                        _ = await _repoPortalUserIncomes.UpdateAsync(line);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertPortalUserIncomesData(item, parentId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoPortalUserIncomes.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        private async Task CRUD_PortalUserRelatives(ICollection<PortalUserRelativesDto> userRelativesDtos, long parentId)
        {
            if (userRelativesDtos?.Count > 0)
            {
                foreach (var item in userRelativesDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var line = await _repoPortalUserRelatives.GetAsync((long)item.Id);

                        item.PortalUserDataId = parentId;

                        ObjectMapper.Map(item, line);

                        _ = await _repoPortalUserRelatives.UpdateAsync(line);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertPortalUserRelativesData(item, parentId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoPortalUserRelatives.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        private async Task CRUD_PortalUserAttachments(ICollection<PortalUserAttachmentsDto> userAttachmentsDtos, long parentId)
        {
            if (userAttachmentsDtos?.Count > 0)
            {
                foreach (var item in userAttachmentsDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var line = await _repoPortalUserAttachments.GetAsync((long)item.Id);

                        item.PortalUserDataId = parentId;

                        ObjectMapper.Map(item, line);

                        _ = await _repoPortalUserAttachments.UpdateAsync(line);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertPortalUserAttachmentsData(item, parentId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoPortalUserAttachments.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        private async Task GetSourceAndCreatorNames(PortalUserDataDto portalUserDto)
        {
            portalUserDto.UserName = portalUserDto?.User?.UserName ?? string.Empty;
            portalUserDto.EmailAddress = portalUserDto?.User?.EmailAddress ?? string.Empty;
            // portalUserDto.Source = portalUserDto.SourceCreatorName = "تسجيل اليكتروني";

            int? tenantCreatorId = portalUserDto.PortalUser.TenantCreatorId;

            if (tenantCreatorId != null && tenantCreatorId != 0)
            {
                string creatorName = string.Empty;

                if (portalUserDto.CreatorUserId != null)
                {
                    //CurrentUnitOfWork.SetTenantId(tenantCreatorId);

                    var user = await _userManager.GetUserByIdAsync((long)portalUserDto.CreatorUserId);

                    creatorName = user?.Name;
                }

                // CurrentUnitOfWork.SetTenantId(null);

                //  var tnnt = await _tenantRepository.GetAsync((int)tenantCreatorId);

                //      portalUserDto.Source = tnnt?.Name ?? string.Empty;
                portalUserDto.SourceCreatorName = creatorName;
            }
        }

        private IQueryable<PortalUserData> FilterGetAll(IQueryable<PortalUserData> queryable, PortalUserUnifiedPagedDto input)
        {
            if (input.Params != null && !string.IsNullOrEmpty(input.Params.IdNumber))
                queryable = queryable.Where(q => q.PortalUser.IdNumber.Contains(input.Params.IdNumber) ||
                q.PortalUser.IdNumberWifeHusband1.Contains(input.Params.IdNumber) || q.PortalUser.IdNumberWife2.Contains(input.Params.IdNumber) ||
                q.PortalUser.IdNumberWife3.Contains(input.Params.IdNumber) || q.PortalUser.IdNumberWife4.Contains(input.Params.IdNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PhoneNumber))
                queryable = queryable.Where(q =>
                q.PhoneNumber.Contains(input.Params.PhoneNumber) || q.MobileNumber1.Contains(input.Params.PhoneNumber) ||
                q.MobileNumber2.Contains(input.Params.PhoneNumber)
                );

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.CaseNumber))
                queryable = queryable.Where(q => q.PortalUser.CaseNumber.Contains(input.Params.CaseNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Name))
                queryable = queryable.Where(q => q.PortalUser.Name.Contains(input.Params.Name));

            if (input.Params != null && input.Params.GenderLkpId != null)
                queryable = queryable.Where(q => q.GenderLkpId == input.Params.GenderLkpId);

            if (input.Params != null && input.Params.NationalityLkpId != null)
                queryable = queryable.Where(q => q.PortalUser.NationalityLkpId == input.Params.NationalityLkpId);

            if (input.Params != null && input.Params.CityLkpId != null)
                queryable = queryable.Where(q => q.CityLkpId == input.Params.CityLkpId);

            if (input.Params != null && input.Params.SourceId != null)
                queryable = queryable.Where(q => q.PortalUser.TenantCreatorId == input.Params.SourceId);

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

        #endregion
    }
}
