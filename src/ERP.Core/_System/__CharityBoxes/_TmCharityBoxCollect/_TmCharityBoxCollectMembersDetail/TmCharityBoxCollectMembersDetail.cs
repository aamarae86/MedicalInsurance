using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__CharityBoxes._TmCharityBoxCollectMembers;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollect._TmCharityBoxCollectMembersDetail
{
    public class TmCharityBoxCollectMembersDetail : AuditedEntity<long>, IMustHaveTenant
    {
        public long TmCharityBoxCollectId { get; protected set; }

        public long TmCharityBoxCollectMemberId { get; protected set; }

        [ForeignKey(nameof(TmCharityBoxCollectMemberId))]
        public TmCharityBoxCollectMembers TmCharityBoxCollectMembers { get; protected set; }

        [ForeignKey(nameof(TmCharityBoxCollectId))]
        public TmCharityBoxCollect TmCharityBoxCollect { get; protected set; }

        public int TenantId { get; set; }
    }
}
