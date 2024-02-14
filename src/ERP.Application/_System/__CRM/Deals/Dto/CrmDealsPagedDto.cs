using Abp.Application.Services.Dto;

namespace ERP._System.__CRM._CrmDeals.Dto
{
    public class CrmDealsPagedDto  : PagedAndSortedResultRequestDto
    {
        public CrmDealsSearchDto Params { get; set; }
    }
}
