using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptPoPurchaseOrderScreenData
    {
        public string PurchaseOrderNumber { get; set; }
        public DateTime PurchaseOrderDate { get; set; }
        public decimal QtyOrdered { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public string NameAr { get; set; }
        public string WarehouseName { get; set; }
        public string ItemName { get; set; }
        public string ItemNumber { get; set; }
        public string VendorNameAr { get; set; }
    }
}