using Abp.Application.Services;
using ERP.Currencies.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP.Currencies
{
    public interface ICurrencyAppService : IAsyncCrudAppService<CurrencyDto, int, PagedCurrencyResultRequestDto, CreateCurrencyDto, CurrencyEditDto>
    {
        Task<decimal> GetRate(CurrencyRateDto currencyRateDto);
        Task<bool> GetLocalCurrencyStatus();
        Task<Select2PagedResult> GetCurrenciesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<CurrencyDto> GetFirstCurrencyAsync();

    }
}
