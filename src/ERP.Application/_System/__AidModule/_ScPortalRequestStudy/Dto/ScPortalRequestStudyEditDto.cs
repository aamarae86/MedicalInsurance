using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._ScPortalRequestStudyAttachment.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Parameters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScPortalRequestStudy.Dto
{
    [AutoMap(typeof(ScPortalRequestStudy))]
    public class ScPortalRequestStudyEditDto : CodeComUtility, IEntityDto<long>
    {
        public long Id { get; set; }

        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public long? AccountId { get; set; }

        public string StudyDate { get; set; }

        public int? NumberOfMonths { get; set; }

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

        public string DecisionInfo { get; set; }

        public long? OtherAidLkpId { get; set; }

        public int? OtherMonthNo { get; set; }

        public bool IsMedicine { get; set; }

        public List<ScPortalRequestStudyAttachmentDto> ListAttachments { get; set; }
    }
}
