using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__PmPropertiesModule._PmOwners
{
    public class PmOwnersTaxDetails : AuditedEntity<long>, IMustHaveTenant
    {
        public long PmOwnerId { get; protected set; }
        [ForeignKey(nameof(PmOwnerId))]
        public PmOwners PmOwner { get; protected set; }

        public long PmActivityTypeLkpId { get; protected set; }
        [ForeignKey(nameof(PmActivityTypeLkpId))]
        public FndLookupValues FndPmActivityTypeLkp { get; protected set; }

        [Range(0, 100)]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal TaxPercentage { get; protected set; }
        public int TenantId { get; set; }
    }
}
