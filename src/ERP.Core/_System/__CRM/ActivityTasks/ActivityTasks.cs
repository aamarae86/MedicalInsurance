using Abp.Domain.Entities;
using ERP._System.__CRM.Deals;
using ERP._System.__CRM.Leads;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__CRM._ActivityTasks
{
   public class ActivityTasks : PostAuditedEntity<long>, IMustHaveTenant
    {
        public long RelatedToLkpId { get; set; }
        [ForeignKey(nameof(RelatedToLkpId))]
        public FndLookupValues RelatedToLkps { get; set; } //"CrmLeadsPersonsType"

        public long CrmLeadsPersonsId { get; set; }
        [ForeignKey(nameof(CrmLeadsPersonsId))]
        public CrmLeadsPersons CrmLeadsPersons { get; set; } //with CrmLeadsPersons

        [MaxLength(200)]
        public string Subject { get; set; }
        public long StatuesLkpId { get; set; }
        [ForeignKey(nameof(StatuesLkpId))]
        public FndLookupValues StatuesLkps { get; set; } //"ActivityTasksStatues"
        public long PriorityLkpId { get; set; }
        [ForeignKey(nameof(PriorityLkpId))]
        public FndLookupValues PriorityLkps { get; set; } //"ActivityTasksPriority"
        
        public long? CrmDealsId { get; set; }
        [ForeignKey(nameof(CrmDealsId))]
        public CrmDeals CrmDeals { get; set; } //with CrmDeals



        public DateTime DueDate { get; set; }
        public DateTime ReminderDate { get; set; }
        public DateTime ReminderTime { get; set; }
        public bool Reminder { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }
        public int TenantId { get; set; }

        [NotMapped]
        public string Lang { get; set; }
    }
}
