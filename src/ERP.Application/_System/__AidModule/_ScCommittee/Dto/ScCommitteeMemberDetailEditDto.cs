using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    [AutoMap(typeof(ScCommitteeMemberDetail))]
    public class ScCommitteeMemberDetailEditDto : EntityDto<long>, IDetailRowStatus
    {
        //public int TenantId { get; set; }

        public long CommitteeId { get; set; }

        public long CommitteeMemberId { get; set; }

        public string rowStatus { get; set; }
    }
}
