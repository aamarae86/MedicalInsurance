using Abp.Application.Services.Dto;
using ERP.Helpers.Core.__PostAudited;
using System;

namespace ERP._System.__SpGuarantees._SpCases.Dto
{
    public class SpCasesBaseDto : PostAuditedEntityDto<long>
    {
        public string CaseName { get; set; }
        public string RegistrationDate { get; set; }
        public string BirthDate { get; set; }
        public string PlaceOfBirth { get; set; }
        public long? NationalityLkpId { get; set; }
        public long? MaritalStatusLkpId { get; set; }
        public long? StatusLkpId { get; set; }
        public long? HealthStatusLkpId { get; set; }
        public string TypeOfDisease { get; set; }
        public string TypeOfTreatment { get; set; }
        public string DescriptionOfHealthCondition { get; set; }
        public bool? IsStudy { get; set; }
        public string SchoolUniversityName { get; set; }
        public long? EducationalLevelLkpId { get; set; }
        public long? EducationalStageLkpId { get; set; }
        public decimal? MonthlyInstallment { get; set; }
        public string SupervisorComments { get; set; }
        public string Casephoto { get; set; }
        public long? SponsorCategoryLkpId { get; set; }
        public string IdNumber { get; set; }
        public string IdExpirationDate { get; set; }
        public long? GenderLkpId { get; set; }

        public string base64Str { get; set; }

        public string fileExt { get; set; }
    }
}
