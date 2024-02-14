using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._FndTaxType
{
    [AbpAuthorize]

    public class FndTaxTypeAppService : AsyncCrudAppService<FndTaxType, FndTaxTypeDto, long, FndTaxTypePagedDto, FndTaxTypeCreateDto, FndTaxTypeEditDto>, IFndTaxTypeAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
      


        public FndTaxTypeAppService(IRepository<FndTaxType, long> repository,
             IGetCounterRepository getCounterRepository
            ) : base(repository)
        {

          
            _repoProcCounter = getCounterRepository;


            CreatePermissionName = PermissionNames.Pages_FndTaxType_Insert;
            UpdatePermissionName = PermissionNames.Pages_FndTaxType_Update;
            DeletePermissionName = PermissionNames.Pages_FndTaxType_Delete;
            GetAllPermissionName = PermissionNames.Pages_FndTaxType;
        }

        protected override IQueryable<FndTaxType> CreateFilteredQuery(FndTaxTypePagedDto input)
        {
            var iqueryable = Repository.GetAll();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.TaxTypeNumber))
                iqueryable = iqueryable.Where(z => z.TaxTypeNumber.Contains(input.Params.TaxTypeNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.TaxNameAr))
                iqueryable = iqueryable.Where(z => z.TaxNameAr.Contains(input.Params.TaxNameAr));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.TaxNameEn))
                iqueryable = iqueryable.Where(z => z.TaxNameEn.Contains(input.Params.TaxNameEn));


            if (input.Params != null && input.Params.Percentage != 0)
                iqueryable = iqueryable.Where(z => z.Percentage == input.Params.Percentage);
         
           
            return iqueryable;
        }

        public override async Task<FndTaxTypeDto> Create(FndTaxTypeCreateDto input)
        {
            try
            {
                CheckCreatePermission();
                input.TaxTypeNumber = await GetFndTaxTypeNumber();
                var FndTaxTypeList = ObjectMapper.Map<FndTaxType>(input);

                _ = await Repository.InsertAsync(FndTaxTypeList);

                return new FndTaxTypeDto { };

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Select2PagedResult> GetFndTaxTypeSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = Repository.GetAll().Where(z => string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.TaxNameAr.Contains(searchTerm) : z.TaxNameEn.Contains(searchTerm)));
            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = (lang == "ar-EG" ? z.TaxNameAr : z.TaxNameEn), altText = z.Percentage.ToString("0.00") })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<decimal> GetPercentage(int id, DateTime? date)
        {
            var TaxType = await Repository.GetAsync(id);
            return TaxType.Percentage;
        }

        private async Task<string> GetFndTaxTypeNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "FndTaxType", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }


    }
}
