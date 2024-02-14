using Abp.Application.Services.Dto;

namespace ERP._System.__CRM._CrmContactUs.Dto
{
    public class CrmContactUsPagedDto : PagedAndSortedResultRequestDto
    {
        public CrmContactUsSearchDto Params { get; set; }
    }
}
