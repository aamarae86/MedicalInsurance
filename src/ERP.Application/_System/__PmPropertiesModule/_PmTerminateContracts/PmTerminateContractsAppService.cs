using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Json;
using ERP._System.__PmPropertiesModule._PmTerminateContracts.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmTerminateContracts
{
    public class PmTerminateContractsAppService : AsyncCrudAppService<PmTerminateContracts, PmTerminateContractsDto, long, PagedPmTerminateContractsResultRequestDto, CreatePmTerminateContractsDto, PmTerminateContractsEditDto>,
        IPmTerminateContractsAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;

        public PmTerminateContractsAppService(IGetCounterRepository repoProcCounter,
                  IRepository<PmTerminateContracts, long> repository) : base(repository)
        {
            _repoProcCounter = repoProcCounter;

            CreatePermissionName = PermissionNames.Pages_PmTerminateContracts_Insert;
            UpdatePermissionName = PermissionNames.Pages_PmTerminateContracts_Update;
            DeletePermissionName = PermissionNames.Pages_PmTerminateContracts_Delete;
            GetAllPermissionName = PermissionNames.Pages_PmTerminateContracts;
        }

        public async override Task<PmTerminateContractsDto> Create(CreatePmTerminateContractsDto input)
        {
            CheckCreatePermission();

            input.TerminationNumber = await GetPmTerminateContractNumber();

            return await base.Create(input);
        }

        public async override Task<PagedResultDto<PmTerminateContractsDto>> GetAll(PagedPmTerminateContractsResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.FndLookupValuesPmTerminateContractsStatusLkp, z => z.PmContract, z => z.PmContract.PmTenants);

            if (input.Params != null && input.Params.PmContractId != null)
                queryable = queryable.Where(q => q.PmContractId == input.Params.PmContractId);

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.PmTenantId != null)
                queryable = queryable.Where(q => q.PmContract.PmTenants.Id == input.Params.PmTenantId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.TerminationDate))
                queryable = queryable.Where(q => q.TerminationDate == DateTimeController.ConvertToDateTime(input.Params.TerminationDate));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.TerminationNumber))
                queryable = queryable.Where(q => q.TerminationNumber.Contains(input.Params.TerminationNumber));

            var count = await queryable.CountAsync();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            queryable = queryable.OrderByDescending(x => x.CreationTime);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<PmTerminateContractsDto>());

            var PagedResultDto = new PagedResultDto<PmTerminateContractsDto>()
            {
                Items = data2 as IReadOnlyList<PmTerminateContractsDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<PmTerminateContractsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValuesPmTerminateContractsStatusLkp, z => z.PmContract)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<PmTerminateContractsDto>(current);
        }

        public override Task<PmTerminateContractsDto> Update(PmTerminateContractsEditDto input)
        {
            CheckUpdatePermission();

            var entity = Repository.GetAll().Where(x => x.Id == input.Id).FirstOrDefault();

            var mapped = ObjectMapper.Map<PmTerminateContractsEditDto>(entity);

            mapped.TerminationDate = input.TerminationDate;

            mapped.PmContractId = input.PmContractId;

            mapped.FineAmount = input.FineAmount;

            mapped.IsTransferDepositToCustomer = input.IsTransferDepositToCustomer;

            mapped.Notes = input.Notes;

            return base.Update(mapped);
        }

        private async Task<string> GetPmTerminateContractNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "ArInvoiceHd", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
