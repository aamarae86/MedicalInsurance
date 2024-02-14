using System;
using System.ComponentModel.DataAnnotations;
using ERP.ResourcePack.CRM.activityCall;
using ERP.ResourcePack.CRM.Deals;
using ERP.Web.UI.Controllers.Base;

namespace ERP.Web.UI.Models.ViewModels.CRM.ActivityCall
{
    public class ActivityCallVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(activityCall.RelatedToLkpId), ResourceType = typeof(activityCall))]
        public long RelatedToLkpId { get; set; }
        public string RelatedToLkpVal { get; set; }

        [Display(Name = nameof(activityCall.CrmLeadsPersonsId), ResourceType = typeof(activityCall))]
        public long CrmLeadsPersonsId { get; set; }
        public string CrmLeadsPersonsVal { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(activityCall.Subject), ResourceType = typeof(activityCall))]
        public string Subject { get; set; }

        [Display(Name = nameof(activityCall.CallPurposeLkpId), ResourceType = typeof(activityCall))]
        public long CallPurposeLkpId { get; set; }
        public string CallPurposeLkpVal { get; set; }

        [Display(Name = nameof(activityCall.CallTypeLkpId), ResourceType = typeof(activityCall))]
        public long CallTypeLkpId { get; set; }
        public string CallTypeLkpVal { get; set; }

        [Display(Name = nameof(activityCall.CallDetailsLkpId), ResourceType = typeof(activityCall))]
        public long CallDetailsLkpId { get; set; }
        public string CallDetailsLkpVal { get; set; }

        [Display(Name = nameof(activityCall.StartDate), ResourceType = typeof(activityCall))]
        public string StartDate { get; set; }
   
        [Display(Name = nameof(activityCall.StartTime), ResourceType = typeof(activityCall))]
        public string StartTime { get; set; }

        [Display(Name = nameof(activityCall.EndTime), ResourceType = typeof(activityCall))]
        public string EndTime { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(activityCall.Description), ResourceType = typeof(activityCall))]
        public string Description { get; set; }

        [Display(Name = nameof(activityCall.CallResultLkpId), ResourceType = typeof(activityCall))]
        public long CallResultLkpId { get; set; }
        public string CallResultLkpVal { get; set; }


        [Display(Name = nameof(deals.Title), ResourceType = typeof(deals))]
        public long? CrmDealsId { get; set; }
        public string CrmDealsVal { get; set; }



    }
}