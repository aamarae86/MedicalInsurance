using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptMiscreceiptScreenData
    {

        public long id { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime MiscReceiptDate { get; set; }
        public string CollectorNameAr { get; set; }
        public decimal amount { get; set; }
        public string Status { get; set; }
    
        public string BankAccountNameAr { get; set; }
        public string BankAccountNameEn { get; set; }
        public string Notes { get; set; }

        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string ReceiptType { get; set; }
       
        public decimal Total { get; set; }
        public string LinesNotes { get; set; }
        public string CheckNumber { get; set; }
        public DateTime MaturityDate { get; set; }
        public string Bank { get; set; }
        public decimal CheckAmount { get; set; }
        public string AmountTafqeet { get; set; }
        public string DType { get; set; }
        public string BeneficentName { get; set; }
    }
}