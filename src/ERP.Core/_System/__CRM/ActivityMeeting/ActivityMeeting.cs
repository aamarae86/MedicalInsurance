using Abp.Domain.Entities;
using ERP.Helpers.Core.__PostAudited;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP._System.__CRM.Leads;
using System;
using System.Collections;
using System.Collections.Generic;
using ERP._System.__CRM.Deals;

namespace ERP._System.__CRM._ActivityMeeting
{
   public class ActivityMeeting : PostAuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        public bool AllDay { get; set; }

        public DateTime FromDay { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToDay { get; set; }
        public DateTime ToTime { get; set; }

        public long RelatedToLkpId { get; set; }
        [ForeignKey(nameof(RelatedToLkpId))]
        public FndLookupValues RelatedToLkps { get; set; } //"CrmLeadsPersonsType"
         
        public long CrmLeadsPersonsId { get; set; }
        [ForeignKey(nameof(CrmLeadsPersonsId))]
        public CrmLeadsPersons CrmLeadsPersons { get; set; } //with CrmLeadsPersons


        public long? CrmDealsId { get; set; }
        [ForeignKey(nameof(CrmDealsId))]
        public CrmDeals CrmDeals { get; set; } //with CrmDeals

        public long PartiReminderLkpId { get; set; }
        [ForeignKey(nameof(PartiReminderLkpId))]
        public FndLookupValues PartiReminderLkps { get; set; } //"ActivityMeetingPartRemember"

        [MaxLength(4000)]
        public string Description { get; set; }
        public int TenantId { get; set; }
        [NotMapped]
        public string Lang { get; set; }
        public ICollection<ActivityMeetingParticipant> ActivityMeetingParticipant { get; set; }

    }
}
