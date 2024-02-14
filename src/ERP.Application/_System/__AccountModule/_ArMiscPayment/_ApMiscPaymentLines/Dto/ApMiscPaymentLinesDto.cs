using Abp.AutoMapper;
using ERP._System._ApMiscPaymentLines;

namespace ERP._System._ArMiscPayment._ApMiscPaymentLines.Dto
{
    [AutoMap(typeof(ApMiscPaymentLines))]
    public class ApMiscPaymentLinesDto
    {
        public decimal? MiscPaymentAmount { get; set; }

        public string Notes { get; set; }

        public string TaxNo { get; set; }

        public decimal? TaxPercent { get; set; }

        public decimal? TrTax { get; set; }

        public string invoiceNumber { get; set; }

        public long? TaxAccountId { get; set; }

        public long? AccountId { get; set; }

        public long? MiscPaymentId { get; set; }

        public long? TaxPercentageLkpId { get;  set; }
        public string TaxPercentageNameAr { get; set; }
        public string TaxPercentageNameEn { get; set; }

        public long? FndTaxTypeLkpId { get; set; }
        public string FndTaxTypeNameAr { get; set; }
        public string FndTaxTypeNameEn { get; set; }
    }
}
