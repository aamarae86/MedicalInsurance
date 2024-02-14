using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._ScComityMembers;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScCommittee
{
    public class ScCommitteeMemberDetail : AuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public long CommitteeId { get; protected set; }
        public long CommitteeMemberId { get; protected set; }

        [ForeignKey(nameof(CommitteeId))]
        public ScCommittee Committee { get; protected set; }

        [ForeignKey(nameof(CommitteeMemberId))]
        public ScComityMembers Member { get; protected set; }

    }
}
