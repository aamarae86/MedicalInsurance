using Abp.Domain.Entities.Auditing;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ApMiscPaymentDetailsVM : AuditedEntity<long>, IAuditedEntityStrDates
    {
        [Display(Name = nameof(ApMiscPaymentHeaders.CheckNumber), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string CheckNumber { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.BeneficiaryName), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string BeneficiaryNameDetail { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.Amount), ResourceType = typeof(ApMiscPaymentHeaders))]
        public decimal? Amount { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.Amount), ResourceType = typeof(ApMiscPaymentHeaders))]
        public decimal? AmountDetails { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.Notes), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string Notes { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.MaturityDate), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string MaturityDate { get; set; }

        public long? MiscPaymentId { get; set; }

        public string CreationTimeStr => this.CreationTime.ToString("yyyy/MM/dd");
            //public string DeletionTimeStr => this.DeletionTime == null ? null : this.DeletionTime.Value.ToString("yyyy/MM/dd");
        public string LastModificationTimeStr => this.LastModificationTime == null ? null : this.LastModificationTime.Value.ToString("yyyy/MM/dd");
    }

}