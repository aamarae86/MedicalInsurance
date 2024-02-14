using Abp.Application.Services.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScCommitteesCheck.Dto
{
    public class CommitteeRequestDataDto : EntityDto<long>, IDetailRowStatus
    {
        public decimal? AidAmount { get; set; }

        public string CashingTo { get; set; }

        public string IdNumber { get; set; }

        public string CheckNumber { get; set; }

        public string Name { get; set; }

        public long? CommitteeDetailsId { get; set; }

        public long? ScPortalRequestMgrDecisionId { get; set; }

        public string rowStatus { get; set; }
    }
}
