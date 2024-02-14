using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScCommittee
{
    public class ScCommitteeDetailsElectronicAid : AuditedEntity<long>, IMustHaveTenant
    {
        public long ElectronicTypeLkpId { get; protected set; }

        public long ScCommitteeDetailsId { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? Amount { get; protected set; }

        [ForeignKey(nameof(ScCommitteeDetailsId))]
        public ScCommitteeDetail ScCommitteeDetail { get; protected set; }

        [ForeignKey(nameof(ElectronicTypeLkpId))]
        public FndLookupValues FndElectronicTypeLkp { get; protected set; }

        public int TenantId { get; set; }
    }
}
