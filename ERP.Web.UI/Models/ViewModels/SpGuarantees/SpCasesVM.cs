using ERP._System.__SpGuarantees._SpCases.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.SpGuarantees;
using ERP.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.SpGuarantees
{
    public class SpCasesVM : BasePostAuditedVM<long>, IAttachmentListJSONString
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [Display(Name = nameof(SpContracts.SpBeneficentId), ResourceType = typeof(SpContracts))]
        public long SpBeneficentId { get; set; }

        #region Attachments
        [Display(Name = nameof(SpCases.AttachmentName), ResourceType = typeof(SpCases))]
        public string Attachment_Name { get; set; }
        #endregion

        #region Search Params
        [Display(Name = nameof(SpCases.CaseNumber), ResourceType = typeof(SpCases))]
        public string Search_CaseNumber { get; set; }
        [Display(Name = nameof(SpCases.CaseName), ResourceType = typeof(SpCases))]
        public long? Search_CaseName { get; set; }
        [Display(Name = nameof(SpCases.SponsorCategoryLkpId), ResourceType = typeof(SpCases))]
        public long? Search_SponsorCategoryId { get; set; }
        [Display(Name = nameof(SpCases.NationalityLkpId), ResourceType = typeof(SpCases))]
        public long? Search_NationalityId { get; set; }
        [Display(Name = nameof(SpCases.SpFamilyNumber), ResourceType = typeof(SpCases))]
        public string Search_FamilyNumber { get; set; }
        [Display(Name = nameof(SpCases.SpFamilyId), ResourceType = typeof(SpCases))]
        public long? Search_FamilyName { get; set; }
        [Display(Name = nameof(SpCases.StatusLkpId), ResourceType = typeof(SpCases))]
        public long? Search_StatusId { get; set; }

        [Display(Name = nameof(SpCases.RegistrationDate), ResourceType = typeof(SpCases))]
        public string Search_RegistrationDate { get; set; }

        #endregion

        #region Base
        [Display(Name = nameof(SpCases.CaseName), ResourceType = typeof(SpCases))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string CaseName { get; set; }
        [Display(Name = nameof(SpCases.RegistrationDate), ResourceType = typeof(SpCases))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string RegistrationDate { get; set; }

        [Display(Name = nameof(SpCases.BirthDate), ResourceType = typeof(SpCases))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string BirthDate { get; set; }

        [Display(Name = nameof(SpCases.PlaceOfBirth), ResourceType = typeof(SpCases))]
        public string PlaceOfBirth { get; set; }

        [Display(Name = nameof(SpCases.NationalityLkpId), ResourceType = typeof(SpCases))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? NationalityLkpId { get; set; }
        [Display(Name = nameof(SpCases.MaritalStatusLkpId), ResourceType = typeof(SpCases))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? MaritalStatusLkpId { get; set; }
        [Display(Name = nameof(SpCases.StatusLkpId), ResourceType = typeof(SpCases))]
        public long? StatusLkpId { get; set; }
        [Display(Name = nameof(SpCases.SpFamilyId), ResourceType = typeof(SpCases))]
        public long? SpFamilyId { get; set; }
        [Display(Name = nameof(SpCases.HealthStatusLkpId), ResourceType = typeof(SpCases))]
        public long? HealthStatusLkpId { get; set; }
        [Display(Name = nameof(SpCases.TypeOfDisease), ResourceType = typeof(SpCases))]
        public string TypeOfDisease { get; set; }
        [Display(Name = nameof(SpCases.TypeOfTreatment), ResourceType = typeof(SpCases))]
        public string TypeOfTreatment { get; set; }
        [Display(Name = nameof(SpCases.DescriptionOfHealthCondition), ResourceType = typeof(SpCases))]
        public string DescriptionOfHealthCondition { get; set; }
        [Display(Name = nameof(SpCases.IsStudy), ResourceType = typeof(SpCases))]
        public bool? IsStudy { get; set; }
        [Display(Name = nameof(SpCases.IsStudy), ResourceType = typeof(SpCases))]
        public bool? IsStudyAlt { get; set; }
        [Display(Name = nameof(SpCases.SchoolUniversityName), ResourceType = typeof(SpCases))]
        public string SchoolUniversityName { get; set; }
        [Display(Name = nameof(SpCases.EducationalLevelLkpId), ResourceType = typeof(SpCases))]
        public long? EducationalLevelLkpId { get; set; }
        [Display(Name = nameof(SpCases.EducationalStageLkpId), ResourceType = typeof(SpCases))]
        public long? EducationalStageLkpId { get; set; }
        [Display(Name = nameof(SpCases.MonthlyInstallment), ResourceType = typeof(SpCases))]
        public decimal? MonthlyInstallment { get; set; }
        [Display(Name = nameof(SpCases.SupervisorComments), ResourceType = typeof(SpCases))]
        public string SupervisorComments { get; set; }
        [Display(Name = nameof(SpCases.CasePhoto), ResourceType = typeof(SpCases))]
        public string Casephoto { get; set; }
        [Display(Name = nameof(SpCases.SponsorCategoryLkpId), ResourceType = typeof(SpCases))]
        public long? SponsorCategoryLkpId { get; set; }
        [Display(Name = nameof(SpCases.IdNumber), ResourceType = typeof(SpCases))]
        public string IdNumber { get; set; }

        [Display(Name = nameof(SpCases.IdExpirationDate), ResourceType = typeof(SpCases))]
        public string IdExpirationDate { get; set; }

        [Display(Name = nameof(SpCases.GenderLkpId), ResourceType = typeof(SpCases))]
        public long? GenderLkpId { get; set; }

        public long? SpContractDetailsId { get; set; }
        #endregion

        [Display(Name = nameof(SpCases.CaseNumber), ResourceType = typeof(SpCases))]
        public string CaseNumber { get; set; }
        public string NationalityEn { get; set; }
        public string NationalityAr { get; set; }
        public string MaritalStatusEn { get; set; }
        public string MaritalStatusAr { get; set; }
        public string StatusEn { get; set; }
        public string StatusAr { get; set; }
        public string HealthStatusEn { get; set; }
        public string HealthStatusAr { get; set; }
        public string EducationalLevelEn { get; set; }
        public string EducationalLevelAr { get; set; }
        public string EducationalStageEn { get; set; }
        public string EducationalStageAr { get; set; }
        public string SponsorCategoryEn { get; set; }
        public string SponsorCategoryAr { get; set; }
        public string GenderEn { get; set; }
        public string GenderAr { get; set; }
        [Display(Name = nameof(SpCases.RelativesTypeLkpId), ResourceType = typeof(SpCases))]
        public string RelativesTypeEn { get; set; }
        [Display(Name = nameof(SpCases.RelativesTypeLkpId), ResourceType = typeof(SpCases))]
        public string RelativesTypeAr { get; set; }
        [Display(Name = nameof(SpCases.SpFamilyNumber), ResourceType = typeof(SpCases))]
        public string FamilyNumber { get; set; }
        [Display(Name = nameof(SpCases.SpFamilyId), ResourceType = typeof(SpCases))]
        public string FamilyName { get; set; }
        [Display(Name = nameof(SpCases.GuardianName), ResourceType = typeof(SpCases))]
        public string GuardianName { get; set; }

        public string SpContractNumber { get; set; }
        public string SpBeneficentName { get; set; }

        public string AttachmentsListStr { get; set; }

        public ICollection<SpCasesAttachmentsDto> ListOfAttachments => string.IsNullOrEmpty(AttachmentsListStr) ?
                 new List<SpCasesAttachmentsDto>() : Helper<List<SpCasesAttachmentsDto>>.Convert(AttachmentsListStr);

    }
}