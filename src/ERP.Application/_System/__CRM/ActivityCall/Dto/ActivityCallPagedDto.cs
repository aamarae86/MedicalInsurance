using Abp.Application.Services.Dto;

namespace ERP._System.__CRM._ActivityCall.Dto
{
    public class ActivityCallPagedDto  : PagedAndSortedResultRequestDto
    {
        public ActivityCallSearchDto Params { get; set; }
    }
}
