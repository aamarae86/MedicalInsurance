using ERP.Helpers.Core.__PostAudited;
using System;

namespace ERP._System.__Warehouses._PoPurchaseOrder.Dto
{
    public class PoPurchaseOrderBaseDto : PostAuditedEntityDto<long>
    {
        public string PurchaseOrderDate { get; set; }

        public long StatusLkpId { get; set; }

        public long VendorId { get; set; }

        public long IvWarehouseId { get; set; }

        public string ConditionsForOrdering { get; set; }

    }
}
