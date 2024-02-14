using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._IvItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__Warehouses._IvAdjustmentHd._IvAdjustmentTr
{
    public class IvAdjustmentTr : AuditedEntity<long>, IMustHaveTenant
    {
        public long? IvAdjustmentHdId { get;protected set; }
        public long? IvItemId { get;protected set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? CurrentQty { get;protected set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Qty { get; protected set; }
        public int TenantId { get ; set ; }

        [ForeignKey(nameof(IvItemId))]
        public IvItems IvItems { get; protected set; }

        [ForeignKey(nameof(IvAdjustmentHdId))]
        public IvAdjustmentHd IvAdjustmentHd { get; protected set; }
    }
}
