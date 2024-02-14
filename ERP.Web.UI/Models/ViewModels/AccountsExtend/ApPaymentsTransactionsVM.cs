using ERP.ResourcePack.AccountsExtend;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AccountsExtend
{
    public class ApPaymentsTransactionsVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(ApPaymentsTransactions.PaymentNumber), ResourceType = typeof(ApPaymentsTransactions))]
        public string PaymentNumber { get; set; }

        [Display(Name = nameof(ApPaymentsTransactions.CheckNumber), ResourceType = typeof(ApPaymentsTransactions))]
        public string CheckNumber { get; set; }

        [Display(Name = nameof(ApPaymentsTransactions.PaymentDate), ResourceType = typeof(ApPaymentsTransactions))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string PaymentDate { get; set; }

        [Display(Name = nameof(ApPaymentsTransactions.MaturityDate), ResourceType = typeof(ApPaymentsTransactions))]
        public string MaturityDate { get; set; }

        [Display(Name = nameof(ApPaymentsTransactions.Notes), ResourceType = typeof(ApPaymentsTransactions))]
        public string Notes { get; set; }

        [Display(Name = nameof(ApPaymentsTransactions.PaymentAmount), ResourceType = typeof(ApPaymentsTransactions))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal PaymentAmount { get; set; }

        [Display(Name = nameof(ApPaymentsTransactions.AccPayeeOnly), ResourceType = typeof(ApPaymentsTransactions))]
        public bool AccPayeeOnly { get; set; }

        [Display(Name = nameof(ApPaymentsTransactions.AccPayeeOnly), ResourceType = typeof(ApPaymentsTransactions))]
        public bool AccPayeeOnlyAlt { get; set; }

        [Display(Name = nameof(ApPaymentsTransactions.StatusLkpId), ResourceType = typeof(ApPaymentsTransactions))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(ApPaymentsTransactions.PaymentTypeLkpId), ResourceType = typeof(ApPaymentsTransactions))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PaymentTypeLkpId { get; set; }

        [Display(Name = nameof(ApPaymentsTransactions.BankAccountId), ResourceType = typeof(ApPaymentsTransactions))]
        public long? BankAccountId { get; set; }

        [Display(Name = nameof(ApPaymentsTransactions.VendorId), ResourceType = typeof(ApPaymentsTransactions))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long VendorId { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public FndLookupValuesVM FndPaymentTypeLkp { get; set; }

        public ApBankAccountsVM ApBankAccounts { get; set; }

        public ApVendorsVM ApVendors { get; set; }
    }
}