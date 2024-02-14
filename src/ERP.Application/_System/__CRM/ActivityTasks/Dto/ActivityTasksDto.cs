
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CRM._ActivityTasks.Dto
{
    public class ActivityTasksDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(Id.ToString());

        public long RelatedToLkpId { get; set; }
        public string RelatedToLkpVal { get; set; }

        public long CrmLeadsPersonsId { get; set; }
        public string CrmLeadsPersonsVal { get; set; }


        public long? CrmDealsId { get; set; }
        public string CrmDealsVal { get; set; }
        [MaxLength(200)]
        public string Subject { get; set; }

        public long StatuesLkpId { get; set; }
        public string StatuesLkpVal { get; set; }

        public long PriorityLkpId { get; set; }
        public string PriorityLkpVal { get; set; }

        public string DueDate { get; set; }
        public string ReminderDate { get; set; }
        public string ReminderTime { get; set; }
        public bool Reminder { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
    }
}
