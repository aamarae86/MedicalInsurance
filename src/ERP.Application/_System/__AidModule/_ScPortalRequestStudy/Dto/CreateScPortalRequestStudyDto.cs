using Abp.AutoMapper;
using ERP._System.__AidModule._ScPortalRequestStudyAttachment.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;

namespace ERP._System.__AidModule._ScPortalRequestStudy.Dto
{
    [AutoMap(typeof(ScPortalRequestStudy))]
    public class CreateScPortalRequestStudyDto : ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public long? AccountId { get; set; }

        public string StudyDate { get; set; }

        public string StudyNumber { get; set; }

        public int? NumberOfMonths { get; set; }

        public long? StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_ScPortalRequestStudyStatus);

        public string CashingTo { get; set; }

        public string StudyDetails { get; set; }

        public string ResearcherDecision { get; set; }

        public long? RefuseLkpId { get; set; }

        public string RefuseDescription { get; set; }

        public long? PortalRequestId { get; set; }

        public long? StudyLkpId { get; set; }

        public decimal? SuggestedAmount { get; set; }

        public long? OtherAidLkpId { get; set; }

        public int? OtherMonthNo { get; set; }

        public bool IsMedicine { get; set; }

        public List<ScPortalRequestStudyAttachmentDto> ListAttachments { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }
    }
}
