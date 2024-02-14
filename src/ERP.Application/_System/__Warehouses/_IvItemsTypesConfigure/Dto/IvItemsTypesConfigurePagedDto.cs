using Abp.Application.Services.Dto;

namespace ERP._System.__Warehouses._IvItemsTypesConfigure.Dto
{
    public class IvItemsTypesConfigurePagedDto : PagedAndSortedResultRequestDto
    {
        public IvItemsTypesConfigureSearchDto Params { get; set; }
    }
}
