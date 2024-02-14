using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._ApBanks;
using ERP._System._FndLookupValues;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModule._ArReceipts
{
    public class ArReceiptDetails : AuditedEntity<long>, IMustHaveTenant
    {
            public long ReceiptId { get; protected set; }
            [ForeignKey(nameof(ReceiptId))]
            public ArReceipts ArReceipts { get; protected set; }

            [Required]
            [MaxLength(30)]
            public string CheckNumber { get; protected set; }

            [Required]
            public DateTime MaturityDate { get; protected set; }

            [Required]
            [Column(TypeName = "decimal(18, 6)")]
            public decimal? Amount { get; protected set; }
   
            [MaxLength(4000)]
            public string Notes { get; protected set; }
      
            [Required]
            public long BankLkpId { get; protected set; }
            [ForeignKey(nameof(BankLkpId))]
            public FndLookupValues Bank { get; protected set; }

            public long? SourceCodeLkpId { get; protected set; }
        
            public long? SourceId { get; protected set; }
        public long? TenxMigrationId { get; set; }

        public int TenantId { get; set; }
    }
}
