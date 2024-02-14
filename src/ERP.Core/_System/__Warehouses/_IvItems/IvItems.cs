using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._IvAdjustmentHd._IvAdjustmentTr;
using ERP._System.__Warehouses._IvItemsTypesConfigure;
using ERP._System.__Warehouses._IvReceiveHd._IvReceiveTr;
using ERP._System.__Warehouses._IvUnits;
using ERP._System.__Warehouses._IvWarehouseItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ERP._System._FndLookupValues;
using ERP._System._FndTaxType;

namespace ERP._System.__Warehouses._IvItems
{
    public class IvItems : AuditedEntity<long>, IMustHaveTenant
    {
        public long? IvItemsTypesConfigureId { get; protected set; }
        [MaxLength(20)]
        public string ItemNumber { get; protected set; }
        [MaxLength(200)]
        public string ItemName { get; protected set; }
        [MaxLength(50)]
        public string ItemBarcode { get; protected set; }
        [MaxLength(30)]
        public string ItemRef1 { get; protected set; }
        [MaxLength(30)]
        public string ItemRef2 { get; protected set; }
        public long? IvUnitId { get; protected set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? ItemOrdQty { get; protected set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? ItemMaxStk { get; protected set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? ItemMinStk { get; protected set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? ItemQtys { get; protected set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? AvgCost { get; protected set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? LastCost { get; protected set; }
        public bool? IsItemObsolete { get; protected set; }
        public DateTime? ObsoleteDate { get; protected set; }
        public bool? IsDonationItem { get; protected set; }
        public int TenantId { get; set; }

        public long? FndTaxtypeId { get; protected set; }
        public long? TaxPercentageLkpId { get; protected set; }

        [ForeignKey(nameof(TaxPercentageLkpId))]
        public FndLookupValues FndLookupValues { get; protected set; }

        [ForeignKey(nameof(FndTaxtypeId))]
        public FndTaxType FndTaxType { get; protected set; }

        [ForeignKey(nameof(IvItemsTypesConfigureId))]
        public IvItemsTypesConfigure IvItemsTypesConfigure { get; protected set; }

        [ForeignKey(nameof(IvUnitId))]
        public IvUnits IvUnits { get; protected set; }

        public virtual ICollection<IvReceiveTr> IvReceiveTr { get; protected set; }

        public virtual ICollection<IvWarehouseItems> IvWarehouseItems { get; protected set; }

        public virtual ICollection<IvAdjustmentTr> IvAdjustmentTr { get; protected set; }

    }
}
