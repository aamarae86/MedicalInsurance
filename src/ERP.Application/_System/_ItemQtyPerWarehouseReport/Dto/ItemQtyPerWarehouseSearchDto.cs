using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ItemQtyPerWarehouseReport.Dto
{
    public class ItemQtyPerWarehouseSearchDto
    {
        public long? TrItemId { get; set; }
        public long? IvWarehouseId { get; set; }
        public string Lang { get; set; }
        public long TenantId { get; set; }

    }
}
