using Abp.AutoMapper;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    [AutoMapTo(typeof(ScCommitteeMemberDetail))]
    public class ScCommitteeMemberDetailCreateDto
    {
        public int TenantId { get; set; }

        public long CommitteeId { get; set; }
        public long CommitteeMemberId { get; set; }
    }
}
