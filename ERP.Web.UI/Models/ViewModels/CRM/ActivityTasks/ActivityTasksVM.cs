using System;
using System.ComponentModel.DataAnnotations;
using ERP.Web.UI.Controllers.Base;
using ERP.ResourcePack.CRM.activityTask;
using ERP.ResourcePack.CRM.Deals;
namespace ERP.Web.UI.Models.ViewModels.CRM.ActivityTasks
{
    public class ActivityTasksVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }
        [Display(Name = nameof(activityTask.RelatedToLkpId), ResourceType = typeof(activityTask))]
        public long RelatedToLkpId { get; set; }
        public string RelatedToLkpVal { get; set; }

        [Display(Name = nameof(activityTask.CrmLeadsPersonsId), ResourceType = typeof(activityTask))]
        public long CrmLeadsPersonsId { get; set; }
        public string CrmLeadsPersonsVal { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(activityTask.Subject), ResourceType = typeof(activityTask))]
        public string Subject { get; set; }

        [Display(Name = nameof(activityTask.StatuesLkpId), ResourceType = typeof(activityTask))]
        public long StatuesLkpId { get; set; }
        public string StatuesLkpVal { get; set; }

        [Display(Name = nameof(activityTask.PriorityLkpId), ResourceType = typeof(activityTask))]
        public long PriorityLkpId { get; set; }
        public string PriorityLkpVal { get; set; }

        [Display(Name = nameof(activityTask.DueDate), ResourceType = typeof(activityTask))]
        public string DueDate { get; set; }

        [Display(Name = nameof(activityTask.ReminderDate), ResourceType = typeof(activityTask))]
        public string ReminderDate { get; set; }


        [Display(Name = nameof(activityTask.ReminderTime), ResourceType = typeof(activityTask))]
        public string ReminderTime { get; set; }

        [Display(Name = nameof(activityTask.Reminder), ResourceType = typeof(activityTask))]
        public bool Reminder { get; set; }
        [MaxLength(4000)]
        [Display(Name = nameof(activityTask.Description), ResourceType = typeof(activityTask))]
        public string Description { get; set; }

        [Display(Name = nameof(deals.Title), ResourceType = typeof(deals))]
        public long? CrmDealsId { get; set; }
        public string CrmDealsVal { get; set; }

    }
}