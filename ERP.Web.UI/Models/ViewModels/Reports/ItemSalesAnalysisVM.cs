using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Reports
{
    public class ItemSalesAnalysisVM
    {
        public long Id { get; set; }
        public string Serial { get; set; }
        public string ItemNumber { get; set; }
        public string ItemName { get; set; }
        public decimal? TotalQtySold { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? NetProfit { get; set; }
        public decimal? GTotalValue { get; set; }
        public decimal? GTotalCost { get; set; }
        public decimal? TotalProfit { get; set; }
    }
}