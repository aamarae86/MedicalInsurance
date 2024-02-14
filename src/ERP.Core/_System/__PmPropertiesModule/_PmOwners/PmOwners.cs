using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._PmProperties;
using ERP._System._ApBankAccounts;
using ERP._System._FndLookupValues;
using ERP._System._GlCodeComDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmOwners
{
    public class PmOwners : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string OwnerNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string OwnerNameAr { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string OwnerNameEn { get; protected set; }

        public long StatusLkpId { get; protected set; }
        [ForeignKey(nameof(StatusLkpId)), Column(Order =0)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [MaxLength(50)]
        public string IdNumber { get; protected set; }

        //[Required]
        [MaxLength(100)]
        public string TaxNumber { get; protected set; }

        public long NationalityLkpId { get; protected set; }
        [ForeignKey(nameof(NationalityLkpId)), Column(Order = 1)]
        public FndLookupValues FndNationalityLkp { get; protected set; }

        public long CountryLkpId { get; protected set; }
        [ForeignKey(nameof(CountryLkpId)), Column(Order = 2)]
        public FndLookupValues FndCountryLkp { get; protected set; }

        public long CityLkpId { get; protected set; }
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

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [Required]
        public long AccountId { get; protected set; }
        [ForeignKey(nameof(AccountId)), Column(Order = 0)]
        public GlCodeComDetails GlCodeComAccount { get; protected set; }

        [Required]
        public long CurrentAccountId { get; protected set; }
        [ForeignKey(nameof(CurrentAccountId)), Column(Order = 1)]
        public GlCodeComDetails GlCodeComCurrentAccount { get; protected set; }

        [Required]
        public long BankAccountId { get; protected set; }
        [ForeignKey(nameof(BankAccountId)), Column(Order = 2)]
        public ApBankAccounts BankAccount { get; protected set; }

        [Required]
        public long CashAccountId { get; protected set; }
        [ForeignKey(nameof(CashAccountId)), Column(Order = 3)]
        public ApBankAccounts CashAccount { get; protected set; }

        public bool IsMainOwner { get; protected set; }


        public ICollection<PmOwnersTaxDetails> PmOwnersTaxesDetails { get; protected set; }

        public ICollection<PmProperties> PmProperties { get; protected set; }

        public int TenantId { get; set; }
    }
}
