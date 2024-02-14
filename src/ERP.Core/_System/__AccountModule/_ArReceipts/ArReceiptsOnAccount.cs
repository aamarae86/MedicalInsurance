using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModule._ArReceipts
{
    public class ArReceiptsOnAccount : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        public DateTime ApplyDate { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        [Required]
        public decimal Amount { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [Required]
        public long ReceiptTypeLkpId { get; protected set; }
        [ForeignKey(nameof(ReceiptTypeLkpId))]//, Column(Order = 0)]
        public FndLookupValues FndReceiptTypeLkp { get; protected set; }

        public long? SourceCodeLkpId { get; protected set; }

        public long? SourceId { get; protected set; }

        public long ReceiptId { get; protected set; }
        [ForeignKey(nameof(ReceiptId))]
        public ArReceipts ArReceipts { get; protected set; }
        public long? TenxMigrationId { get; set; }
        public int TenantId { get; set; }

    }
}
