using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP.Currencies.Dto;
using ERP.Helpers.Core;
using ERP.StripeIntegration;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Currencies
{
    [AbpAuthorize]
    public class CurrencyAppService : AsyncCrudAppService<Currency, CurrencyDto, int, PagedCurrencyResultRequestDto, CreateCurrencyDto, CurrencyEditDto>,
        ICurrencyAppService
    {
        private readonly ICurrencyManager _currencyManager;

        public CurrencyAppService(IRepository<Currency, int> repository, ICurrencyManager currencyManager) : base(repository)
        {
            _currencyManager = currencyManager;

            //CreatePermissionName = PermissionNames.Pages_Currencies_Insert;
            //UpdatePermissionName = PermissionNames.Pages_Currencies_Update;
            //DeletePermissionName = PermissionNames.Pages_Currencies_Delete;
            //GetAllPermissionName = PermissionNames.Pages_Currencies;
        }

        public async Task<Select2PagedResult> GetCurrenciesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _currencyManager.GetCurrenciesSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<decimal> GetRate(CurrencyRateDto currencyRateDto)
            => await _currencyManager.GetRate(currencyRateDto.Id, currencyRateDto.date);

        
        public async Task<bool> GetLocalCurrencyStatus()
        {
            var Entity = await Repository.FirstOrDefaultAsync(x => x.IsLocalCurrency == true);
            return Entity == null;
        }

        public async Task<CurrencyDto> GetFirstCurrencyAsync()
        {
            var current = await Repository.GetAll()
                .Where(z => z.TenantId == AbpSession.TenantId).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<CurrencyDto>(current);

            return mapped;
        }

        protected override IQueryable<Currency> CreateFilteredQuery(PagedCurrencyResultRequestDto input)
        {
            try
            {
                var queryable = Repository.GetAll();

                if (!string.IsNullOrEmpty(input.Params.Code))
                    queryable = queryable.Where(q => q.Code.Contains(input.Params.Code));

                if (!string.IsNullOrEmpty(input.Params.DescriptionAr))
                    queryable = queryable.Where(q => q.DescriptionAr.Contains(input.Params.DescriptionAr));

                if (!string.IsNullOrEmpty(input.Params.DescriptionEn))
                    queryable = queryable.Where(q => q.DescriptionEn.Contains(input.Params.DescriptionEn));

                queryable = queryable.OrderByDescending(x => x.CreationTime);

                return queryable;
            }
            catch (System.Exception ex)
            {
                return base.CreateFilteredQuery(input);
            }
        }
    }
}
