using Abp.Application.Services.Dto;

namespace ERP._System.__Warehouses._PoPurchaseOrder.Dto
{
    public class PoPurchaseOrderPagedDto : PagedAndSortedResultRequestDto
    {
        public PoPurchaseOrderSearchDto Params { get; set; }
    }
}
