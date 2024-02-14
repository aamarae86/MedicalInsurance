using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__CharityBoxes._TmCharityBoxReceive;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs._TmDamagedCharityBoxDetails;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs.Dto;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs.ProcDto;
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

namespace ERP._System.__CharityBoxes._TmDamagedCharityBoxs
{
    [AbpAuthorize]
    public class TmDamagedCharityBoxsAppService : AsyncCrudAppService<TmDamagedCharityBoxs, TmDamagedCharityBoxsDto, long, PagedTmDamagedCharityBoxsResultRequestDto, TmDamagedCharityBoxsCreateDto, TmDamagedCharityBoxsEditDto>,
        ITmDamagedCharityBoxsAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IGetTmDamagedCharityBoxesScreenDataRepository _GetTmDamagedCharityBoxesScreenDataRepository;
        private readonly ITmCharityBoxReceiveRepository _repoPost;
        private readonly IRepository<TmDamagedCharityBoxDetails, long> _repoTmDamagedCharityBoxDetails;

        public TmDamagedCharityBoxsAppService(IRepository<TmDamagedCharityBoxs, long> repository,
            IRepository<TmDamagedCharityBoxDetails, long> repoTmDamagedCharityBoxDetails,
            IGetCounterRepository getCounterRepository,
            IGetTmDamagedCharityBoxesScreenDataRepository GetTmDamagedCharityBoxesScreenDataRepository,
            ITmCharityBoxReceiveRepository tmCharityBoxReceiveRepository) : base(repository)
        {
            _repoProcCounter = getCounterRepository;
            _GetTmDamagedCharityBoxesScreenDataRepository = GetTmDamagedCharityBoxesScreenDataRepository;
            _repoTmDamagedCharityBoxDetails = repoTmDamagedCharityBoxDetails;
            _repoPost = tmCharityBoxReceiveRepository;

            CreatePermissionName = PermissionNames.Pages_TmDamagedCharityBoxs_Insert;
            UpdatePermissionName = PermissionNames.Pages_TmDamagedCharityBoxs_Update;
            DeletePermissionName = PermissionNames.Pages_TmDamagedCharityBoxs_Delete;
            GetAllPermissionName = PermissionNames.Pages_TmDamagedCharityBoxs;
        }

        protected override IQueryable<TmDamagedCharityBoxs> CreateFilteredQuery(PagedTmDamagedCharityBoxsResultRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLookup, x => x.TmSupervisors);

            if (input.Params != null && input.Params.StatusLkpId.HasValue && input.Params.StatusLkpId.Value > 0)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.TmSupervisorId.HasValue && input.Params.TmSupervisorId.Value > 0)
                iqueryable = iqueryable.Where(z => z.TmSupervisorId == input.Params.TmSupervisorId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.DamagedCharityBoxsNumber))
                iqueryable = iqueryable.Where(z => z.DamagedCharityBoxsNumber.Contains(input.Params.DamagedCharityBoxsNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FromDate))
            {
                DateTime dtFrom = (DateTime)DateTimeController.ConvertToDateTime(input.Params.FromDate);

                iqueryable = iqueryable.Where(q => dtFrom <= q.DamagedCharityBoxsDate);
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ToDate))
            {
                DateTime dtTo = (DateTime)DateTimeController.ConvertToDateTime(input.Params.ToDate);

                iqueryable = iqueryable.Where(q => dtTo >= q.DamagedCharityBoxsDate);
            }

            return iqueryable;
        }

        public override async Task<TmDamagedCharityBoxsDto> Create(TmDamagedCharityBoxsCreateDto input)
        {
            CheckCreatePermission();

            if (input.DamagedCharityBoxDetails == null || input.DamagedCharityBoxDetails.Count == 0)
                throw new UserFriendlyException("يجب اضافة حصالة واحدة علي الأقل!!!!!!!!!!!!");

            input.DamagedCharityBoxsNumber = await GetDamagedBoxNumber();

            var currentTmDamagedCharityBoxs = await base.Create(input);

            if (input.DamagedCharityBoxDetails.Count > 0)
            {
                foreach (var item in input.DamagedCharityBoxDetails)
                {
                    item.TmDamagedCharityBoxId = currentTmDamagedCharityBoxs.Id;

                    _ = await _repoTmDamagedCharityBoxDetails.InsertAsync(ObjectMapper.Map<TmDamagedCharityBoxDetails>(item));
                }
            }

            return new TmDamagedCharityBoxsDto { };
        }

        public override async Task<TmDamagedCharityBoxsDto> Update(TmDamagedCharityBoxsEditDto input)
        {
            CheckUpdatePermission();

            if (input.DamagedCharityBoxDetails == null || input.DamagedCharityBoxDetails.Count == 0)
                throw new UserFriendlyException("يجب اضافة حصالة واحدة علي الأقل!!!!!!!!!!!!");

            _ = await base.Update(input);

            if (input.DamagedCharityBoxDetails.Count > 0)
            {
                foreach (var item in input.DamagedCharityBoxDetails)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var damagedCharityBoxDetails = await _repoTmDamagedCharityBoxDetails.GetAsync((long)item.Id);

                        item.TmDamagedCharityBoxId = input.Id;

                        ObjectMapper.Map(item, damagedCharityBoxDetails);

                        _ = await _repoTmDamagedCharityBoxDetails.UpdateAsync(damagedCharityBoxDetails);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.TmDamagedCharityBoxId = input.Id;

                        _ = await _repoTmDamagedCharityBoxDetails.InsertAsync(ObjectMapper.Map<TmDamagedCharityBoxDetails>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoTmDamagedCharityBoxDetails.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new TmDamagedCharityBoxsDto { };
        }

        public async Task<List<TmDamagedCharityBoxDetailsDto>> GetAllDetails(long id)
        {
            var output = new List<TmDamagedCharityBoxDetailsDto>();

            var listData = await _repoTmDamagedCharityBoxDetails.GetAllIncluding(z => z.TmCharityBoxActionDetails.OldTmCharityBoxes)
                .Where(d => d.TmDamagedCharityBoxId == id).ToListAsync();

            foreach (var item in listData)
            {
                var current = new TmDamagedCharityBoxDetailsDto
                {
                    Id = item.Id,
                    CharityBoxActionDetailId = item.CharityBoxActionDetailId,
                    charityBoxName = item.TmCharityBoxActionDetails.OldTmCharityBoxes == null ? string.Empty : item.TmCharityBoxActionDetails.OldTmCharityBoxes.CharityBoxName,
                    barCode = item.TmCharityBoxActionDetails.OldTmCharityBoxes == null ? string.Empty : item.TmCharityBoxActionDetails.OldTmCharityBoxes.CharityBoxBarcode,
                    DamageReason = item.DamageReason == null ? string.Empty : item.DamageReason,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<TmDamagedCharityBoxsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.FndStatusLookup, x => x.TmSupervisors)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<TmDamagedCharityBoxsDto>(current);
        }

        public async Task<PostOutput> PostTmDamagedCharityBoxs(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _repoPost.Execute(postDto, "TmDamagedCharityBoxPost");

            return result.FirstOrDefault();
        }

        public async Task<List<TmDamagedCharityBoxesScreenDataOutput>> GetTmDamagedCharityBoxesScreenData(IdLangInputDto input)
        {
            var result = await _GetTmDamagedCharityBoxesScreenDataRepository.Execute(input, "GetTmDamagedCharityBoxesScreenData");

            return result.ToList();
        }

        private async Task<string> GetDamagedBoxNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "TmDamagedCharityBoxs", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
