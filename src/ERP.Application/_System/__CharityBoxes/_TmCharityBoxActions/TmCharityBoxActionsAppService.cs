using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__CharityBoxes._TmCharityBoxActions._TmCharityBoxActionDetails;
using ERP._System.__CharityBoxes._TmCharityBoxActions.Dto;
using ERP._System.__CharityBoxes._TmCharityBoxReceive;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxActions
{
    [AbpAuthorize]
    public class TmCharityBoxActionsAppService : AsyncCrudAppService<TmCharityBoxActions, TmCharityBoxActionsDto, long, PagedTmCharityBoxActionsResultRequestDto, CreateTmCharityBoxActionsDto, TmCharityBoxActionsEditDto>,
        ITmCharityBoxActionsAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly ITmCharityBoxReceiveRepository _repoPost;
        private readonly ITmCharityBoxActionDetailsMananger _tmCharityBoxActionDetailsMananger;
        private readonly IRepository<TmCharityBoxActionDetails, long> _repoTmCharityBoxActionsDetail;

        public TmCharityBoxActionsAppService(IGetCounterRepository getCounterRepository,
            ITmCharityBoxReceiveRepository tmCharityBoxReceiveRepository,
            ITmCharityBoxActionDetailsMananger tmCharityBoxActionDetailsMananger,
            IRepository<TmCharityBoxActions, long> repository,
            IRepository<TmCharityBoxActionDetails, long> repoTmCharityBoxActionsDetail) : base(repository)
        {
            _repoTmCharityBoxActionsDetail = repoTmCharityBoxActionsDetail;
            _tmCharityBoxActionDetailsMananger = tmCharityBoxActionDetailsMananger;
            _repoProcCounter = getCounterRepository;
            _repoPost = tmCharityBoxReceiveRepository;

            CreatePermissionName = PermissionNames.Pages_TmCharityBoxActions_Insert;
            UpdatePermissionName = PermissionNames.Pages_TmCharityBoxActions_Update;
            DeletePermissionName = PermissionNames.Pages_TmCharityBoxActions_Delete;
            GetAllPermissionName = PermissionNames.Pages_TmCharityBoxActions;
        }

        protected override IQueryable<TmCharityBoxActions> CreateFilteredQuery(PagedTmCharityBoxActionsResultRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.TmSupervisors);

            if (input.Params != null && input.Params.StatusLkpId.HasValue && input.Params.StatusLkpId.Value > 0)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.TmSupervisorId.HasValue && input.Params.TmSupervisorId.Value > 0)
                iqueryable = iqueryable.Where(z => z.TmSupervisorId == input.Params.TmSupervisorId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ActionsNumber))
                iqueryable = iqueryable.Where(z => z.ActionsNumber.Contains(input.Params.ActionsNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FromDate) && !string.IsNullOrEmpty(input.Params.ToDate))
            {
                DateTime dtFrom = (DateTime)DateTimeController.ConvertToDateTime(input.Params.FromDate);
                DateTime dtTo = (DateTime)DateTimeController.ConvertToDateTime(input.Params.ToDate);

                iqueryable = iqueryable.Where(q => dtFrom <= q.ActionsDate && dtTo >= q.ActionsDate);
            }

            return iqueryable;
        }

        public override async Task<TmCharityBoxActionsDto> Create(CreateTmCharityBoxActionsDto input)
        {
            CheckCreatePermission();

            if (input.BoxActionsDetails.Count > 0) Validator(input.BoxActionsDetails);
            else throw new UserFriendlyException("يجب ملئ علي الاقل واحد من التفاصيل");

            input.ActionsNumber = await GetCharityBoxNumber();

            var currentTmCharityBoxActions = await base.Create(input);

            if (input.BoxActionsDetails.Count > 0)
            {
                var newStatusDetailLkpId = Convert.ToInt64(FndEnum.FndLkps.New_TmCharityBoxActionsDetailStatues);

                foreach (var item in input.BoxActionsDetails)
                {
                    item.StatusLkpId = newStatusDetailLkpId;
                    item.CharityBoxActionId = currentTmCharityBoxActions.Id;

                    _ = await _repoTmCharityBoxActionsDetail.InsertAsync(ObjectMapper.Map<TmCharityBoxActionDetails>(item));
                }
            }

            return new TmCharityBoxActionsDto { };
        }

        public override async Task<TmCharityBoxActionsDto> Update(TmCharityBoxActionsEditDto input)
        {
            CheckUpdatePermission();

            if (input.BoxActionsDetails.Count > 0) Validator(input.BoxActionsDetails);
            else throw new UserFriendlyException("يجب ملئ علي الاقل واحده من التفاصيل");

            _ = await base.Update(input);

            if (input.BoxActionsDetails.Count > 0)
            {
                var newStatusDetailLkpId = Convert.ToInt64(FndEnum.FndLkps.New_TmCharityBoxActionsDetailStatues);

                foreach (var item in input.BoxActionsDetails)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var TmCharityBoxActionsDetail = await _repoTmCharityBoxActionsDetail.GetAsync((long)item.Id);

                        item.CharityBoxActionId = input.Id;

                        ObjectMapper.Map(item, TmCharityBoxActionsDetail);

                        _ = await _repoTmCharityBoxActionsDetail.UpdateAsync(TmCharityBoxActionsDetail);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.StatusLkpId = newStatusDetailLkpId;
                        item.CharityBoxActionId = input.Id;

                        _ = await _repoTmCharityBoxActionsDetail.InsertAsync(ObjectMapper.Map<TmCharityBoxActionDetails>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoTmCharityBoxActionsDetail.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new TmCharityBoxActionsDto { };
        }

        public async Task<List<TmCharityBoxActionDetailsDto>> GetAllDetails(long id)
        {
            var output = new List<TmCharityBoxActionDetailsDto>();

            var listData = await _repoTmCharityBoxActionsDetail.GetAllIncluding(z =>
                       z.FndLookupValuesStatusLkp, x => x.FndLookupValuesActionLkp,
                        x => x.NewTmCharityBoxes, x => x.OldTmCharityBoxes,
                        z => z.TmLocationSub, z => z.TmLocationSub.TmLocation,
                        z => z.TmLocationSub.TmLocation.Region,
                        z => z.TmLocationSub.TmLocation.Region.FndLookupValues)
                .Where(d => d.CharityBoxActionId == id).ToListAsync();

            foreach (var item in listData)
            {
                var current = new TmCharityBoxActionDetailsDto
                {
                    Id = item.Id,
                    Notes = item.Notes,
                    ActionLkpId = item.ActionLkpId,
                    NewCharityBoxId = item.NewCharityBoxId,
                    OldCharityBoxid = item.OldCharityBoxid,
                    CharityBoxActionId = item.CharityBoxActionId,
                    TmLocationSubId = item.TmLocationSubId,
                    ActionLkp = item.FndLookupValuesActionLkp.NameAr,
                    OldCharityBox = item.OldTmCharityBoxes == null ? string.Empty : item.OldTmCharityBoxes.CharityBoxName,
                    NewCharityBox = item.NewTmCharityBoxes == null ? string.Empty : item.NewTmCharityBoxes.CharityBoxName,
                    TmLocationSubTxt =
                                $"{item.TmLocationSub.TmLocation.Region.FndLookupValues.NameAr}-" +
                                $"{item.TmLocationSub.TmLocation.Region.RegionName}-" +
                                $"{item.TmLocationSub.TmLocation.LocationName}-" +
                                $"{item.TmLocationSub.TmLocationSubName}",
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<TmCharityBoxActionsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.TmSupervisors)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<TmCharityBoxActionsDto>(current);
        }

        private void Validator(ICollection<TmCharityBoxActionDetailsDto> BoxActionsDetails)
        {
            var checkSameLocation = BoxActionsDetails.GroupBy(z => z.TmLocationSubId).Any(z => z.Count() > 1);
            var checkNewSameBox = BoxActionsDetails.GroupBy(z => z.NewCharityBoxId).Any(z => z.Count() > 1);

            if (checkSameLocation) throw new UserFriendlyException("الموقع متكرر مرتين");
            if (checkNewSameBox) throw new UserFriendlyException("الحصالة الجديدة متكرر مرتين");

            foreach (var item in BoxActionsDetails)
            {
                if (item.ActionLkpId == Convert.ToInt64(FndEnum.FndLkps.New_TmCharityBoxActionDetailsAction) &&
                    item.NewCharityBoxId == null)
                    throw new UserFriendlyException("الحصالة الجديدة مطلوبة");
                else if (
                    item.ActionLkpId == Convert.ToInt64(FndEnum.FndLkps.Replace_TmCharityBoxActionDetailsAction) &&
                    (item.NewCharityBoxId == null || item.OldCharityBoxid == null))
                    throw new UserFriendlyException("الحصالة الجديدة مطلوبة او القديمة");
                else if (
                    (item.ActionLkpId == Convert.ToInt64(FndEnum.FndLkps.Missed_TmCharityBoxActionDetailsAction) ||
                        item.ActionLkpId == Convert.ToInt64(FndEnum.FndLkps.Broken_TmCharityBoxActionDetailsAction) ||
                        item.ActionLkpId == Convert.ToInt64(FndEnum.FndLkps.Gain_TmCharityBoxActionDetailsAction)) &&
                        item.OldCharityBoxid == null)
                    throw new UserFriendlyException(" الحصالة القديمة مطلوبة ");
            }
        }

        public async Task<PostOutput> PostTmCharityBoxActions(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _repoPost.Execute(postDto, "TmCharityBoxActionsPost");

            return result.FirstOrDefault();
        }

        public async Task<Select2PagedResult> GetCharityBoxActionDetailsForCollectSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
          => await _tmCharityBoxActionDetailsMananger.GetCharityBoxActionDetailsForCollectSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetCharityBoxActionDetailsForDamagedSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
          => await _tmCharityBoxActionDetailsMananger.GetCharityBoxActionDetailsForDamagedSelect2(searchTerm, pageSize, pageNumber, lang);

        private async Task<string> GetCharityBoxNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "TmCharityBoxActions", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
