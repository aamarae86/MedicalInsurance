using System.Collections.Generic;

namespace ERP._System.__Warehouses._PoPurchaseOrder.Dto
{
    public class PoPurchaseOrderDto : PoPurchaseOrderBaseDto
    {
        public string PurchaseOrderNumber { get; set; }

        public string StatusAr { get; set; }
        public string StatusEn { get; set; }

        public string VendorNameAr { get; set; }
        public string VendorNameEn { get; set; }
        public string VendorNumber { get; set; }

        public string IvWarehouseName { get; set; }
        public string IvWarehouseNumber { get; set; }

        public ICollection<PoPurchaseOrderDetailsDto> PoPurchaseOrderTrs { get; set; }
    }
}
