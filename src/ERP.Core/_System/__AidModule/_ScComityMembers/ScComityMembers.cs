using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ScComityMembers
{
    public class ScComityMembers : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        [MaxLength(30)]
        public string MemberNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string MemberName { get; protected set; }

        public long MemberCategoryLkpId { get; protected set; }

        public bool IsActive { get; set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(MemberCategoryLkpId))]
        public FndLookupValues FndLookupValues { get; protected set; }
    }
}
