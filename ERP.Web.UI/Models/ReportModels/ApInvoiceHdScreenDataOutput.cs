using System;

namespace ERP.Web.UI.Models.ReportModels
{
    public class ApInvoiceHdScreenDataOutput
    {
        public long Id { get; set; }
        public string HdInvNo { get; set; }
        public DateTime HdDate { get; set; }
        public Decimal CurrencyRate { get; set; }
        public Decimal PrepaidAmount { get; set; }
        public string Comments { get; set; }
        public int PrepaidPeriod { get; set; }
        public string Status { get; set; }
        public long StatusLkpId { get; set; }
        public string HdType { get; set; }
        public long HdTypeLkpId { get; set; }
        public string CurrencyNameAr { get; set; }
        public string CurrencyNameEn { get; set; }
        public string VendorNameAr { get; set; }
        public string VendorNameEn { get; set; }
        public string FromAccountCode { get; set; }
        public string FromAccountName { get; set; }
        public string ToAccountCode { get; set; }
        public string ToAccountName { get; set; }
        public string DetailsDesc { get; set; }
        public Decimal DetailsAmount { get; set; }
        public Decimal DetailsTaxAmount { get; set; }
        public string DetailsAccountCode { get; set; }
        public string DetailsAccountName { get; set; }
        public long TaxPercentageLkpId { get; set; }
        public string TaxPercentage { get; set; }
        public string TaxNo { get; set; }

    }
}