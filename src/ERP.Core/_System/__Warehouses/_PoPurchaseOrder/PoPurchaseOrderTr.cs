using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__Warehouses._IvReceiveHd._IvReceiveTr;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._PoPurchaseOrder
{
    public class PoPurchaseOrderTr : AuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public long PoPurchaseOrderId { get; protected set; }

        [ForeignKey(nameof(PoPurchaseOrderId))]
        public PoPurchaseOrderHd PurchaseOrder { get; protected set; }

        [Required]
        public long IvItemId { get; protected set; }

        [ForeignKey(nameof(IvItemId))]
        public IvItems Items { get; protected set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal QtyOrdered { get; protected set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal UnitPrice { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? ReceivedQty { get; protected set; }

        public DateTime? ReceivedDate { get; protected set; }

        public virtual ICollection<IvReceiveTr> IvReceiveTr { get; protected set; }
    }
}
