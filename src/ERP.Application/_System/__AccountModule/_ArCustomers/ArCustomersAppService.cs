using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System._ArCustomers.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues;
using ERP._System._FndLookupValues.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._ArCustomers
{
    [AbpAuthorize]
    public class ArCustomersAppService : AsyncCrudAppService<ArCustomers, ArCustomersDto, long, PagedArCustomersResultRequestDto, CreateArCustomersDto, ArCustomersEditDto>, IArCustomersAppService
    {
        private readonly IArCustomersManager _ArCustomersManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IFndLookupValuesManager _IFndLookupValuesManager;

        public ArCustomersAppService(IRepository<ArCustomers, long> repository,
            IGetCounterRepository repoProcCounter, IArCustomersManager ArCustomersManager) : base(repository)
        {
            _ArCustomersManager = ArCustomersManager;
            _repoProcCounter = repoProcCounter;
           

            CreatePermissionName = PermissionNames.Pages_ArCustomers_Insert;
            UpdatePermissionName = PermissionNames.Pages_ArCustomers_Update;
            DeletePermissionName = PermissionNames.Pages_ArCustomers_Delete;
            GetAllPermissionName = PermissionNames.Pages_ArCustomers;
        }

        public void SetGetAllPermissionName(string permissionName)
        {
            GetAllPermissionName = permissionName;
        }

        public void SetCreatePermissionName(string permissionName)
        {
            CreatePermissionName = permissionName;
        }

        public void SetUpdatePermissionName(string permissionName)
        {
            UpdatePermissionName = permissionName;
        }

        public void SetDeletePermissionName(string permissionName)
        {
            DeletePermissionName = permissionName;
        }

        public async override Task<ArCustomersDto> Create(CreateArCustomersDto input)
        {
            var counterInput = new GetCounterInputDto { CounterName = "ArCustomers", TenantId = (int)AbpSession.TenantId, Lang = input.Lang, year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            if (input.SourceCodeLkpId == 0) input.SourceCodeLkpId = Convert.ToInt64(FndEnum.FndLkps.Manual_ArCustomersSource);

            input.CustomerNumber = input.CustomerNumber > 0 ? input.CustomerNumber : Convert.ToInt32(result?.FirstOrDefault()?.OutputStr ?? "1");

            return await base.Create(input);
        }

        public async Task<ArCustomersDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValues, x => x.FndLookupValuesCustType, x => x.FndLookupValuesSource,x=>x.FndPaymentTermsLkp)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ArCustomersDto>(current);

            return mapped;
        }
        public async Task<ArCustomersDto> GetFirstCustomerAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValues, x => x.FndLookupValuesCustType, x => x.FndLookupValuesSource, x => x.FndPaymentTermsLkp)
                .Where(z => z.TenantId == AbpSession.TenantId).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ArCustomersDto>(current);

            return mapped;
        }

        public async Task<List<ArCustomersDto>> GetAAsync()
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValues, x => x.FndLookupValuesCustType)
                .Where(z => true).ToListAsync();

            var mapped = ObjectMapper.Map<List<ArCustomersDto>>(current);

            return mapped;
        }

        public async Task<bool> GetExistCustomerNameArAsync(string input, string Id)
        {
            var current = await Repository.GetAll()
                .Where(x => x.CustomerNameAr.ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<bool> GetExistCustomerNameEnAsync(string input, string Id)
        {
            var current = await Repository.GetAll()
                           .Where(x => x.CustomerNameEn.ToLower() == input.ToLower() && x.Id.ToString() != Id)
                           .FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<bool> GetExistCustomerTypeAsync(long input, string Id)
        {
            var current = await Repository.GetAll()
                           .Where(x => x.CustomerTypeLkpId == input && x.Id.ToString() != Id &&  x.TenantId == (int)AbpSession.TenantId)
                           .FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<ArCustomersDto> GetCustomeData(string input, string Id)
        {
            var current = await Repository.GetAll()
                .Where(x=> x.Id.ToString() != Id && x.TenantId == (int)AbpSession.TenantId)
                           .FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ArCustomersDto>(current);

            return mapped;
        }

        public async Task<ArCustomersDto> GetCustomerDatadetails(string input, string Id)
        {
            var current = await Repository.GetAll()
                .Where(x => x.Id.ToString() == Id && x.TenantId == (int)AbpSession.TenantId)
                           .FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ArCustomersDto>(current);

            return mapped;
        }


        public async override Task<PagedResultDto<ArCustomersDto>> GetAll(PagedArCustomersResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAll();

            if (!string.IsNullOrEmpty(input.Params.CustomerNameAr))
                queryable = queryable.Where(q => q.CustomerNameAr.Contains(input.Params.CustomerNameAr));

            if (!string.IsNullOrEmpty(input.Params.CustomerNameEn))
                queryable = queryable.Where(q => q.CustomerNameEn.Contains(input.Params.CustomerNameEn));

            if ((input.Params.StatusLkp != null) && input.Params.StatusLkp != 0)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkp);

            if (input.Params.CustomerNumber != null)
                queryable = queryable.Where(q => q.CustomerNumber == input.Params.CustomerNumber);

            if ((input.Params.SourceCodeLkpId != null) && input.Params.SourceCodeLkpId != 0)
                queryable = queryable.Where(q => q.SourceCodeLkpId == input.Params.SourceCodeLkpId);

            if ((input.Params.SourceId != null) && input.Params.SourceId != 0)
                queryable = queryable.Where(q => q.SourceId == input.Params.SourceId);

            var count = await queryable.CountAsync();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ArCustomersDto>());

            var PagedResultDto = new PagedResultDto<ArCustomersDto>()
            {
                Items = data2 as IReadOnlyList<ArCustomersDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }
        public async Task<Select2PagedResult> GetArCustomersBytypeSelect2(string searchTerm, string lang,bool IsCash, int pageSize, int pageNumber)
           => await _ArCustomersManager.GetArCustomersBytypeSelect2(searchTerm, lang, IsCash, pageSize, pageNumber);

        public async Task<Select2PagedResult> GetPOSCustomersBytypeSelect2(string searchTerm, string lang, bool IsCash, int pageSize, int pageNumber)
           => await _ArCustomersManager.GetPOSCustomersBytypeSelect2(searchTerm, lang, IsCash, pageSize, pageNumber);

        public async Task<Select2PagedResult> GetArCustomersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _ArCustomersManager.GetArCustomersSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
