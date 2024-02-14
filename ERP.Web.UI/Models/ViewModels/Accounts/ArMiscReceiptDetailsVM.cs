using Abp.Domain.Entities.Auditing;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArMiscReceiptDetailsVM : AuditedEntity<long>
    {
        [Display(Name = nameof(ArMiscReceiptHeaders.MiscReceiptId), ResourceType = typeof(ArMiscReceiptHeaders))]
        public long? MiscReceiptId { get;  set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.CheckNumber), ResourceType = typeof(ArMiscReceiptHeaders))]
        public string CheckNumber { get;  set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.MaturityDate), ResourceType = typeof(ArMiscReceiptHeaders))]
        public DateTime? MaturityDate { get;  set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.BankLkp), ResourceType = typeof(ArMiscReceiptHeaders))]
        public long? BankLkpId { get;  set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.CheckAmount), ResourceType = typeof(ArMiscReceiptHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal? AmountDetail { get;  set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.BankAccountId), ResourceType = typeof(ArMiscReceiptHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? BankAccountId { get;  set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.DepositBanks), ResourceType = typeof(ArMiscReceiptHeaders))]
        public long? BankAccountdetailsId { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.IsActive), ResourceType = typeof(ArMiscReceiptHeaders))]
        public bool IsActive { get; set; }

    }
}