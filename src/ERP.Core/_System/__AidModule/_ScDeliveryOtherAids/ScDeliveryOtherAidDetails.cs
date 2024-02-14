using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScPortalRequestMgrDecision;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScDeliveryOtherAids
{
    public class ScDeliveryOtherAidDetails : AuditedEntity<long>, IMustHaveTenant
    {
        public long ScDeliveryOtherAidsId { get; protected set; }

        public long? CommitteeDetailsId { get; protected set; }

        public long? ScPortalRequestMgrDecisionId { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(ScDeliveryOtherAidsId))]
        public ScDeliveryOtherAids ScDeliveryOtherAids { get; protected set; }

        [ForeignKey(nameof(CommitteeDetailsId))]
        public ScCommitteeDetail ScCommitteeDetail { get; protected set; }

        [ForeignKey(nameof(ScPortalRequestMgrDecisionId))]
        public ScPortalRequestMgrDecision ScPortalRequestMgrDecision { get; protected set; }
    }
}
