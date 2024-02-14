using Abp.Application.Services;
using ERP._System.__CRM._ActivityCall.Dto;


namespace ERP._System.__CRM._ActivityCall
{
    public interface IActivityCallAppService : IAsyncCrudAppService<ActivityCallDto, long, ActivityCallPagedDto, ActivityCallCreateDto, ActivityCallEditDto>
    {
    }
}
 