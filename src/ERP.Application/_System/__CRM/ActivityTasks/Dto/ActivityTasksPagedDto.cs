using Abp.Application.Services.Dto;

namespace ERP._System.__CRM._ActivityTasks.Dto
{
    public class ActivityTasksPagedDto  : PagedAndSortedResultRequestDto
    {
        public ActivityTasksSearchDto Params { get; set; }
    }
}
