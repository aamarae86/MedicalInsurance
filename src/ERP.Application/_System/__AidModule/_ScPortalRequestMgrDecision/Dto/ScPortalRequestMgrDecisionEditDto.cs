using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._ScPortalRequestStudy.Dto;
using ERP.Helpers.Parameters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScPortalRequestMgrDecision.Dto
{
    [AutoMap(typeof(ScPortalRequestMgrDecision))]
    public class ScPortalRequestMgrDecisionEditDto : EntityDto<long>, ICodeComUtilityTexts
    {
        public string DecisionDate { get; set; }

        public long? StatusLkpId { get; set; }

        public decimal? Amount { get; set; }

        public long? OtherAidLkpId { get; set; }

        public int? OtherMonthNo { get; set; }

        public bool IsMedicine { get; set; }

        public int? NumberOfMonths { get; set; }

        [MaxLength(200)]
        public string CashingTo { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long? RefuseLkpId { get; set; }

        [MaxLength(4000)]
        public string RefuseDescription { get; set; }

        public long? PortalRequestStudyId { get; set; }

        public string codeComUtilityTexts { get; set; }

        public ScPortalRequestStudyDto ScPortalRequestStudy { get; set; }

        public virtual ICollection<ScPRMgrDecisionElectronicAidDto> MgrDecisionElectronicAids { get; set; }

    }
}
