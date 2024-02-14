using ERP._System.__PmPropertiesModule._PmPropertiesAttachments.Dto;
using ERP._System.__PmPropertiesModule._PmTenants.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.PmPropertiesModule;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class PmTenantsVM : BaseAuditedEntityVM<long>, IAttachmentListJSONString
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [Display(Name = nameof(PmTenants.TenantName), ResourceType = typeof(PmTenants))]
        public string TenantName { get; set; }

        [Display(Name = nameof(PmTenants.TenantNumber), ResourceType = typeof(PmTenants))]
        public string TenantNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmTenants.TenantNameAr), ResourceType = typeof(PmTenants))]
        public string TenantNameAr { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmTenants.TenantNameEn), ResourceType = typeof(PmTenants))]
        public string TenantNameEn { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmTenants.StatusLkpId), ResourceType = typeof(PmTenants))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(PmTenants.IdNumber), ResourceType = typeof(PmTenants))]
        public string IdNumber { get; set; }

        [Display(Name = nameof(PmTenants.NationalityLkpId), ResourceType = typeof(PmTenants))]
        public long? NationalityLkpId { get; set; }

        [Display(Name = nameof(PmTenants.CountryLkpId), ResourceType = typeof(PmTenants))]
        public long? CountryLkpId { get; set; }

        [Display(Name = nameof(PmTenants.CityLkpId), ResourceType = typeof(PmTenants))]
        public long? CityLkpId { get; set; }

        [Display(Name = nameof(PmTenants.Address), ResourceType = typeof(PmTenants))]
        public string Address { get; set; }

        [Display(Name = nameof(PmTenants.HomePhoneNumber), ResourceType = typeof(PmTenants))]
        public string HomePhoneNumber { get; set; }

        [Display(Name = nameof(PmTenants.MobileNumber), ResourceType = typeof(PmTenants))]
        public string MobileNumber { get; set; }

        [Display(Name = nameof(PmTenants.WorkPhoneNumber), ResourceType = typeof(PmTenants))]
        public string WorkPhoneNumber { get; set; }

        [Display(Name = nameof(PmTenants.Fax), ResourceType = typeof(PmTenants))]
        public string Fax { get; set; }

        [Display(Name = nameof(PmTenants.Website), ResourceType = typeof(PmTenants))]
        public string Website { get; set; }

        [Display(Name = nameof(PmTenants.EmailAddress), ResourceType = typeof(PmTenants))]
        public string EmailAddress { get; set; }

        [Display(Name = nameof(PmTenants.JobName), ResourceType = typeof(PmTenants))]
        public string JobName { get; set; }

        [Display(Name = nameof(PmTenants.CompanyName), ResourceType = typeof(PmTenants))]
        public string CompanyName { get; set; }

        [Display(Name = nameof(PmTenants.PoBox), ResourceType = typeof(PmTenants))]
        public string PoBox { get; set; }

        [Display(Name = nameof(PmTenants.OtherAddress), ResourceType = typeof(PmTenants))]
        public string OtherAddress { get; set; }

        [Display(Name = nameof(PmTenants.Region), ResourceType = typeof(PmTenants))]
        public string Region { get; set; }

        public ICollection<PmTenantsAttachmentsDto> PmTenantsAttachments { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public FndLookupValuesVM FndNationalityLkp { get; set; }

        public FndLookupValuesVM FndCountryLkp { get; set; }

        public FndLookupValuesVM FndCityLkp { get; set; }

        public FndLookupValuesVM FndPassportCountryLkp { get; set; }

        public FndLookupValuesVM FndSpecialGenderLkp { get; set; }

        public FndLookupValuesVM FndMaritalStatusLkp { get; set; }

        public FndLookupValuesVM FndPaymentMethodLkp { get; set; }

        [Display(Name = nameof(PmTenants.PassportNumber), ResourceType = typeof(PmTenants))]
        public string PassportNumber { get; set; }

        [Display(Name = nameof(PmTenants.PassportIssueDate), ResourceType = typeof(PmTenants))]
        public string PassportIssueDate { get; set; }

        [Display(Name = nameof(PmTenants.PassportExpiryDate), ResourceType = typeof(PmTenants))]
        public string PassportExpiryDate { get; set; }

        [Display(Name = nameof(PmTenants.PassportCountryLkpId), ResourceType = typeof(PmTenants))]
        public long? PassportCountryLkpId { get; set; }

        [Display(Name = nameof(PmTenants.SpecialGenderLkpId), ResourceType = typeof(PmTenants))]
        public long? SpecialGenderLkpId { get; set; }

        [Display(Name = nameof(PmTenants.BirthDate), ResourceType = typeof(PmTenants))]
        public string BirthDate { get; set; }

        [Display(Name = nameof(PmTenants.MaritalStatusLkpId), ResourceType = typeof(PmTenants))]
        public long? MaritalStatusLkpId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PmTenants.PaymentMethodLkpId), ResourceType = typeof(PmTenants))]
        public long? PaymentMethodLkpId { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(PmTenants.CommercialLicenseNumber), ResourceType = typeof(PmTenants))]
        public string CommercialLicenseNumber { get; set; }

        [Display(Name = nameof(PmTenants.CommercialLicenseExpiryDate), ResourceType = typeof(PmTenants))]
        public string CommercialLicenseExpiryDate { get; set; }

        [Display(Name = nameof(PmTenants.ResidenceEndDate), ResourceType = typeof(PmTenants))]
        public string ResidenceEndDate { get; set; }

        public string AttachmentsListStr { get; set; }

        public ICollection<PmTenantsAttachmentsDto> PTAttachmentsList => string.IsNullOrEmpty(AttachmentsListStr) ?
                 new List<PmTenantsAttachmentsDto>() : Helper<List<PmTenantsAttachmentsDto>>.Convert(AttachmentsListStr);
    }
}