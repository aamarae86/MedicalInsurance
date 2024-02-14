using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__Warehouses._IvReceiveHd._IvReceiveTr;
using ERP._System.__Warehouses._IvUnits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._IvStoreIssue
{
    public class IvStoreIssueTr : AuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public long IvStoreIssueHdId { get; protected set; }

        [ForeignKey(nameof(IvStoreIssueHdId))]
        public IvStoreIssueHd StoreIssue { get; protected set; }

        [Required]
        public long IvItemId { get; protected set; }

        [ForeignKey(nameof(IvItemId))]
        public IvItems Items { get; protected set; }

        [Required]
        public long IvUnitId { get; protected set; }

        [ForeignKey(nameof(IvUnitId))]
        public IvUnits Units { get; protected set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Qty { get; protected set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal AvgCost { get; protected set; }
    }
}
