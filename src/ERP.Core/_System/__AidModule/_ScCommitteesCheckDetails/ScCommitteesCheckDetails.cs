using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScCommitteesCheck;
using ERP._System.__AidModule._ScPortalRequestMgrDecision;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScCommitteesCheckDetails
{
    public class ScCommitteesCheckDetails : AuditedEntity<long>, IMustHaveTenant
    {
        public long? CommitteeDetailsId { get; protected set; }

        public long? CommitteesCheckId { get; protected set; }

        public long? ScPortalRequestMgrDecisionId { get; protected set; }

        [MaxLength(30)]
        public string CheckNumber { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(CommitteesCheckId))]
        public ScCommitteesCheck ScCommitteesCheck { get; protected set; }

        [ForeignKey(nameof(CommitteeDetailsId))]
        public ScCommitteeDetail ScCommitteeDetail { get; protected set; }

        [ForeignKey(nameof(ScPortalRequestMgrDecisionId))]
        public ScPortalRequestMgrDecision ScPortalRequestMgrDecision { get; protected set; }
    }
}
