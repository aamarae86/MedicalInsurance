using Abp.Domain.Entities.Auditing;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.SpGuarantees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArMiscReceiptLinesVM : AuditedEntity<long>, IAuditedEntityStrDates
    {
        [Display(Name = nameof(ArMiscReceiptHeaders.MiscReceiptId), ResourceType = typeof(ArMiscReceiptHeaders))]
        public long? MiscReceiptId { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.Amount), ResourceType = typeof(ArMiscReceiptHeaders))]
        public decimal? MiscReceiptAmount { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.Notes), ResourceType = typeof(ArMiscReceiptHeaders))]
        public string Notes { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.ReceiptTypeLkpId), ResourceType = typeof(ArMiscReceiptHeaders))]
        public long? ReceiptTypeLkpId { get; set; }

        public long? CaseId { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.AdminitrativePercent), ResourceType = typeof(ArMiscReceiptHeaders))]
        public decimal? AdministrativePercent { get; set; }

        public long? AccountId { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.ManualReceiptNumber), ResourceType = typeof(ArMiscReceiptHeaders))]
        public string ManualReceiptNumber { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.ManualReceiptNumberLines), ResourceType = typeof(ArMiscReceiptHeaders))]
        public string ManualReceiptNumberLines { get; set; }


        [Display(Name = nameof(ArMiscReceiptHeaders.SourceCodeLkpId), ResourceType = typeof(ArMiscReceiptHeaders))]
        public long? SourceCodeLkpId { get; set; }

        public long? SourceId { get; set; }


        [Display(Name = nameof(ArMiscReceiptHeaders.IsActive), ResourceType = typeof(ArMiscReceiptHeaders))]
        public bool IsActive { get; set; }

        [Display(Name = nameof(SpCases.CaseName), ResourceType = typeof(SpCases))]
        public long? SpContractDetailsId { get; set; }

        [Display(Name = nameof(SpCases.CaseNumber), ResourceType = typeof(SpCases))]
        public string CaseNumber { get; set; }


        public string CreationTimeStr => this.CreationTime.ToString("yyyy/MM/dd");

        public string LastModificationTimeStr => this.LastModificationTime == null ? null : this.LastModificationTime.Value.ToString("yyyy/MM/dd");
    }
}