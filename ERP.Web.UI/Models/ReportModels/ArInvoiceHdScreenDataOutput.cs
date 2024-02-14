using System;

namespace ERP.Web.UI.Models.ReportModels
{
    public class ArInvoiceHdScreenDataOutput
    {
        public long Id { get; set; }
        public string HdInvoiceNo { get; set; }
        public DateTime HdDate { get; set; }
        public long StatusLkpId { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string CurrencyNameAr { get; set; }
        public string CurrencyNameEn { get; set; }
        public decimal CurrancyRate { get; set; }
        public string CustomerNameAr { get; set; }
        public string CustomerNameEn { get; set; }
        public string DetailDesc { get; set; }
        public decimal DetailAmount { get; set; }
        public string DetailAccountCode { get; set; }
        public string DetailAccountName { get; set; }
        public decimal DetailTaxPercent { get; set; }

     

      

       
    }
}