using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System.__PmPropertiesModule._PmOwners;
using ERP._System.__PmPropertiesModule._PmPropertiesAttachments;
using ERP._System.__PmPropertiesModule._PmPropertiesRevenueAccounts;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits;
using ERP._System._ApBankAccounts;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__PmPropertiesModule._PmProperties
{
    public class PmProperties : AuditedEntity<long>,IMustHaveTenant
    {
        #region Props
        [Required]
        [MaxLength(200)]
        public string PropertyNameAr { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string PropertyNameEn { get; protected set; }

        [Required]
        [MaxLength(30)]
        public string PropertyNumber { get; protected set; }

        [MaxLength(30)]
        public string LandNumber { get; protected set; }

        [MaxLength(30)]
        public string MilkiyaNumber { get; protected set; }

        [MaxLength(200)]
        public string Region { get; protected set; }

        [MaxLength(4000)]
        public string Address { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? PropertyValue { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? CommissionPercentage { get; protected set; }

        public DateTime? CompletionDate { get; protected set; }

        public int? NoOfFloors { get; protected set; }

        public long PmOwnerId { get; protected set; }

        public long BankAccountId { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long? CountryLkpId { get; protected set; }

        public long? CityLkpId { get; protected set; }

        public long? CommissionTypeLkpId { get; protected set; }

        public long? PmPurposeLkpId { get; protected set; }

        [ForeignKey(nameof(PmOwnerId))]
        public PmOwners PmOwners { get; protected set; }

        [ForeignKey(nameof(BankAccountId))]
        public ApBankAccounts ApBankAccounts { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(CountryLkpId)), Column(Order = 1)]
        public FndLookupValues FndCountryLkp { get; protected set; }

        [ForeignKey(nameof(CityLkpId)), Column(Order = 2)]
        public FndLookupValues FndCityLkp { get; protected set; }

        [ForeignKey(nameof(CommissionTypeLkpId)), Column(Order = 3)]
        public FndLookupValues FndCommissionTypeLkp { get; protected set; }

        [ForeignKey(nameof(PmPurposeLkpId)), Column(Order = 4)]
        public FndLookupValues FndPmPurposeLkp { get; protected set; }

        public virtual ICollection<PmContract> PmContract { get; protected set; }
        public virtual ICollection<PmPropertiesUnits> PmPropertiesUnits { get; protected set; }
        public virtual ICollection<PmPropertiesAttachments> PmPropertiesAttachments { get; protected set; }
        public virtual ICollection<PmPropertiesRevenueAccounts> PmPropertiesRevenueAccounts { get; protected set; }
        public virtual ICollection<FmMaintRequisitionsHdr> FmMaintRequisitionsHdr { get; protected set; }

        public int TenantId { get; set; } 
        #endregion

    }
}
