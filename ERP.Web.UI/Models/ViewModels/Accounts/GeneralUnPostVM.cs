using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class GeneralUnPostVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(ArCustomers.UnPostNo), ResourceType = typeof(ArCustomers))]
        public string UnPostNo { get; set; }

        [Display(Name = nameof(ArCustomers.UnPostDate), ResourceType = typeof(ArCustomers))]
        public string UnPostDate { get; set; }

        [Display(Name = nameof(ArCustomers.SourceLkp), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long SourceLkpId { get; set; }

        [Display(Name = nameof(ArCustomers.ApMiscPaymentHeadersId), ResourceType = typeof(ArCustomers))]
        public long? ApMiscPaymentHeadersId { get; set; }

        public string SourceNo { get; set; }

        [Display(Name = nameof(ArCustomers.Notes), ResourceType = typeof(ArCustomers))]
        public string Notes { get; set; }

        [Display(Name = nameof(ArCustomers.RefuseReason), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string RefuseReason { get; set; }

        public long? ArMiscReceiptHeadersId { get; set; }

        public long? PmContractId { get; set; }

        public long? ScCommitteesId { get; set; }

        public long? GlJeHeaderId { get; set; }

        public long? ScPortalRequestMgrDecisionId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? Select2Temp { get; set; }

        public string Lang { get; set; }

        public long? ArJobCardHdId { get; set; }
        public FndLookupValuesVM FndLookupGeneralUnPostSourceLkp { get; set; }

        public ApMiscPaymentHeadersVM ApMiscPaymentHeaders { get; set; }
    }
}