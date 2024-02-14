using Abp.Application.Services.Dto;
using Abp.AutoMapper;
 

namespace ERP._System.__CRM._ActivityMeeting.Dto
{
    [AutoMap(typeof(ActivityMeetingParticipant))]
    public class ActivityMeetingParticipantDto : EntityDto<long>
    {

        public long ActivityMeetingId { get; set; }
        public string ActivityMeetingVal { get; set; }
 
        public long RelatedToLkpId { get; set; }
        public string RelatedToLkpVal { get; set; }
 
        public long CrmLeadsPersonsId { get; set; }
        public string CrmLeadsPersonsVal { get; set; }
  
        public string rowStatus { get; set; }
    }
}
