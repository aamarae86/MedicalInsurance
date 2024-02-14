using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SalesModule.ArInvoiceSettlement
{
    public class ArInvoiceSettlementDr : AuditedEntity<long>, IMustHaveTenant
    {
        public long ArInvoiceSettlementHdId { get; set; }
        public long SourceLkpId { get; set; }
        public long SourceId { get; set; }
        public int TenantId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal Amount { get; set; }

        [ForeignKey(nameof(ArInvoiceSettlementHdId))]
        public ArInvoiceSettlementHd ArInvoiceSettlementHd { get; set; }
    }
}
