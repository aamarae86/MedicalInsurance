using System;

namespace ERP._System.__Warehouses._PoPurchaseOrder.Dto
{
    public class PoPurchaseOrderSearchDto
    {
        public string PurchaseOrderDate { get; set; }
        public string OrderNumber { get; set; }
        public long? VendorId { get; set; }
        public long? IvWarehouseId { get; set; }
        public long? StatusId { get; set; }
        public override string ToString()
        {
            return $"Params.OrderNumber={OrderNumber}&Params.VendorId={VendorId}&Params.StatusId={StatusId}&Params.IvWarehouseId={IvWarehouseId}&Params.PurchaseOrderDate={PurchaseOrderDate}";
        }
    }
}
