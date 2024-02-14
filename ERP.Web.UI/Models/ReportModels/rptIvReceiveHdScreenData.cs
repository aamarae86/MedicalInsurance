using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptIvReceiveHdScreenData
    {
        public string HdReceiveNumber { get; set; }
        public DateTime HdReceiveDate { get; set; }
        public decimal CurrencyRate { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string WarehouseName { get; set; }
        public string VendorNameAr { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string DescriptionAr { get; set; }
        public string StatusLkp { get; set; }
        public string TypeLkp { get; set; }
        public string ItemName { get; set; }
        public string ItemNumber { get; set; }
        public string UnitName { get; set; }
    }
}