using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__CharityBoxes._TmCharityBoxCollect._TmCharityBoxCollectMembersDetail;
using ERP._System._FndLookupValues;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollectMembers
{
    public class TmCharityBoxCollectMembers : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        [MaxLength(30)]
        public string MemberNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string MemberName { get; protected set; }

        public long MemberCategoryLkpId { get; protected set; }

        [ForeignKey(nameof(MemberCategoryLkpId))]
        public FndLookupValues FndMemberCategoryValues { get; protected set; }

        public virtual ICollection<TmCharityBoxCollectMembersDetail> TmCharityBoxCollectMembersDetails { get; protected set; }

        public bool IsActive { get; set; }

        public int TenantId { get; set; }
    }
}
