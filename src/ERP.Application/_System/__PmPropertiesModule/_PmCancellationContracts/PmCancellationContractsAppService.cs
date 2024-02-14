using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__PmPropertiesModule._PmCancellationContracts.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._GlCodeComDetails;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmCancellationContracts
{
    [AbpAuthorize]
    public class PmCancellationContractsAppService : EditBaseAsyncCrudAppService<PmCancellationContracts, PmCancellationContractsDto, long, PagedPmCancellationContractsResultRequestDto, CreatePmCancellationContractsDto, PmCancellationContractsEditDto>,
        IPmCancellationContractsAppService
    {
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IEntityCounterManager _entityCounterManager;

        public PmCancellationContractsAppService(IRepository<PmCancellationContracts, long> repository,
            IGlCodeComDetailsManager glCodeComDetailsManager
            , IEntityCounterManager entityCounterManager
            ) : base(repository)
        {
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _entityCounterManager = entityCounterManager;
            CreatePermissionName = PermissionNames.Pages_PmCancellationContracts_Insert;
            UpdatePermissionName = PermissionNames.Pages_PmCancellationContracts_Update;
            DeletePermissionName = PermissionNames.Pages_PmCancellationContracts_Delete;
            GetAllPermissionName = PermissionNames.Pages_PmCancellationContracts;
        }

        public async override Task<PagedResultDto<PmCancellationContractsDto>> GetAll(PagedPmCancellationContractsResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.GlCodeComDetails, x => x.FndLookupValues, x => x.PmContract, x => x.PmContract.PmTenants);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.CancellationNumber))
                queryable = queryable.Where(q => q.CancellationNumber.Contains(input.Params.CancellationNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.CancellationDate))
                queryable = queryable.Where(q => q.CancellationDate == DateTimeController.ConvertToDateTime(input.Params.CancellationDate));

            if (input.Params != null && input.Params.PmContractId != null)
                queryable = queryable.Where(q => q.PmContractId == input.Params.PmContractId);

            if (input.Params != null && input.Params.PmTenantName != null)
                queryable = queryable.Where(q => q.PmContract.PmTenants.Id == input.Params.PmTenantName);

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            queryable = queryable.OrderByDescending(x => x.CreationTime);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<PmCancellationContractsDto>());
            var counter = 0;

            foreach (var item in data)
            {
                (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetails, _app.Reqlanguage);
                data2[counter].codeComUtilityIds = ids;
                data2[counter].codeComUtilityTexts = texts;
                ++counter;
            }

            var PagedResultDto = new PagedResultDto<PmCancellationContractsDto>()
            {
                Items = data2 as IReadOnlyList<PmCancellationContractsDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        //public async override Task<PmCancellationContractsDto> Create(CreatePmCancellationContractsDto input)
        //{
        //    CheckCreatePermission();

        //    var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

        //    input.CancellationNumber = await GetCancellationNumber();

        //    input.AccountId = currentComCodeId.Value;

        //    return await base.Create(input);
        //}

        public async Task<PmCancellationContractsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.GlCodeComDetails,
                  x => x.FndLookupValues, x => x.PmContract,
                  x => x.PmContract.PmTenants).Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var ReturnObj = ObjectMapper.Map<PmCancellationContractsDto>(current);

            (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(current.GlCodeComDetails, _app.Reqlanguage);
            ReturnObj.codeComUtilityIds = ids;
            ReturnObj.codeComUtilityTexts = texts;

            return ReturnObj;
        }

        //public async override Task<PmCancellationContractsDto> Update(PmCancellationContractsEditDto input)
        //{
        //    CheckUpdatePermission();

        //    var current = await Repository.GetAsync((long)input.Id);
        //    var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

        //    current.UpdateData((long)currentComCodeId, input.PmContractId, input.FinePeriodPerDays, input.FineAmount, input.CancellationDate, input.Notes);

        //    _ = await Repository.UpdateAsync(current);

        //    return new PmCancellationContractsDto();
        //}

        internal override async Task EntityCreatePreExecute(CreatePmCancellationContractsDto input)
        {
            input.CancellationNumber = await _entityCounterManager.GetEntityNumber("PmCancellationContracts", (int)AbpSession.TenantId);

            var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

            input.AccountId = currentComCodeId.Value;
        }

        internal override async Task EntityCreatePostExecute(CreatePmCancellationContractsDto input, long EntityId)
        { }

        internal override async Task EntityUpdatePreExecute(PmCancellationContractsEditDto input)
        {
            var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);
            input.AccountId = currentComCodeId;
        }

        internal override async Task EntityDeletePreExecute(EntityDto<long> input)
        { }
    }
}
