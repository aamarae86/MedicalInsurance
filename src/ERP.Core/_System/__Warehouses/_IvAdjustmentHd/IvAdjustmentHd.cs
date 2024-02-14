using Abp.Domain.Entities;
using ERP._System.__Warehouses._IvAdjustmentHd._IvAdjustmentTr;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._IvAdjustmentHd
{
    public class IvAdjustmentHd : PostAuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string AdjustmentNumber { get; protected set; }
        public DateTime? AdjustmentDate { get; protected set; }
        public long? StatusLkpId { get; protected set; }
        public long? AdjustmentTypeLkpId { get; protected set; }
        public long? IvWarehouseId { get; protected set; }
        [MaxLength(4000)]
        public string Notes { get; protected set; }
        public int TenantId { get; set; }

        [ForeignKey(nameof(AdjustmentTypeLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValuesAdjustmentTypeLkp { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesStatusLkpIvAdjustmentHd { get; protected set; }

        [ForeignKey(nameof(IvWarehouseId))]
        public IvWarehouses IvWarehouses { get; protected set; }

        public virtual ICollection<IvAdjustmentTr> IvAdjustmentTr { get; protected set; }
    }
}
