using Abp.Domain.Entities;
using ERP._System.__Warehouses._IvReceiveHd;
using ERP._System._ApVendors;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._PoPurchaseOrder
{
    public class PoPurchaseOrderHd : PostAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        [MaxLength(20)]
        public string PurchaseOrderNumber { get; protected set; }

        [Required]
        public DateTime PurchaseOrderDate { get; protected set; }

        [Required]
        public long StatusLkpId { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupValuesStatusLkp { get; protected set; }

        [Required]
        public long VendorId { get; protected set; }

        [ForeignKey(nameof(VendorId))]
        public ApVendors Vendor { get; protected set; }

        [Required]
        public long IvWarehouseId { get; protected set; }

        [ForeignKey(nameof(IvWarehouseId))]
        public IvWarehouses Warehouses { get; protected set; }

        [MaxLength(4000)]
        public string ConditionsForOrdering { get; protected set; }

        public ICollection<PoPurchaseOrderTr> PoPurchaseOrderTrs { get; protected set; }

        public ICollection<IvReceiveHd> IvReceiveHd { get; protected set; }
    }
}
