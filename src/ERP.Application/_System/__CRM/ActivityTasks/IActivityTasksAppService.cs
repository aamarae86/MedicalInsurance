using Abp.Application.Services;
using ERP._System.__CRM._ActivityTasks.Dto;


namespace ERP._System.__CRM._ActivityTasks
{
    public interface IActivityTasksAppService : IAsyncCrudAppService<ActivityTasksDto, long, ActivityTasksPagedDto, ActivityTasksCreateDto, ActivityTasksEditDto>
    {
    }
}
 