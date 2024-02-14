using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScDeliveryOtherAids.Dto
{
    [AutoMap(typeof(ScDeliveryOtherAidDetails))]
    public class ScDeliveryOtherAidDetailsDto : EntityDto<long>, IDetailRowStatus
    {
        public long ScDeliveryOtherAidsId { get; set; }

        public long? CommitteeDetailsId { get; set; }

        public long? ScPortalRequestMgrDecisionId { get; set; }

        public string Name { get; set; }

        public string IdNumber { get; set; }

        public string AidAmountAr { get; set; }

        public string AidAmountEn { get; set; }

        public string CashingTo { get; set; }

        public string rowStatus { get; set; }
    }
}
