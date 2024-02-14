using Abp.Domain.Entities;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ERP._System.__CRM._ActivityMeeting;
using ERP._System._FndLookupValues;
using ERP._System.__CRM.Leads;

namespace ERP._System.__CRM._ActivityMeeting
{
   public class ActivityMeetingParticipant : PostAuditedEntity<long>, IMustHaveTenant
    {
        public long ActivityMeetingId { get; set; }
        [ForeignKey(nameof(ActivityMeetingId))]
        public ActivityMeeting ActivityMeetings { get; set; }

        public long RelatedToLkpId { get; set; }
        [ForeignKey(nameof(RelatedToLkpId))]
        public FndLookupValues RelatedToLkps { get; set; } //"CrmLeadsPersonsType"

        public long CrmLeadsPersonsId { get; set; }
        [ForeignKey(nameof(CrmLeadsPersonsId))]
        public CrmLeadsPersons CrmLeadsPersons { get; set; } //with CrmLeadsPersons

        public int TenantId { get; set; }
    }
}
