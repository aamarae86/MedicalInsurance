using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__SpGuarantees._SpCaseHistory;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpBeneficent
{
    public class SpBeneficent : AuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        [Required]
        [MaxLength(20)]
        public string BeneficentNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string BeneficentName { get; protected set; }

        //[Required]
        //[MaxLength(200)]
        //public string BeneficentNameAr { get; protected set; }

        //[Required]
        //[MaxLength(200)]
        //public string BeneficentNameEn { get; protected set; }

        [Required]
        public long FirstTitleLkpId { get; protected set; }

        public long? CityLkpId { get; protected set; }

        public long? GenderLkpId { get; protected set; }

        public long? NationalityLkpId { get; protected set; }

        [MaxLength(50)]
        public string MobileNumber1 { get; protected set; }

        [MaxLength(50)]
        public string MobileNumber2 { get; protected set; }

        public long? LastTitleLkpId { get; protected set; }

        [MaxLength(32)]
        public string Fax { get; protected set; }

        [MaxLength(256)]
        public string EmailAddress { get; protected set; }

        [MaxLength(100)]
        public string PoBox { get; protected set; }

        [MaxLength(200)]
        public string JobDescription { get; protected set; }

        [MaxLength(200)]
        public string Job { get; protected set; }

        [MaxLength(4000)]
        public string Address { get; protected set; }

        [ForeignKey(nameof(FirstTitleLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupFirstTitleValues { get; protected set; }

        [ForeignKey(nameof(CityLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupCityValues { get; protected set; }

        [ForeignKey(nameof(GenderLkpId)), Column(Order = 2)]
        public FndLookupValues FndLookupGenderValues { get; protected set; }

        [ForeignKey(nameof(NationalityLkpId)), Column(Order = 3)]
        public FndLookupValues FndLookupNationalityValues { get; protected set; }

        [ForeignKey(nameof(LastTitleLkpId)), Column(Order = 4)]
        public FndLookupValues FndLookupLastTitleValues { get; protected set; }

        public virtual ICollection<SpBeneficentAttachments> SpBeneficentAttachments { get; protected set; }

        public virtual ICollection<ArMiscReceiptHeaders> ArMiscReceiptHeaders { get; protected set; }

        public virtual ICollection<SpBeneficentBanks> SpBeneficentBanks { get; protected set; }

        public virtual ICollection<SpCaseHistory> SpCaseHistory { get; protected set; }

    }
}
