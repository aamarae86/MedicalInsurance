using ERP.ResourcePack.Accounts;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ApMiscPaymentLinesVM : BaseAuditedEntityVM<long>
    {
        [MaxLength(30)]
        [Display(Name = nameof(ApMiscPaymentHeaders.InvoiceNumber), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string InvoiceNumber { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.MiscPaymentAmount), ResourceType = typeof(ApMiscPaymentHeaders))]
        public decimal? MiscPaymentAmount { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.Notes), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string Notes { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.TaxNo), ResourceType = typeof(ApMiscPaymentHeaders))]
        public string TaxNo { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.TaxPercent), ResourceType = typeof(ApMiscPaymentHeaders))]
        public decimal? TaxPercent { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.TrTax), ResourceType = typeof(ApMiscPaymentHeaders))]
        public decimal? TrTax { get; set; }

        public long? TaxAccountId { get; set; }

        public long? AccountId { get; set; }

        public long? MiscPaymentId { get; set; }

        [Display(Name = nameof(ApMiscPaymentHeaders.TaxPercent), ResourceType = typeof(ApMiscPaymentHeaders))]
        public long? TaxPercentageLkpId { get; set; }

        public string TaxPercentageNameAr { get; set; }

        public string TaxPercentageNameEn { get; set; }
    }
}