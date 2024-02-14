using Abp.Application.Services.Dto;

namespace ERP._System.__CRM._CrmProducts.Dto
{
    public class CrmProductsPagedDto : PagedAndSortedResultRequestDto
    {
        public CrmProductsSearchDto Params { get; set; }
    }
}
