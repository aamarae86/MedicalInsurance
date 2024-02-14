using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptSalesScreenData
    {
        public string CustomerNameAr { get; set; }
        public string CustomerNameEn { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string ItemName { get; set; }
        public string SalesManNameAr { get; set; }
        public string SalesManNameEn { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal Net { get; set; }
        public long ItemId { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalItem { get; set; }
        public string LpoNo { get; set; }
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string TaxNo { get; set; }
        public string Address { get; set; }
        public string TaxPercentageNameAR { get; set; }
        public string TaxPercentageNameEN { get; set; }
        public string UnitName { get; set; }
        public string TaxRegNo { get; set; }
        public decimal TaxAmount { get; set; }
        public string NetTafqeet { get; set; }
        


    }
}