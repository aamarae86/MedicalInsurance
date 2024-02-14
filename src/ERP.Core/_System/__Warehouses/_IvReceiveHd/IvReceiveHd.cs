using Abp.Domain.Entities;
using ERP._System.__Warehouses._IvReceiveHd._IvReceiveTr;
using ERP._System.__Warehouses._PoPurchaseOrder;
using ERP._System._ApVendors;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._IvReceiveHd
{
    public class IvReceiveHd : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string HdReceiveNumber { get; protected set; }

        public DateTime HdReceiveDate { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal CurrencyRate { get; protected set; }

        [MaxLength(4000)]
        public string Comment { get; protected set; }

        public long IvWarehouseId { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public int CurrencyId { get; protected set; }

        public long VendorId { get; protected set; }

        //public long ReceiveTypeLkpId { get; protected set; }

        public long? PoPurchaseOrderHdId { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(IvWarehouseId))]
        public IvWarehouses IvWarehouses { get; protected set; }

        [ForeignKey(nameof(VendorId))]
        public ApVendors ApVendors { get; protected set; }

        [ForeignKey(nameof(PoPurchaseOrderHdId))]
        public PoPurchaseOrderHd PoPurchaseOrderHd { get; protected set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currencies.Currency Currency { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        //[ForeignKey(nameof(ReceiveTypeLkpId)), Column(Order = 1)]
        //public FndLookupValues FndReceiveTypeLkp { get; protected set; }

        public virtual ICollection<IvReceiveTr> IvReceiveTr { get; protected set; }
    }
}
