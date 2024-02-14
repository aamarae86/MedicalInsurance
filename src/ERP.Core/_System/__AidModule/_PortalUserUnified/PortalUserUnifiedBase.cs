using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._PortalUserUnified
{
    public class PortalUserUnifiedBase : AuditedEntity<long>
    {
        public string PhoneNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string Region { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string MobileNumber1 { get; protected set; }

        [MaxLength(50)]
        public string MobileNumber2 { get; protected set; }

        public DateTime BirthDate { get; protected set; }

        public DateTime IdExpirationDate { get; protected set; }

        public DateTime? PassportExpiryDate { get; protected set; }

        public DateTime? PassportIssueDate { get; protected set; }

        public DateTime? ResidenceEndDate { get; protected set; }

        [MaxLength(100)]
        public string PassportNumber { get; protected set; }

        [MaxLength(100)]
        public string UnifiedNumber { get; protected set; }

        [MaxLength(200)]
        public string Job { get; protected set; }

        [MaxLength(200)]
        public string JobDescription { get; protected set; }

        [MaxLength(4000)]
        public string Address { get; protected set; }

        public long MaritalStatusLkpId { get; protected set; }

        public long GenderLkpId { get; protected set; }

        public long CityLkpId { get; protected set; }

        public long? CaseCategoryLkpId { get; protected set; }

        public long? QualificationLkpId { get; protected set; }

        [ForeignKey(nameof(GenderLkpId)), Column(Order = 0)]
        public FndLookupValues GenderFndLookupValues { get; protected set; }

        [ForeignKey(nameof(CityLkpId)), Column(Order = 1)]
        public FndLookupValues CityFndLookupValues { get; protected set; }

        [ForeignKey(nameof(MaritalStatusLkpId)), Column(Order = 3)]
        public FndLookupValues MaritalStatusFndLookupValues { get; protected set; }

        [ForeignKey(nameof(QualificationLkpId)), Column(Order = 4)]
        public FndLookupValues QualificationFndLookupValues { get; protected set; }

        [ForeignKey(nameof(CaseCategoryLkpId)), Column(Order = 5)]
        public FndLookupValues FndCaseCategoryLkp { get; protected set; }
    }
}
