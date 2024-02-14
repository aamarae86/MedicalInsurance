using ERP.Front.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.SpGuarantees;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using ERP.Web.UI.Models.ViewModels.SpGuarantees;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArMiscReceiptHeadersVM : BasePostAuditedVM<long>
    {
        public long PortalUsersId { get; set; }

        public string Lang { get; set; }

        public string EncId { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.CheckNumber), ResourceType = typeof(ArMiscReceiptHeaders))]
        public string CheckNumber { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.ReceiptType), ResourceType = typeof(ArMiscReceiptHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? ReceiptTypeLkpId { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.ReceiptNumber), ResourceType = typeof(ArMiscReceiptHeaders))]
        public string ReceiptNumber { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.MiscReceiptDate), ResourceType = typeof(ArMiscReceiptHeaders))]
        public string MiscReceiptDate { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.Boxes), ResourceType = typeof(ArMiscReceiptHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? BankAccountId { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.Notes), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string Notes { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.PostedLkpId), ResourceType = typeof(ArMiscReceiptHeaders))]
        public long? PostedLkpId { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.TransactionTypeLkpId), ResourceType = typeof(ArMiscReceiptHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? TransactionTypeLkpId { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.CollectorId), ResourceType = typeof(ArMiscReceiptHeaders))]
        public long? CollectorId { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.Amount), ResourceType = typeof(ArMiscReceiptHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal? Amount { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.ManualReceiptNumber), ResourceType = typeof(ArMiscReceiptHeaders))]
        public string ManualReceiptNumber { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.BeneficentId), ResourceType = typeof(ArMiscReceiptHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? BeneficentId { get; set; }

        [Display(Name = nameof(ArMiscReceiptHeaders.SourceCodeLkpId), ResourceType = typeof(ArMiscReceiptHeaders))]
        public long? SourceCodeLkpId { get; set; }

        public long? SourceId { get; set; }


        [Display(Name = nameof(SpCases.CaseName), ResourceType = typeof(SpCases))]
        public long? SpContractDetailsId { get; set; }

        public string ListArMiscReceiptLines { get; set; }
        public string ListArMiscReceiptDetails { get; set; }

        public List<ListArMiscReceiptDetailsVM> ListArMiscReceiptDetailsVM => string.IsNullOrEmpty(this.ListArMiscReceiptDetails) ?
              new List<ListArMiscReceiptDetailsVM>() : Helper<List<ListArMiscReceiptDetailsVM>>.Convert(this.ListArMiscReceiptDetails);

        public List<ListArMiscReceiptLinesVM> ListArMiscReceiptLinesVM => string.IsNullOrEmpty(this.ListArMiscReceiptLines) ?
            new List<ListArMiscReceiptLinesVM>() : Helper<List<ListArMiscReceiptLinesVM>>.Convert(this.ListArMiscReceiptLines);

        public SpBeneficentVM SpBeneficent { get; set; }

        public ApBankAccountsVM ApBankAccounts { get; set; }

        public FndLookupValuesVM FndLookupValuesPostedLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesTransactionTypeLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesSourceCodeLkp { get; set; }

        public FndLookupValuesVM FndReceiptTypeLkp { get; set; }

        public FndCollectorsVM FndCollectors { get; set; }
    }
}