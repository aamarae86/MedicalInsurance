using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class GetTaxReportDataOutputHelper 
    {
        public string SourceName { get; set; }
        public string TransNo { get; set; }
        public string VendorName { get; set; }
        public string TaxNo { get; set; }
        public string CostCenter { get; set; }
        public string Notes { get; set; }
        public decimal TaxFivePer { get; set; }

        public decimal OtherTaxPer { get; set; }
        public decimal TaxVal { get; set; }
        public decimal TotalVal { get; set; }
        public decimal TaxAmount { get; set; }
        public int AcountId { get; set; }
        public DateTime TransDate { get; set; }
    }
}