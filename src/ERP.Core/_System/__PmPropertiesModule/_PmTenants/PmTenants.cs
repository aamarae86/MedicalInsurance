using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System.__PmPropertiesModule._PmTenantsAttachments;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmTenants
{
    public class PmTenants : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string TenantNumber { get; protected set; }
        
        [Required]
        [MaxLength(200)]
        public string TenantNameAr { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string TenantNameEn { get; protected set; }

        [Required]
        public long StatusLkpId { get;protected set; }
        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [MaxLength(50)]
        public string IdNumber { get; protected set; }
        
        public long? NationalityLkpId { get; protected set; }
        [ForeignKey(nameof(NationalityLkpId)), Column(Order = 1)]
        public FndLookupValues FndNationalityLkp { get; protected set; }

        public long? CountryLkpId{ get; protected set; }
        [ForeignKey(nameof(CountryLkpId)), Column(Order = 2)]
        public FndLookupValues FndCountryLkp { get; protected set; }

        public long? CityLkpId { get; protected set; }
        [ForeignKey(nameof(CityLkpId)), Column(Order = 3)]
        public FndLookupValues FndCityLkp { get; protected set; }

        [MaxLength(4000)]
        public string Address { get; protected set; }
        
        [MaxLength(32)]
        public string HomePhoneNumber { get; protected set; }
        
        [MaxLength(32)]
        public string MobileNumber { get; protected set; }
        
        [MaxLength(32)]
        public string WorkPhoneNumber { get; protected set; }
        
        [MaxLength(32)]
        public string Fax { get; protected set; }
        
        [MaxLength(256)]
        public string Website { get; protected set; }
        
        [MaxLength(256)]
        public string EmailAddress { get; protected set; }
        
        [MaxLength(200)]
        public string JobName { get; protected set; }
        
        [MaxLength(200)]
        public string CompanyName { get; protected set; }
        
        [MaxLength(100)]
        public string PoBox { get; protected set; }
        
        [MaxLength(4000)]
        public string OtherAddress { get; protected set; }
        
        [MaxLength(100)]
        public string Region { get; protected set; }
        
        [MaxLength(100)]
        public string PassportNumber { get; protected set; }
        
        public DateTime? PassportIssueDate { get; protected set; }
        
        public DateTime? PassportExpiryDate { get; protected set; }
        
        public long? PassportCountryLkpId { get; protected set; }
        [ForeignKey(nameof(PassportCountryLkpId)), Column(Order = 3)]
        public FndLookupValues FndPassportCountryLkp { get; protected set; }

        public long? SpecialGenderLkpId { get; protected set; }
        [ForeignKey(nameof(SpecialGenderLkpId)), Column(Order = 4)]
        public FndLookupValues FndSpecialGenderLkp { get; protected set; }

        public DateTime? BirthDate { get; protected set; }
        
        public long? MaritalStatusLkpId { get; protected set; }
        [ForeignKey(nameof(MaritalStatusLkpId)), Column(Order = 5)]
        public FndLookupValues FndMaritalStatusLkp { get; protected set; }

        public long? PaymentMethodLkpId { get; protected set; }
        [ForeignKey(nameof(PaymentMethodLkpId)), Column(Order = 6)]
        public FndLookupValues FndPaymentMethodLkp { get; protected set; }

        [MaxLength(100)]
        public string CommercialLicenseNumber { get; protected set; }

        public DateTime? CommercialLicenseExpiryDate { get; protected set; }

        public DateTime? ResidenceEndDate { get; protected set; }


        public int TenantId { get ; set ; }
        public virtual ICollection<PmTenantsAttachments> PmTenantsAttachments { get; protected set; }


        public virtual ICollection<PmContract> PmContract { get;set; }
    }
}
