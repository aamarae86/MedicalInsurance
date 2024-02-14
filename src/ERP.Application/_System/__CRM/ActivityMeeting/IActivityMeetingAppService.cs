using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__CRM._ActivityMeeting.Dto;
 
using System.Threading.Tasks;

namespace ERP._System.__HR._ActivityMeeting
{
    public interface IActivityMeetingAppService : IAsyncCrudAppService<ActivityMeetingDto, long, PagedActivityMeetingRequestDto, CreateActivityMeetingDto, ActivityMeetingEditDto>
    {
       // Task<ActivityMeetingParticipantDto> GetDetailAsync(EntityDto<long> input);                            

    }
}
