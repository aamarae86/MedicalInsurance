using Abp.AutoMapper;
using ERP._System.__AidModule._ScPortalRequestStudy.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using ERP.Helpers.Parameters;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScPortalRequestMgrDecision.Dto
{
    [AutoMap(typeof(ScPortalRequestMgrDecision))]
    public class ScPortalRequestMgrDecisionDto : PostAuditedEntityDto<long>, ICodeComUtilityTexts
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string DecisionDate { get; set; }

        public long? StatusLkpId { get; set; }

        public decimal? Amount { get; set; }

        public long? OtherAidLkpId { get; set; }

        public int? OtherMonthNo { get; set; }

        public bool IsMedicine { get; set; }

        public int? NumberOfMonths { get; set; }

        [MaxLength(4000)]
        public string RefuseForUpdateReason { get; set; }

        [MaxLength(200)]
        public string CashingTo { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long? RefuseLkpId { get; set; }

        [MaxLength(4000)]
        public string RefuseDescription { get; set; }

        public long? PortalRequestStudyId { get; set; }

        [MaxLength(30)]
        public string DecisionNumer { get; set; }

        public int TenantId { get; set; }

        public string codeComUtilityTexts { get; set; }

        public bool IsElectronic { get; set; }

        public FndLookupValuesDto FndLookupValuesStatusLkpId { get; set; }

        public FndLookupValuesDto FndLookupValuesRefuseLkpId { get; set; }

        public FndLookupValuesDto FndOtherAidLkp { get; set; }

        public ScPortalRequestStudyDto ScPortalRequestStudy { get; set; }

    }
}
