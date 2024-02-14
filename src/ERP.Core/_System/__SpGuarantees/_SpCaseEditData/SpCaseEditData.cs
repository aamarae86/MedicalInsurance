using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpCaseEditData
{
    public class SpCaseEditData : AuditedEntity<long>, IMustHaveTenant
    {
        public long? SpContractDetailsId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal OldAmount { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal NewAmount { get; protected set; }

        [MaxLength(200)]
        public string OldSponsFor { get; protected set; }

        [MaxLength(200)]
        public string NewSponsFor { get; protected set; }

        [MaxLength(50)]
        public string OldAccountNumber { get; protected set; }

        [MaxLength(50)]
        public string NewAccountNumber { get; protected set; }

        [MaxLength(200)]
        public string OldAccountOwnerName { get; protected set; }

        [MaxLength(200)]
        public string NewAccountOwnerName { get; protected set; }

        public long? OldBankLkpId { get; protected set; }

        public long? NewBankLkpId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }
        public int TenantId { get; set; }
    }
}
