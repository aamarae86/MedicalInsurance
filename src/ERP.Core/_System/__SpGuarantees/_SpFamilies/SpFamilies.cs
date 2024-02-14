using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__SpGuarantees._SpCases;
using ERP._System.__SpGuarantees._SpFamilyDuties;
using ERP._System.__SpGuarantees._SpFamilyIncomes;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpFamilies
{
    public class SpFamilies : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(200)]
        public string FamilyName { get; protected set; }

        [Required]
        [MaxLength(30)]
        public string FamilyNumber { get; protected set; }

        public DateTime RegistrationDate { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string GuardianName { get; protected set; }

        public DateTime BirthDate { get; protected set; }

        [MaxLength(200)]
        public string PlaceOfBirth { get; protected set; }

        [MaxLength(50)]
        public string IdNumber { get; protected set; }

        public DateTime? IdExpirationDate { get; protected set; }

        [MaxLength(200)]
        public string JobDescription { get; protected set; }

        [MaxLength(200)]
        public string Job { get; protected set; }

        public bool IsFatherDied { get; protected set; }

        public bool IsMotherDied { get; protected set; }

        public bool IsHasHouse { get; protected set; }

        public DateTime? FatherDiedDate { get; protected set; }

        public DateTime? MotherDiedDate { get; protected set; }

        [MaxLength(200)]
        public string FatherDiedReason { get; protected set; }

        [MaxLength(200)]
        public string MotherDiedReason { get; protected set; }

        [MaxLength(200)]
        public string Region { get; protected set; }

        [MaxLength(4000)]
        public string Address { get; protected set; }

        [MaxLength(50)]
        public string MobileNumber1 { get; protected set; }

        [MaxLength(50)]
        public string MobileNumber2 { get; protected set; }

        [MaxLength(50)]
        public string AccountNumber { get; protected set; }

        [MaxLength(50)]
        public string AccountOwner { get; protected set; }

        public long? BankLkpId { get; protected set; }

        public long? MaritalStatusLkpId { get; protected set; }

        public long? RelativesTypeLkpId { get; protected set; }

        public long? NationalityLkpId { get; protected set; }

        public long? HousingTypeLkpId { get; protected set; }

        public long? HousingStatusLkpId { get; protected set; }

        public long? CityLkpId { get; protected set; }

        [ForeignKey(nameof(BankLkpId)), Column(Order = 0)]
        public FndLookupValues FndBankLkp { get; protected set; }

        [ForeignKey(nameof(MaritalStatusLkpId)), Column(Order = 1)]
        public FndLookupValues FndMaritalStatusLkp { get; protected set; }

        [ForeignKey(nameof(RelativesTypeLkpId)), Column(Order = 2)]
        public FndLookupValues FndRelativesTypeLkp { get; protected set; }

        [ForeignKey(nameof(NationalityLkpId)), Column(Order = 3)]
        public FndLookupValues FndNationalityLkp { get; protected set; }

        [ForeignKey(nameof(HousingTypeLkpId)), Column(Order = 4)]
        public FndLookupValues FndHousingTypeLkp { get; protected set; }

        [ForeignKey(nameof(HousingStatusLkpId)), Column(Order = 5)]
        public FndLookupValues FndHousingStatusLkp { get; protected set; }

        [ForeignKey(nameof(CityLkpId)), Column(Order = 6)]
        public FndLookupValues FndCityLkp { get; protected set; }


        public virtual ICollection<SpCases> SpCases { get; protected set; }

        public virtual ICollection<SpFamilyDuties> SpFamilyDuties { get; protected set; }

        public virtual ICollection<SpFamilyIncomes> SpFamilyIncomes { get; protected set; }

        public int TenantId { get; set; }

    }
}
