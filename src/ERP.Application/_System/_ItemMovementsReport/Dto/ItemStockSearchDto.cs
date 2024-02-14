using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ItemMovementsReport.Dto
{
    public class ItemStockSearchDto
    {
        public string ShowZero { get; set; }
        public long? ItemId { get; set; }
        public long? IvWarehouseId { get; set; }
    }
}
