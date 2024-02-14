using Abp.Application.Services.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Users.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._PortalUserUnified.Dto
{
    public class PortalUserUnifiedBaseDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public string LastModificationUser { get; set; }

        public string Source { get; set; }

        public string SourceCreatorName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string Region { get; set; }

        [Required]
        [MaxLength(50)]
        public string MobileNumber1 { get; set; }

        [MaxLength(50)]
        public string MobileNumber2 { get; set; }

        public string BirthDate { get; set; }

        public string IdExpirationDate { get; set; }

        public string PassportExpiryDate { get; set; }

        public string PassportIssueDate { get; set; }

        public string ResidenceEndDate { get; set; }

        [MaxLength(100)]
        public string PassportNumber { get; set; }

        [MaxLength(100)]
        public string UnifiedNumber { get; set; }

        [MaxLength(200)]
        public string Job { get; set; }

        [MaxLength(200)]
        public string JobDescription { get; set; }

        [MaxLength(4000)]
        public string Address { get; set; }

        public long MaritalStatusLkpId { get; set; }

        public long GenderLkpId { get; set; }

        public long CityLkpId { get; set; }

        public long? CaseCategoryLkpId { get; set; }

        public long? QualificationLkpId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string IdNumber { get; set; }

        [MaxLength(30)]
        public string CaseNumber { get; set; }

        [MaxLength(200)]
        public string WifeHusbandName1 { get; set; }

        [MaxLength(50)]
        public string IdNumberWifeHusband1 { get; set; }

        [MaxLength(200)]
        public string JobWifeHusband1 { get; set; }

        [MaxLength(200)]
        public string WifeName2 { get; set; }

        [MaxLength(50)]
        public string IdNumberWife2 { get; set; }

        [MaxLength(200)]
        public string WifeName3 { get; set; }

        [MaxLength(50)]
        public string IdNumberWife3 { get; set; }

        [MaxLength(200)]
        public string WifeName4 { get; set; }

        [MaxLength(50)]
        public string IdNumberWife4 { get; set; }

        [MaxLength(200)]
        public string JobWife2 { get; set; }

        [MaxLength(200)]
        public string JobWife3 { get; set; }

        [MaxLength(200)]
        public string JobWife4 { get; set; }

        public long NationalityLkpId { get; set; }

        public int? TenantCreatorId { get; set; }

        public long? UserId { get; set; }

        public FndLookupValuesDto GenderFndLookupValues { get; set; }

        public FndLookupValuesDto CityFndLookupValues { get; set; }

        public FndLookupValuesDto MaritalStatusFndLookupValues { get; set; }

        public FndLookupValuesDto QualificationFndLookupValues { get; set; }

        public FndLookupValuesDto FndCaseCategoryLkp { get; set; }

        public FndLookupValuesDto NationalityFndLookupValues { get; set; }

        public UserDto User { get; set; }
    }
}
