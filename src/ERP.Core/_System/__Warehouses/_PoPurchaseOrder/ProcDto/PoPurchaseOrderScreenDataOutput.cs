using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._PoPurchaseOrder.ProcDto
{
    public class PoPurchaseOrderScreenDataOutput
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
