using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScCampains.Dto;
using ERP._System.__AidModule._ScCampains.Outputs;
using ERP._System.__AidModule._ScCampains.Procs;
using ERP._System.__AidModule._ScCampainsDetail;
using ERP._System.__AidModule._ScCampainsDetail.Dto;
using ERP._System.__AidModule._ScCampainsDetail.Procs;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues.Dto;
using ERP._System._Portal;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using ERP.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScCampains
{
    [AbpAuthorize]
    public class ScCampainsAppService : AsyncCrudAppService<ScCampains, ScCampainsDto, long, PagedScCampainsResultRequestDto, CreateScCampainsDto, ScCampainsEditDto>,
        IScCampainsAppService
    {
        private readonly IRepository<ScCampainsDetail, long> _repoScCampainsDetail;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IPortalUserManager _portalUserManager;
        private readonly IPortalUserRelativesManager _portalUserRelativesManager;
        private readonly IScCampainsDetailPostRepository _scCampainsDetailPostRepository;
        private readonly IScCampainsDetailDeliverRepository _scCampainsDetailDeliverRepository;
        private readonly IScCampainsPostRepository _scCampainsPostRepository;
        private readonly IGetScCampainssScreenDataRepository _getScCampainssScreenDataRepository;

        public ScCampainsAppService(IRepository<ScCampains, long> repository,
            IRepository<ScCampainsDetail, long> repoScCampainsDetail,
            IGetCounterRepository repoProcCounter,
            IPortalUserManager portalUserManager,
            IScCampainsPostRepository scCampainsPostRepository,
            IPortalUserRelativesManager portalUserRelativesManager,
            IScCampainsDetailDeliverRepository scCampainsDetailDeliverRepository,
            IGetScCampainssScreenDataRepository getScCampainssScreenDataRepository,
            IScCampainsDetailPostRepository scCampainsDetailPostRepository) : base(repository)
        {
            _repoProcCounter = repoProcCounter;
            _repoScCampainsDetail = repoScCampainsDetail;
            _portalUserManager = portalUserManager;
            _scCampainsPostRepository = scCampainsPostRepository;
            _portalUserRelativesManager = portalUserRelativesManager;
            _scCampainsDetailPostRepository = scCampainsDetailPostRepository;
            _scCampainsDetailDeliverRepository = scCampainsDetailDeliverRepository;
            _getScCampainssScreenDataRepository = getScCampainssScreenDataRepository;

            CreatePermissionName = PermissionNames.Pages_ScCampains_Insert;
            UpdatePermissionName = PermissionNames.Pages_ScCampains_Update;
            DeletePermissionName = PermissionNames.Pages_ScCampains_Delete;
            GetAllPermissionName = PermissionNames.Pages_ScCampains;
        }

        public async override Task<PagedResultDto<ScCampainsDto>> GetAll(PagedScCampainsResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.FndLookupValues);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.CampainName))
                queryable = queryable.Where(q => q.CampainName.Contains(input.Params.CampainName));

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);

            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ScCampainsDto>());

            var PagedResultDto = new PagedResultDto<ScCampainsDto>()
            {
                Items = data2 as IReadOnlyList<ScCampainsDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<PagedResultDto<MasterDetailDto>> GetAllForDetials(PagedMasterDetailResultRequestDto input)
        {
            var dtFrom = !string.IsNullOrEmpty(input.Params.FromScCampainDate) ? DateTimeController.ConvertToDateTime(input.Params.FromScCampainDate) : DateTime.MinValue;
            var dtTo = !string.IsNullOrEmpty(input.Params.FromScCampainDate) ? DateTimeController.ConvertToDateTime(input.Params.ToScCampainDate) : DateTime.MinValue;

            var queryable = _repoScCampainsDetail.GetAllIncluding(w => w.ScCampains, w => w.PortalFndUsers, w => w.ScCampainsAid, w => w.FndLookupValues).Where(z => z.StatusLkpId != 145 &&
                            (input.Params == null || input.Params.portalFndUsersId1 == null || input.Params.portalFndUsersId1 == 0 || z.PortalFndUsersId == input.Params.portalFndUsersId1) &&
                            (input.Params == null || input.Params.portalFndUsersId2 == null || input.Params.portalFndUsersId1 == 0 || z.PortalFndUsersId == input.Params.portalFndUsersId2) &&
                            (input.Params == null || input.Params.CampainName == null || z.CampainId == Convert.ToInt64(input.Params.CampainName)) &&
                            (input.Params == null || input.Params.campainAidId == null || input.Params.campainAidId == 0 || z.CampainAidId == input.Params.campainAidId) &&
                            (input.Params == null || input.Params.FromScCampainDate == null || input.Params.ToScCampainDate == null || (z.ScCampains.ScCampainDate >= dtFrom && z.ScCampains.ScCampainDate <= dtTo)) &&
                            (input.Params == null || input.Params.statusLkpId == null || input.Params.statusLkpId == 0 || z.StatusLkpId == input.Params.statusLkpId));

            var count = await queryable.CountAsync();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<MasterDetailDto>());

            var PagedResultDto = new PagedResultDto<MasterDetailDto>()
            {
                Items = data2 as IReadOnlyList<MasterDetailDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public override async Task<ScCampainsDto> Create(CreateScCampainsDto input)
        {
            CheckCreatePermission();

            input.CampainNumber = await GetScCampaignNumber();

            var currentScCampains = await base.Create(input);

            if (input.ScCampainDetailsList.Count > 0)
            {
                var newStatusDetailLkpId = Convert.ToInt64(FndEnum.FndLkps.New_ScCampainsDetailStatues);

                foreach (var item in input.ScCampainDetailsList)
                {
                    var currentScCampainsDetail = ObjectMapper.Map<ScCampainsDetail>(item);

                    currentScCampainsDetail.SetCampainId(currentScCampains.Id);
                    currentScCampainsDetail.SetStatusLkpId(newStatusDetailLkpId);

                    _ = await _repoScCampainsDetail.InsertAsync(currentScCampainsDetail);
                }
            }

            return new ScCampainsDto { };
        }

        public override async Task<ScCampainsDto> Update(ScCampainsEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            if (input.ScCampainDetailsList.Count > 0)
            {
                var newStatusDetailLkpId = Convert.ToInt64(FndEnum.FndLkps.New_ScCampainsDetailStatues);

                foreach (var item in input.ScCampainDetailsList)
                {
                    if (item.id != null && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var scCampainsDetail = await _repoScCampainsDetail.GetAsync((long)item.id);

                        item.CreatorUserId = scCampainsDetail.CreatorUserId;

                        ObjectMapper.Map(item, scCampainsDetail);

                        _ = await _repoScCampainsDetail.UpdateAsync(scCampainsDetail);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        var currentScCampainsDetail = ObjectMapper.Map<ScCampainsDetail>(item);

                        currentScCampainsDetail.SetCampainId(input.Id);
                        currentScCampainsDetail.SetStatusLkpId(newStatusDetailLkpId);

                        _ = await _repoScCampainsDetail.InsertAsync(currentScCampainsDetail);
                    }
                    else if (item.id != null && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoScCampainsDetail.DeleteAsync((long)item.id);
                    }
                }
            }

            return new ScCampainsDto { };
        }

        public async Task<ScCampainsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.FndLookupValues)
                           .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<ScCampainsDto>(current);
        }

        public async Task<List<ScCampainsDetailDto>> GetAllDetails(long id)
        {
            var output = new List<ScCampainsDetailDto>();

            var listData = await _repoScCampainsDetail
                .GetAllIncluding(z => z.FndLookupValues, x => x.PortalFndUsers, x => x.ScCampainsAid)
                .Where(d => d.CampainId == id).ToListAsync();

            foreach (var item in listData)
            {
                var fndUserDto = ObjectMapper.Map(item.PortalFndUsers, new PortalUserDto());

                var countRelatives = await _portalUserRelativesManager.GetUserRelativesCount(item.PortalFndUsersId);

                var current = new ScCampainsDetailDto
                {
                    id = item.Id,
                    campainAid = item.ScCampainsAid.AidName,
                    campainAidId = item.CampainAidId,
                    fndUsers = $"{item.PortalFndUsers.Name}",
                    fndUserEncId = $"{fndUserDto.EncId}",
                    fndUsersIdNumber = item.PortalFndUsers.IdNumber,
                    portalFndUsersId = item.PortalFndUsersId,
                    statusLkp = item.FndLookupValues.NameAr,
                    statusLkpId = item.StatusLkpId,
                    userRelativeCount = countRelatives.ToString(),
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            if (output.Count > 0)
            {
                long statusPostedId = Convert.ToInt64(FndEnum.FndLkps.Posted_ScCampainsDetailStatues);
                long statusRecievedId = Convert.ToInt64(FndEnum.FndLkps.Received_ScCampainsDetailStatues);

                output[0].postedCount = output.Where(z => z.statusLkpId == statusPostedId).Count();
                output[0].recievedCount = output.Where(z => z.statusLkpId == statusRecievedId).Count();
            }

            return output;
        }

        public async override Task Delete(EntityDto<long> input)
        {
            var ids = await _repoScCampainsDetail.GetAll().Where(z => z.CampainId == input.Id).Select(z => z.Id).ToListAsync();

            foreach (var id in ids) await _repoScCampainsDetail.DeleteAsync(id);

            await Repository.DeleteAsync(input.Id);
        }

        public async Task<Select2PagedResult> GetCampainsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await Repository.GetAll().Where(z =>
                  string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.CampainName.Contains(searchTerm) : z.CampainName.Contains(searchTerm)))
                 .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.CampainName : z.CampainName }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetPortalUsersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var select2pagedResult = await _portalUserManager.GetPortalUsersSelect2(searchTerm, pageSize, pageNumber, lang);
            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetPortalUsersNammesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var select2pagedResult = await _portalUserManager.GetPortalUsersNamesSelect2(searchTerm, pageSize, pageNumber, lang);
            return select2pagedResult;
        }

        public async Task<PostOutput> PostScCampainsDetail(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scCampainsDetailPostRepository.Execute(postDto, "ScCampainsDetailPost");

            return result.FirstOrDefault();
        }

        public async Task<PostOutput> PostScCampains(PostDto postDto)
        {
            var details = await _repoScCampainsDetail.GetAll().Where(z => z.Id == postDto.Id).ToListAsync();

            long newDetailStatus = Convert.ToInt64(FndEnum.FndLkps.New_ScCampainsDetailStatues);

            bool newStatusExist = details.Any(z => z.StatusLkpId == newDetailStatus);

            if (newStatusExist) return new PostOutput { FinalStatues = "F", Reason = "لا يمكن اغلاق الحملة" };

            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scCampainsPostRepository.Execute(postDto, "ScCampainsPost");

            return result.FirstOrDefault();
        }

        public async Task<PostOutput> scCampainsDetailDeliver(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scCampainsDetailDeliverRepository.Execute(postDto, "ScCampainsDetailDeliver");

            return result.FirstOrDefault();
        }

        public async Task<List<ScCampainssScreenDataOutput>> GetScCampainssScreenData(IdLangInputDto idLangInputDto)
        {
            var result = await _getScCampainssScreenDataRepository.Execute(idLangInputDto, "GetScCampainssScreenData");

            return result.ToList();
        }

        private async Task<string> GetScCampaignNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "ScCampains", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
