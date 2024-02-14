using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._PmTenants.Dto
{
    [AutoMap(typeof(PmTenants))]
    public class PmTenantsEditDto : EntityDto<long>
    {
        [Required]
        public string TenantNameAr { get; set; }

        [Required]
        public string TenantNameEn { get; set; }

        [Required]
        public long StatusLkpId { get; set; }

        public string IdNumber { get; set; }

        public long? NationalityLkpId { get; set; }

        public long? CountryLkpId { get; set; }

        public long? CityLkpId { get; set; }

        public string Address { get; set; }

        public string HomePhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string WorkPhoneNumber { get; set; }

        public string Fax { get; set; }

        public string Website { get; set; }

        public string EmailAddress { get; set; }

        public string JobName { get; set; }

        public string CompanyName { get; set; }

        public string PoBox { get; set; }

        public string OtherAddress { get; set; }

        public string Region { get; set; }

        public string PassportNumber { get; set; }

        public string PassportIssueDate { get; set; }

        public string PassportExpiryDate { get; set; }

        public long? PassportCountryLkpId { get; set; }

        public long? SpecialGenderLkpId { get; set; }

        public string BirthDate { get; set; }

        public long? MaritalStatusLkpId { get; set; }

        [Required]
        public long PaymentMethodLkpId { get; set; }

        public string CommercialLicenseNumber { get; set; }

        public string CommercialLicenseExpiryDate { get; set; }

        public string ResidenceEndDate { get; set; }

        public ICollection<PmTenantsAttachmentsDto> PmTenantsAttachments { get; set; }

        public ICollection<PmTenantsAttachmentsDto> PTAttachmentsList { get; set; }
    }
}
