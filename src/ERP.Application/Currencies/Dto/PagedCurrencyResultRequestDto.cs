using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP.Currencies.Dto
{
    [AutoMapFrom(typeof(Currency))]
    public class PagedCurrencyResultRequestDto : PagedResultRequestDto
    {
        public CurrencySearchDto Params { get; set; }
    }
}
