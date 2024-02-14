using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
 
namespace ERP._System.__CRM._ActivityTasks.Dto
{
    [AutoMap(typeof(ActivityTasks))]
    public class ActivityTasksCreateDto
    {
        public long RelatedToLkpId { get; set; }
        public long CrmLeadsPersonsId { get; set; }
        [MaxLength(200)]
        public string Subject { get; set; }
        public long StatuesLkpId { get; set; }
        public long PriorityLkpId { get; set; }
        public long? CrmDealsId { get; set; }
        public string DueDate { get; set; }
        public string ReminderDate { get; set; }
        public string ReminderTime { get; set; }
        public bool Reminder { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }

    }
}
