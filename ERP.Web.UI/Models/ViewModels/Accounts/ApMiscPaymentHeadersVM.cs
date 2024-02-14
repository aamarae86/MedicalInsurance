using ERP.Front.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ApMiscPaymentHeadersVM : BasePostAuditedVM<long>
    {
        [Display(Name = nameof(FndUsers.CaseNumber), ResourceType = typeof(FndUsers))]
        public string CaseNumber { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.PortalUsersId), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string PortalUserName { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.CheckNumber), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string CheckNumber { get; set; }

        [Display(Name = nameof(Settings.FromDate), ResourceType = typeof(Settings))]
        public string FromDate { get; set; }

        [Display(Name = nameof(Settings.ToDate), ResourceType = typeof(Settings))]
        public string ToDate { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.PortalUsersId), ResourceType = typeof(ApMiscPaymentHeaders))]
        public long PortalUsersId { get; set; }

        public string Lang { get; set; }

        public string EncId { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.PaymentNumber), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string PaymentNumber { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.MiscPaymentDate), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string MiscPaymentDate { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.BeneficiaryName), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string BeneficiaryName { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.AccPayeeOnly), ResourceType = typeof(ApMiscPaymentHeaders))]
        public bool AccPayeeOnly { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.BankBoxes), ResourceType = typeof(ApMiscPaymentHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? BankAccountId { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.Notes), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string Notes { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.PostedLkpId), ResourceType = typeof(ApMiscPaymentHeaders))]
        public long? PostedlkpId { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.PaymentTypeLkpId), ResourceType = typeof(ApMiscPaymentHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? PaymentTypeLkpId { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.Amount), ResourceType = typeof(ApMiscPaymentHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal? Amount { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.SourceCodeLkpId), ResourceType = typeof(ApMiscPaymentHeaders))]
        public long? SourceCodeLkpId { get; set; }

        public long? SourceId { get; set; }

        public bool AccPayeeOnlyAlt { get; set; }

        public string ListApMiscPaymentLines { get; set; }
        public string ListApMiscPaymentDetails { get; set; }

        public List<ListApMiscPaymentDetailsVM> ListApMiscPaymentDetailsVM
           =>
          string.IsNullOrEmpty(this.ListApMiscPaymentDetails) ?
              new List<ListApMiscPaymentDetailsVM>() :
              Helper<List<ListApMiscPaymentDetailsVM>>.Convert(this.ListApMiscPaymentDetails);

        public List<ListApMiscPaymentLinesVM> ListApMiscPaymentLinesVM
         =>
        string.IsNullOrEmpty(this.ListApMiscPaymentLines) ?
            new List<ListApMiscPaymentLinesVM>() :
            Helper<List<ListApMiscPaymentLinesVM>>.Convert(this.ListApMiscPaymentLines);


        public FndLookupValuesVM FndLookupValuesPostedPaymentLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesPaymentTypeLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesSourceCodePaymentLkp { get; set; }

        public ApBankAccountsVM ApBankAccounts { get; set; }
    }
}