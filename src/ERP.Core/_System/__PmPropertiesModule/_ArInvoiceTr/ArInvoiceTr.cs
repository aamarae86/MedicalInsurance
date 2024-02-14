using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System._GlCodeComDetails;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__PmPropertiesModule._ArInvoiceTr
{
    public class ArInvoiceTr : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(4000)]
        public string Description { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Amount { get;protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? TaxPercent { get;protected set; }

        public long? ArInvoiceHdId { get;protected set; }

        public long? AccountId { get;protected set; }

        public int TenantId { get ; set ; }

        [ForeignKey(nameof(ArInvoiceHdId))]
        public ArInvoiceHd ArInvoiceHd { get; protected set; }

        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }
        public long? TenxMigrationId { get; set; }
    }
}
