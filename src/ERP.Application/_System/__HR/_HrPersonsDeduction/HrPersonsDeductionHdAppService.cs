using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScCampains.Procs;
using ERP._System.__HR._HrPersonsAdditionHd.Proc;
using ERP._System.__HR._HrPersonsDeduction;
using ERP._System.__HR._HrPersonsDeduction.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPersonsDeductionHdDeduction
{
    [AbpAuthorize]
    public class HrPersonsDeductionHdAppService : AsyncCrudAppService<HrPersonsDeductionHd, HrPersonsDeductionHdDto, long, HrPersonsDeductionHdPagedDto, HrPersonsDeductionHdCreateDto, HrPersonsDeductionHdEditDto>, IHrPersonsDeductionHdAppService
    {
        private readonly IRepository<HrPersonsDeductionTr, long> _repoHrPersonsDeductionTr;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IHrPersonsAdditionPostRepository _hrPersonsAdditionPostRepository;

        public HrPersonsDeductionHdAppService(IRepository<HrPersonsDeductionHd, long> repository,
            IRepository<HrPersonsDeductionTr, long> repoHrPersonsDeductionTr,
            IGetCounterRepository getCounterRepository,
            IHrPersonsAdditionPostRepository hrPersonsAdditionPostRepository) : base(repository)
        {
            _hrPersonsAdditionPostRepository = hrPersonsAdditionPostRepository;
            _repoHrPersonsDeductionTr = repoHrPersonsDeductionTr;
            _repoProcCounter = getCounterRepository;

            CreatePermissionName = PermissionNames.Pages_HrPersonsDeductionHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_HrPersonsDeductionHd_Update;
            DeletePermissionName = PermissionNames.Pages_HrPersonsDeductionHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_HrPersonsDeductionHd;
        }

        protected override IQueryable<HrPersonsDeductionHd> CreateFilteredQuery(HrPersonsDeductionHdPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.Periods);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.DeductionNumber))
                iqueryable = iqueryable.Where(z => z.DeductionNumber.Contains(input.Params.DeductionNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.DeductionName))
                iqueryable = iqueryable.Where(z => z.DeductionName.Contains(input.Params.DeductionName));

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.PeriodId != null)
                iqueryable = iqueryable.Where(z => z.PeriodId == input.Params.PeriodId);

            return iqueryable;
        }

        public async override Task<HrPersonsDeductionHdDto> Create(HrPersonsDeductionHdCreateDto input)
        {
            CheckCreatePermission();

            input.DeductionNumber = await GetDeductionNumber();

            var hrPersonsDeduction = ObjectMapper.Map<HrPersonsDeductionHd>(input);

            _ = await Repository.InsertAsync(hrPersonsDeduction);

            if (input.PersonsDeductionDetails != null && input.PersonsDeductionDetails.Count > 0)
                foreach (var item in input.PersonsDeductionDetails)
                    await InsertHrPersonDeductionData(item, hrPersonsDeduction.Id);

            return new HrPersonsDeductionHdDto { };
        }

        public async override Task<HrPersonsDeductionHdDto> Update(HrPersonsDeductionHdEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            await CRUD_HrPersonDeduction(input.PersonsDeductionDetails, input.Id);

            return new HrPersonsDeductionHdDto { };
        }

        public async Task<List<HrPersonsDeductionTrDto>> GetAllDeductionDetails(EntityDto<long> input)
        {
            var listData = await _repoHrPersonsDeductionTr.GetAllIncluding(x => x.FndDeductionTypeLkp, x => x.HrPersons)
                               .Where(d => d.HrPersonDeductionHdId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<HrPersonsDeductionTrDto>>(listData);
        }

        public async Task<HrPersonsDeductionHdDto> GetDetailAsync(EntityDto<long> input)
            => ObjectMapper.Map<HrPersonsDeductionHdDto>(await Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.Periods)
                           .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

        public async Task<PostOutput> PostHrPersonsDeduction(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _hrPersonsAdditionPostRepository.Execute(postDto, "HrPersonsDeductionPost");

            return result.FirstOrDefault();
        }

        #region Assets Methods

        private async Task InsertHrPersonDeductionData(HrPersonsDeductionTrDto deductionTrDto, long masterId)
        {
            deductionTrDto.HrPersonDeductionHdId = masterId;

            var deductionTr = ObjectMapper.Map<HrPersonsDeductionTr>(deductionTrDto);

            _ = await _repoHrPersonsDeductionTr.InsertAsync(deductionTr);
        }

        private async Task CRUD_HrPersonDeduction(ICollection<HrPersonsDeductionTrDto> deductionTrDtos, long masterId)
        {
            if (deductionTrDtos != null && deductionTrDtos.Count > 0)
            {
                foreach (var item in deductionTrDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var deductionTr = await _repoHrPersonsDeductionTr.GetAsync((long)item.Id);

                        item.HrPersonDeductionHdId = masterId;

                        ObjectMapper.Map(item, deductionTr);

                        _ = await _repoHrPersonsDeductionTr.UpdateAsync(deductionTr);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertHrPersonDeductionData(item, masterId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoHrPersonsDeductionTr.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        private async Task<string> GetDeductionNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "HrPersonsDeductionHd", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }

        #endregion


    }
}
