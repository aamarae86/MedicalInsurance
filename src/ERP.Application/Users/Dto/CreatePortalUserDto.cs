using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._Portal.UserAttachments;
using ERP._System.__AidModule._Portal.UserDuites;
using ERP._System.__AidModule._Portal.UserIncomes;
using ERP._System._Portal.UserRelatives.Dto;
using ERP.Authorization.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Users.Dto
{
    [AutoMapTo(typeof(PortalUser))]
    public class CreatePortalUserDto : EntityDto<long>
    {
        public bool AddToLoggedTenant { get; set; }

        public string Job { get; set; }

        public string CaseNumber { get; set; }

        public long? CaseCategoryLkpId { get; set; }

        public long IsZakat { get; set; }

        public CreateUserNullableDto User { get; set; }

        public List<PortalUserRelativesDto> UserRelatives { get; set; }

        #region Custom Fields

        [Required]
        public string BirthDate { get; set; }

        [Required]
        public long GenderLkpId { get; set; }

        [Required]
        public long CityLkpId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Region { get; set; }

        [MaxLength(50)]
        //[Required]
        public string IdNumber { get; set; }

        public string Name { get; set; }

        //[Required]
        public string IdExpirationDate { get; set; }

        [MaxLength(200)]
        public string WifeHusbandName1 { get; set; }

        [MaxLength(50)]
        public string IdNumberWifeHusband1 { get; set; }

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

        [Required]
        public long NationalityLkpId { get; set; }

        [MaxLength(50)]
        [Required]
        public string MobileNumber1 { get; set; }

        [MaxLength(50)]
        public string MobileNumber2 { get; set; }

        [MaxLength(200)]
        public string JobDescription { get; set; }

        [MaxLength(4000)]
        public string Address { get; set; }

        public long MaritalStatusLkpId { get; set; }

        public long? QualificationLkpId { get; set; }

        [MaxLength(200)]
        public string JobWifeHusband1 { get; set; }

        [MaxLength(200)]
        public string JobWife2 { get; set; }

        [MaxLength(200)]
        public string JobWife3 { get; set; }

        [MaxLength(200)]
        public string JobWife4 { get; set; }

        [MaxLength(100)]
        public string PassportNumber { get; set; }

        [MaxLength(100)]
        public string UnifiedNumber { get; set; }

        public string PassportIssueDate { get; set; }

        public string PassportExpiryDate { get; set; }

        public string ResidenceEndDate { get; set; }

        public int? TenantCreatorId { get; set; }
        #endregion


        public ICollection<PortalUserDutiesDto> UserDuties { get; set; }

        public ICollection<PortalUserIncomesDto> UserIncomes { get; set; }

        public ICollection<PortalUserAttachmentsDto> UserAttachments { get; set; }
    }
}
