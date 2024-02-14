using Abp.Application.Services.Dto;

namespace ERP._System.__Warehouses._IvPriceListHd.Dto
{
   public class IvPriceListHdPagedDto : PagedAndSortedResultRequestDto
    {
        public IvPriceListHdSearchDto Params { get; set; }
    }
}
