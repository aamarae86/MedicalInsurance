using ERP.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ERP.ResourcePack.CRM.Deals;
using ERP._System.__CRM.Deals.Dto;
using ERP.Front.Helpers.Core;

namespace ERP.Web.UI.Models.ViewModels.CRM.Deals
{
    public class CrmDealsVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }
        [Display(Name = nameof(deals.Date), ResourceType = typeof(deals))]

        public string DealDate { get; set; }
        [Display(Name = nameof(deals.DealName), ResourceType = typeof(deals))]
        public string DealName { get; set; }

        [Display(Name = nameof(deals.DealTypeLkpId), ResourceType = typeof(deals))]
        public long? DealTypeLkpId { get; set; }

        public string DealTypeLkpval { get; set; }

        [MaxLength(150)]
        [Display(Name = nameof(deals.NextStep), ResourceType = typeof(deals))]
        public string NextStep { get; set; }

        [Display(Name = nameof(deals.LeadSourceLkpId), ResourceType = typeof(deals))]
        public long? LeadSourceLkpId { get; set; }
        public string LeadSourceLkpVal { get; set; }

        [Display(Name = nameof(deals.CrmLeadsPersonsId), ResourceType = typeof(deals))]
        public long? CrmLeadsPersonsId { get; set; }
        public string CrmLeadsPersonsVal { get; set; }

        [Display(Name = nameof(deals.Amount), ResourceType = typeof(deals))]
        public decimal Amount { get; set; }

        [Display(Name = nameof(deals.ClosingDate), ResourceType = typeof(deals))]
        public string ClosingDate { get; set; }


        [Display(Name = nameof(deals.StageLkpID), ResourceType = typeof(deals))]
        public long? StageLkpID { get; set; }
        public string StageLkpVal { get; set; }

        [Display(Name = nameof(deals.Probability), ResourceType = typeof(deals))]
        public string Probability { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(deals.Description), ResourceType = typeof(deals))]
        public string Description { get; set; }

        [Display(Name = nameof(deals.Company), ResourceType = typeof(deals))]
        [MaxLength(500)]
        public string Company { get; set; }

        public string AttachmentsListStr { get; set; }

        public ICollection<CrmDealsAttachmentsDto> Attachments => string.IsNullOrEmpty(AttachmentsListStr) ?
           new List<CrmDealsAttachmentsDto>() : Helper<List<CrmDealsAttachmentsDto>>.Convert(AttachmentsListStr);


    }
}