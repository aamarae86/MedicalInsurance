using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._IvReceiveHd._IvReceiveTr
{
    public class IvReceiveTr : AuditedEntity<long>, IMustHaveTenant
    {
        public long IvReceiveHdId { get; protected set; }

        public long IvItemId { get; protected set; }

        public long IvUnitId { get; protected set; }

        public long? PoPurchaseOrderTrId { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Qty { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal UnitPrice { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? TaxAmount { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(IvReceiveHdId))]
        public IvReceiveHd IvReceiveHd { get; protected set; }

        [ForeignKey(nameof(IvItemId))]
        public _IvItems.IvItems IvItems { get; protected set; }

        [ForeignKey(nameof(IvUnitId))]
        public _IvUnits.IvUnits IvUnits { get; protected set; }

        [ForeignKey(nameof(PoPurchaseOrderTrId))]
        public _PoPurchaseOrder.PoPurchaseOrderTr PoPurchaseOrderTr { get; protected set; }
    }
}
