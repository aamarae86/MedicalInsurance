using Abp.Application.Services.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScPortalRequestMgrDecision.Dto
{
    public class ScPRMgrDecisionElectronicAidDto : EntityDto<long>, IDetailRowStatus
    {
        public long ElectronicTypeLkpId { get; set; }

        public long ScPortalRequestMgrDecisionId { get; set; }

        public decimal Amount { get; set; }

        public string ElectronicTypeLkpNameAr { get; set; }

        public string ElectronicTypeLkpNameEn { get; set; }

        public string rowStatus { get; set; }
    }
}
