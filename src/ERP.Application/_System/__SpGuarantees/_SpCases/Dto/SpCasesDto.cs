using Abp.AutoMapper;
using System.Collections.Generic;

namespace ERP._System.__SpGuarantees._SpCases.Dto
{
    [AutoMapFrom(typeof(SpCases))]
    public class SpCasesDto : SpCasesBaseDto
    {
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
        public string RelativesTypeEn { get; set; }
        public string RelativesTypeAr { get; set; }
        public string FamilyNumber { get; set; }
        public string FamilyName { get; set; }
        public string GuardianName { get; set; }
        public string SpContractNumber { get; set; }
        public string SpBeneficentName { get; set; }

        public virtual ICollection<SpCasesAttachmentsDto> SpCasesAttachments { get; set; }
    }
}
