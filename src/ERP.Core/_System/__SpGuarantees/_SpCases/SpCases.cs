using Abp.Domain.Entities;
using ERP._System.__SpGuarantees._SpCaseHistory;
using ERP._System.__SpGuarantees._SpCasesAttachments;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP._System.__SpGuarantees._SpFamilies;
using ERP._System.__SpGuarantees._SpPayments;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpCases
{
    public class SpCases : PostAuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(200)]
        [Required]
        public string CaseName { get; protected set; }

        [MaxLength(20)]
        public string CaseNumber { get; protected set; }

        public DateTime? RegistrationDate { get; protected set; }

        public DateTime? BirthDate { get; protected set; }

        [MaxLength(200)]
        public string PlaceOfBirth { get; protected set; }

        public long? NationalityLkpId { get; protected set; }

        public long? MaritalStatusLkpId { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long SpFamilyId { get; protected set; }

        public long? HealthStatusLkpId { get; protected set; }

        [MaxLength(200)]
        public string TypeOfDisease { get; protected set; }

        [MaxLength(200)]
        public string TypeOfTreatment { get; protected set; }

        [MaxLength(4000)]
        public string DescriptionOfHealthCondition { get; protected set; }

        public bool? IsStudy { get; protected set; }

        [MaxLength(200)]
        public string SchoolUniversityName { get; protected set; }

        public long? EducationalLevelLkpId { get; protected set; }

        public long? EducationalStageLkpId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? MonthlyInstallment { get; protected set; }

        [MaxLength(4000)]
        public string SupervisorComments { get; protected set; }

        [MaxLength(200)]
        public string Casephoto { get; protected set; }

        public long SponsorCategoryLkpId { get; protected set; }

        [MaxLength(50)]
        public string IdNumber { get; protected set; }

        public DateTime? IdExpirationDate { get; protected set; }

        public long? GenderLkpId { get; protected set; }

        public int TenantId { get; set; }

        public long? RelativesTypeLkpId { get; set; }

        public long? SpContractDetailsId { get; set; }

        [ForeignKey(nameof(SpContractDetailsId))]
        public SpContractDetails SpContractDetails { get; set; }

        [ForeignKey(nameof(NationalityLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValuesNationalityLkp { get; protected set; }

        [ForeignKey(nameof(MaritalStatusLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesMaritalStatusLkp { get; protected set; }

        [ForeignKey(nameof(HealthStatusLkpId)), Column(Order = 2)]
        public FndLookupValues FndLookupValuesHealthStatusLkp { get; protected set; }

        [ForeignKey(nameof(EducationalLevelLkpId)), Column(Order = 3)]
        public FndLookupValues FndLookupValuesEducationalLevelLkp { get; protected set; }

        [ForeignKey(nameof(EducationalStageLkpId)), Column(Order = 4)]
        public FndLookupValues FndLookupValuesEducationalStageLkp { get; protected set; }

        [ForeignKey(nameof(SponsorCategoryLkpId)), Column(Order = 5)]
        public FndLookupValues FndLookupValuesSponsorCategoryLkp { get; protected set; }

        [ForeignKey(nameof(GenderLkpId)), Column(Order = 6)]
        public FndLookupValues FndLookupValuesGenderLkp { get; protected set; }

        [ForeignKey(nameof(RelativesTypeLkpId)), Column(Order = 7)]
        public FndLookupValues FndLookupValuesRelativesTypeLkp { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 8)]
        public FndLookupValues FndLookupValuesStatusLkp { get; protected set; }

        [ForeignKey(nameof(SpFamilyId))]
        public SpFamilies SpFamilies { get; protected set; }

        public virtual ICollection<SpCasesAttachments> SpCasesAttachments { get; protected set; }

        public virtual ICollection<SpCaseHistory> SpCaseHistory { get; protected set; }

        public virtual ICollection<SpPayments> SpPayments { get; protected set; }

        public virtual ICollection<SpPaymentPersons> SpPaymentPersons { get; protected set; }
    }
}
