using ERP.ResourcePack.Accounts;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ApPdcInterfaceVM : BasePostAuditedVM<long>
    {
        public string encApMiscPaymenId { get; set; }

        [Display(Name = nameof(ArPdcInterface.SourceCode), ResourceType = typeof(ArPdcInterface))]
        public long? SourceCodeLkpId { get; set; }

        [Display(Name = nameof(ArPdcInterface.RegestrationNumber), ResourceType = typeof(ArPdcInterface))]
        public long? SourceId { get; set; }

        [Display(Name = nameof(ArPdcInterface.Status), ResourceType = typeof(ArPdcInterface))]
        public long? StatusLkpId { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(ApPdcInterface.RecieptNumber), ResourceType = typeof(ApPdcInterface))]
        public string SourceNumber { get; set; }

        [Display(Name = nameof(ArPdcInterface.Amount), ResourceType = typeof(ArPdcInterface))]
        public decimal? Amount { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(ArPdcInterface.CheckNumber), ResourceType = typeof(ArPdcInterface))]
        public string CheckNumber { get; set; }

        [Display(Name = nameof(ArPdcInterface.MaturityDate), ResourceType = typeof(ArPdcInterface))]
        public string MaturityDate { get; set; }

        [Display(Name = nameof(ArPdcInterface.BankAccount), ResourceType = typeof(ArPdcInterface))]
        public long? BankAccountId { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ArPdcInterface.Notes), ResourceType = typeof(ArPdcInterface))]
        public string Notes { get; set; }

        public string ConfirmedDate { get; set; }

        public string ReversedDate { get; set; }

        public long? VendorId { get; set; }

        [Display(Name = nameof(ApPdcInterface.ChqReturnResonLKP), ResourceType = typeof(ApPdcInterface))]
        public long? ChqReturnResonLKPId { get; set; }

        public FndLookupValuesVM FndLookupValuesSourceCodeLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesStatusLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesChqReturnResonLKP { get; set; }

        public ApBankAccountsVM ApBankAccounts { get; set; }
        [Display(Name = nameof(ArPdcInterface.FromDate), ResourceType = typeof(ArPdcInterface))]

        public string FromDate { get; set; }

        [Display(Name = nameof(ArPdcInterface.ToDate), ResourceType = typeof(ArPdcInterface))]
        public string ToDate { get; set; }

        public decimal? TotalAmount { get; set; }
    }
}