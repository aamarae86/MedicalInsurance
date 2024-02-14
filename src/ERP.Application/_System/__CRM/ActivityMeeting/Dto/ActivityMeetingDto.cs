using Abp.AutoMapper;
 
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CRM._ActivityMeeting.Dto
{
    [AutoMap(typeof(ActivityMeeting))]
    public class ActivityMeetingDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
  
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        public bool AllDay { get; set; }

        public string FromDay { get; set; }
        public string FromTime { get; set; }
        public string ToDay { get; set; }
        public string ToTime { get; set; }

        public long RelatedToLkpId { get; set; }
        public string RelatedToLkpVal { get; set; }
        
        public long CrmLeadsPersonsId { get; set; }
        public string CrmLeadsPersonsVal { get; set; }
        
        public long PartiReminderLkpId { get; set; }
        public string PartiReminderLkpVal { get; set; }


        public long? CrmDealsId { get; set; }
        public string CrmDealsVal { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

         
        public virtual ICollection<ActivityMeetingParticipantDto> ActivityMeetingParticipantList { get; set; }
    }
}
