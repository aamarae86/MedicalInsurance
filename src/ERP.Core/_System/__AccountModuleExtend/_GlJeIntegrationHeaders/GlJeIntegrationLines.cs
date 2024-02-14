using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._ApVendors;
using ERP._System._ArCustomers;
using ERP._System._FndLookupValues;
using ERP._System._GlCodeComDetails;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders
{
    public class GlJeIntegrationLines : AuditedEntity<long>, IMustHaveTenant
    {
        [Column(TypeName = "decimal(18,6)")]
        public decimal DebitAmount { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal CreditAmount { get; protected set; }

        public long GlJeIntegrationHeaderId { get; protected set; }

        [ForeignKey(nameof(GlJeIntegrationHeaderId))]
        public GlJeIntegrationHeaders GlJeIntegrationHeaders { get; protected set; }

        public long JeIntegrationLineTypeLkpId { get; protected set; }

        [ForeignKey(nameof(JeIntegrationLineTypeLkpId))]
        public FndLookupValues FndJeIntegrationLineTypeLkp { get; protected set; }

        public long AccountId { get; protected set; }

        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        public long? ArCustomerId { get; protected set; }

        [ForeignKey(nameof(ArCustomerId))]
        public ArCustomers ArCustomers { get; protected set; }

        public long? ApVendorId { get; protected set; }

        [ForeignKey(nameof(ApVendorId))]
        public ApVendors ApVendors { get; protected set; }

        [MaxLength(4000)]
        public string JeIntegrationLineNotes { get; protected set; }

        public bool IsSettled { get; set; }

        public long? TenxMigrationId { get; set; }

        public int TenantId { get; set; }

        [NotMapped]
        public string Lang { get; set; }
    }
}
