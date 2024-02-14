using ERP._System.__AidModule._ScPortalRequestStudyAttachment.Dto;
using ERP.Front.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScPortalRequestStudyVM : BasePostAuditedVM<long>, ICodeComUtilityIds, ICodeComUtilityTexts, IAttachmentListJSONString
    {
        public string EncId { get; set; }

        public bool IsMaintenance { get; set; }

        [Display(Name = nameof(ScPortalRequestStudy.AttachmentName), ResourceType = typeof(ScPortalRequestStudy))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string AttachmentName { get; set; }

        public string Status { get; set; }

        [Display(Name = nameof(ScPortalRequestStudy.ManagerRefuseResaon), ResourceType = typeof(ScPortalRequestStudy))]
        public string RefuseForUpdateReason { get; set; }

        [Display(Name = nameof(ScPortalRequestStudy.StudyDate), ResourceType = typeof(ScPortalRequestStudy))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string StudyDate { get; set; }

        [Display(Name = nameof(ScPortalRequestStudy.NoOfMonths), ResourceType = typeof(ScPortalRequestStudy))]
        public int? NumberOfMonths { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(ScPortalRequestStudy.StudyNumber), ResourceType = typeof(ScPortalRequestStudy))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string StudyNumber { get; set; }

        [Display(Name = nameof(ScPortalRequestStudy.StatusLkpId), ResourceType = typeof(ScPortalRequestStudy))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? StatusLkpId { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(ScPortalRequestStudy.CashingTo), ResourceType = typeof(ScPortalRequestStudy))]
        public string CashingTo { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ScPortalRequestStudy.StudyDetails), ResourceType = typeof(ScPortalRequestStudy))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string StudyDetails { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ScPortalRequestStudy.ResearcherDecision), ResourceType = typeof(ScPortalRequestStudy))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ResearcherDecision { get; set; }


        [Display(Name = nameof(ScPortalRequestStudy.RefuseLkpId), ResourceType = typeof(ScPortalRequestStudy))]
        public long? RefuseLkpId { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ScPortalRequestStudy.RefuseDescription), ResourceType = typeof(ScPortalRequestStudy))]
        public string RefuseDescription { get; set; }

        [Display(Name = nameof(ScPortalRequestStudy.PortalRequestId), ResourceType = typeof(ScPortalRequestStudy))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? PortalRequestId { get; set; }
        [Display(Name = nameof(ScPortalRequestStudy.StudyLkpId), ResourceType = typeof(ScPortalRequestStudy))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? StudyLkpId { get; set; }

        [Display(Name = nameof(ScCommittee.OtherCommittee), ResourceType = typeof(ScCommittee))]
        public long? OtherAidLkpId { get; set; }

        [Display(Name = nameof(ScCommittee.OtherCommitteeMonthNo), ResourceType = typeof(ScCommittee))]
        public int? OtherMonthNo { get; set; }

        [Display(Name = nameof(ScCommittee.IsMedicine), ResourceType = typeof(ScCommittee))]
        public bool IsMedicine { get; set; }

        [Display(Name = nameof(ScCommittee.IsMedicine), ResourceType = typeof(ScCommittee))]
        public bool IsMedicineAlt { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        [Display(Name = nameof(ScPortalRequestStudy.CaseName), ResourceType = typeof(ScPortalRequestStudy))]
        public string CaseName { get; set; }

        [Display(Name = nameof(ScPortalRequestStudy.ResearcherName), ResourceType = typeof(ScPortalRequestStudy))]
        public string ResearcherName { get; set; }

        [Display(Name = nameof(ScPortalRequestStudy.SuggestedAmount), ResourceType = typeof(ScPortalRequestStudy))]
        public decimal? SuggestedAmount { get; set; }

        public FndLookupValuesVM FndLookupValuesStatusLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesRefuseLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesStudyLkp { get; set; }

        public ScPortalRequestsVM ScPortalRequest { get; set; }

        public FndLookupValuesVM FndOtherAidLkp { get; set; }

        public string AttachmentsListStr { get; set; }

        public ICollection<ScPortalRequestStudyAttachmentDto> ListAttachments => string.IsNullOrEmpty(AttachmentsListStr) ?
                new List<ScPortalRequestStudyAttachmentDto>() : Helper<List<ScPortalRequestStudyAttachmentDto>>.Convert(AttachmentsListStr);

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }


        [Display(Name = nameof(ScPortalRequestStudy.DecisionInfo), ResourceType = typeof(ScPortalRequestStudy))]
        public string DecisionInfo { get; set; }

    }
}