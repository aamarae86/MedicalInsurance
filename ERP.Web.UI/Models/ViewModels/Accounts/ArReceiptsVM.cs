using ERP._System.__AccountModule._ArReceipts.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArReceiptsVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(ArReceipts.Amount), ResourceType = typeof(ArReceipts))]
        public decimal Amount { get; set; }

        [Display(Name = nameof(ArReceipts.ReceiptNumber), ResourceType = typeof(ArReceipts))]
        [MaxLength(30)]
        public string ReceiptNumber { get; set; }

        [Display(Name = nameof(ArReceipts.ReceiptDateStr), ResourceType = typeof(ArReceipts))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ReceiptDate { get; set; }

        [Display(Name = nameof(ArReceipts.StatusLkpId), ResourceType = typeof(ArReceipts))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        [Display(Name = nameof(ArReceipts.ArCustomerId), ResourceType = typeof(ArReceipts))]
        public long? ArCustomerId { get; set; }
        [Display(Name = nameof(ArReceipts.CustomerNumber), ResourceType = typeof(ArReceipts))]
        public long? CustomerNumber { get; set; }
        public ArCustomersVM ArCustomer { get; set; }

        [Display(Name = nameof(ArReceipts.Notes), ResourceType = typeof(ArReceipts))]
        [MaxLength(4000)]
        public string Notes { get; set; }

        [Display(Name = nameof(ArReceipts.BankAccountId), ResourceType = typeof(ArReceipts))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long BankAccountId { get; set; }
        public ApBankAccountsVM BankAccount { get; set; }

        [Display(Name = nameof(ArReceipts.CurrencyId), ResourceType = typeof(ArReceipts))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public int CurrencyId { get; set; }
        public CurrenciesVM Currency { get; set; }

        [Display(Name = nameof(ArReceipts.CurrencyRate), ResourceType = typeof(ArReceipts))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal CurrencyRate { get; set; }
        [Display(Name = nameof(ArReceipts.RemitanceBankId), ResourceType = typeof(ArReceipts))]
        public long? RemitanceBankId { get; set; }
        public ApBankAccountsVM RemitanceBank { get; set; }

        [Display(Name = nameof(ArReceipts.ManualReceiptNo), ResourceType = typeof(ArReceipts))]
        [MaxLength(30)]
        public string ManualReceiptNo { get; set; }
        [Display(Name = nameof(ArReceipts.SourceCodeLkpId), ResourceType = typeof(ArReceipts))]
        public long? SourceCodeLkpId { get; set; }
        [Display(Name = nameof(ArReceipts.SourceId), ResourceType = typeof(ArReceipts))]
        public long? SourceId { get; set; }

        #region Collection with JSON string properties
        public virtual ICollection<ArReceiptDetailsDto> ListReceiptDetails =>
            string.IsNullOrEmpty(ListReceiptDetailsStr) ?
            new List<ArReceiptDetailsDto>() :
            Helper<List<ArReceiptDetailsDto>>.Convert(ListReceiptDetailsStr);

        public virtual ICollection<ArReceiptsOnAccountDto> ListReceiptsOnAccount =>
            string.IsNullOrEmpty(ListReceiptsOnAccountStr) ?
            new List<ArReceiptsOnAccountDto>() :
            Helper<List<ArReceiptsOnAccountDto>>.Convert(ListReceiptsOnAccountStr);

        [Display(Name = nameof(ArReceipts.ListReceiptDetailsStr), ResourceType = typeof(ArReceipts))]
        public string ListReceiptDetailsStr { get; set; }
        [Display(Name = nameof(ArReceipts.ListReceiptsOnAccountStr), ResourceType = typeof(ArReceipts))]
        public string ListReceiptsOnAccountStr { get; set; }
        #endregion

        [Display(Name = nameof(ArReceipts.ReceiptDetailCheckNumber), ResourceType = typeof(ArReceipts))]
        public string ReceiptDetailCheckNumber { get; set; }

        [Display(Name = nameof(ArReceipts.ReceiptDetailMaturityDateStr), ResourceType = typeof(ArReceipts))]
        public string ReceiptDetailMaturityDateStr { get; set; }

        [Display(Name = nameof(ArReceipts.ReceiptDetailAmount), ResourceType = typeof(ArReceipts))]
        public string ReceiptDetailAmount { get; set; }

        [Display(Name = nameof(ArReceipts.ReceiptDetailNotes), ResourceType = typeof(ArReceipts))]
        public string ReceiptDetailNotes { get; set; }

        [Display(Name = nameof(ArReceipts.ReceiptDetailBankLkpId), ResourceType = typeof(ArReceipts))]
        public long ReceiptDetailBankLkpId { get; set; }

        [Display(Name = nameof(ArReceipts.OnAccountApplyDateStr), ResourceType = typeof(ArReceipts))]
        public string OnAccountApplyDateStr { get; set; }

        [Display(Name = nameof(ArReceipts.OnAccountReceiptTypeLkpId), ResourceType = typeof(ArReceipts))]
        public long OnAccountReceiptTypeLkpId { get; set; }

        [Display(Name = nameof(ArReceipts.OnAccountAmount), ResourceType = typeof(ArReceipts))]
        public decimal OnAccountAmount { get; set; }

        [Display(Name = nameof(ArReceipts.OnAccountNotes), ResourceType = typeof(ArReceipts))]
        public string OnAccountNotes { get; set; }
        [Display(Name = nameof(ArReceipts.OnAccountSourceCodeLkpId), ResourceType = typeof(ArReceipts))]
        public long OnAccountSourceCodeLkpId { get; set; }
        [Display(Name = nameof(ArReceipts.OnAccountSourceId), ResourceType = typeof(ArReceipts))]
        public long OnAccountSourceId { get; set; }

        [Display(Name = nameof(ArReceipts.ReceiptDateFrom), ResourceType = typeof(ArReceipts))]
        public string ReceiptDateFrom { get; set; }
        [Display(Name = nameof(ArReceipts.ReceiptDateTo), ResourceType = typeof(ArReceipts))]
        public string ReceiptDateTo { get; set; }
    }
}