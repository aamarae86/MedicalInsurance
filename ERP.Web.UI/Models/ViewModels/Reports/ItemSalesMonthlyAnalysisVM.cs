using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Reports
{
    public class ItemSalesMonthlyAnalysisVM
    {
        public long Id { get; set; }
        public string ItemNumber { get; set; }
        public string ItemName { get; set; }
        public decimal? JanuarySale { get; set; }
        public decimal? JanuaryValue { get; set; }
        public decimal? FebruarySale { get; set; }
        public decimal? FebruaryValue { get; set; }
        public decimal? MarchSale { get; set; }
        public decimal? MarchValue { get; set; }
        public decimal? AprilSale { get; set; }
        public decimal? AprilValue { get; set; }
        public decimal? MaySale { get; set; }
        public decimal? MayValue { get; set; }
        public decimal? JunSale { get; set; }
        public decimal? JunValue { get; set; }
        public decimal? JulSale { get; set; }
        public decimal? JulValue { get; set; }
        public decimal? AugustSale { get; set; }
        public decimal? AugustValue { get; set; }
        public decimal? SeptemberSale { get; set; }
        public decimal? SeptemberValue { get; set; }
        public decimal? OctoberSale { get; set; }
        public decimal? OctoberValue { get; set; }
        public decimal? NovemberSale { get; set; }
        public decimal? NovemberValue { get; set; }
        public decimal? DecemberSale { get; set; }
        public decimal? DecemberValue { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal? MarchTotal { get; set; }
        public decimal? JanTotal { get; set; }
        public decimal? FebTotal { get; set; }
        public decimal? AprilTotal { get; set; }
        public decimal? MayTotal { get; set; }
        public decimal? JunTotal { get; set; }
        public decimal? JulyTotal { get; set; }
        public decimal? AugTotal { get; set; }
        public decimal? SepTotal { get; set; }
        public decimal? OctTotal { get; set; }
        public decimal? NovTotal { get; set; }
        public decimal? DecTotal { get; set; }
        public decimal? GrandTotal { get; set; }

    }
}