using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SalesModule._ItemSalesAnalysis.ProcDto
{
   public class ItemSalesAnalysisOutput
    {
        public long Id { get; set; }
        public string Serial { get; set; }
        public string ItemNumber { get; set; }
        public string ItemName { get; set; }
        public decimal? TotalQtySold { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? NetProfit { get; set; }
    }
}
