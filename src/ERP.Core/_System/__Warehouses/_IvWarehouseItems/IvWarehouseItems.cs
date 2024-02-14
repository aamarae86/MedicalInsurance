using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._IvItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__Warehouses._IvWarehouseItems
{
    public class IvWarehouseItems : AuditedEntity<long>, IMustHaveTenant
    {
        public long? IvItemId { get;protected set; }
        public long? IvWarehouseId { get; protected set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? CurrentOnHand { get; protected set; }
        public int TenantId { get; set; }

        [ForeignKey(nameof(IvItemId))]
        public IvItems IvItems { get; protected set; }

        [ForeignKey(nameof(IvWarehouseId))]
        public IvWarehouses IvWarehouses { get; protected set; }
    }
}
