using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ItemQtyPerWarehouseReport.Dto
{
    public class ItemQtyPerWarehouseDto
    {
        public string ItemNumber { get; set; }
        public string ItemName { get; set; }
        public string ItemBarcode { get; set; }
        public decimal WareHouseQty { get; set; }
        public decimal TotQty { get; set; }
     
    }
}
