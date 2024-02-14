using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System.__AidModule._ScCommitteesCheckDetails.Dto
{
    [AutoMap(typeof(ScCommitteesCheckDetails))]
    public class ScCommitteesCheckDetailsDto : EntityDto<long>
    {
        public long? CommitteeDetailsId { get; set; }

        public long? ScPortalRequestMgrDecisionId { get; set; }

        public long? CommitteesCheckId { get; set; }

        public string CheckNumber { get; set; }

        public string rowStatus { get; set; }

    }
}
