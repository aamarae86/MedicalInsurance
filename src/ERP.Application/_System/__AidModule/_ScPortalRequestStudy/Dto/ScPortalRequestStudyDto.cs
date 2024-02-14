using Abp.AutoMapper;
using ERP._System.__AidModule._ScPortalRequest.Dto;
using ERP._System.__AidModule._ScPortalRequestStudyAttachment.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using ERP.Helpers.Parameters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScPortalRequestStudy.Dto
{
    [AutoMap(typeof(ScPortalRequestStudy))]
    public class ScPortalRequestStudyDto : PostAuditedEntityDto<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public long? AccountId { get; set; }

        public string StudyDate { get; set; }

        [MaxLength(30)]
        public string StudyNumber { get; set; }

        public long? StatusLkpId { get; set; }

        public int? NumberOfMonths { get; set; }

        public string RefuseForUpdateReason { get; set; }

        [MaxLength(200)]
        public string CashingTo { get; set; }

        [MaxLength(4000)]
        public string StudyDetails { get; set; }

        [MaxLength(4000)]
        public string ResearcherDecision { get; set; }

        public string CaseName { get; set; }

        public string ResearcherName { get; set; }

        public long? RefuseLkpId { get; set; }

        [MaxLength(4000)]
        public string RefuseDescription { get; set; }

        public long? PortalRequestId { get; set; }

        public long? StudyLkpId { get; set; }

        public decimal? SuggestedAmount { get; set; }

        public long? OtherAidLkpId { get; set; }

        public int? OtherMonthNo { get; set; }

        public bool IsMedicine { get; set; }

        public bool IsMaintenance { get; set; }

        public FndLookupValuesDto FndLookupValuesStatusLkp { get; set; }

        public FndLookupValuesDto FndLookupValuesRefuseLkp { get; set; }

        public FndLookupValuesDto FndLookupValuesStudyLkp { get; set; }

        public FndLookupValuesDto FndOtherAidLkp { get; set; }

        public ScPortalRequestDto ScPortalRequest { get; set; }

        public GlCodeComDetails GlCodeComDetails { get; set; }

        public List<ScPortalRequestStudyAttachmentDto> ListAttachments { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }

        public string DecisionInfo { get; set; }
    }
}
