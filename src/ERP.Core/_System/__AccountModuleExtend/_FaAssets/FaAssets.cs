using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._FaAssetCategory;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModuleExtend._FaAssets
{
    public class FaAssets : PostAuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string AssetNumber { get; protected set; }

        [MaxLength(200)]
        public string Description { get; protected set; }

        [MaxLength(100)]
        public string TagNumber { get; protected set; }

        [MaxLength(100)]
        public string SerialNumber { get; protected set; }

        [ForeignKey(nameof(AssetTypeLkpId)), Column(Order = 0)]
        public FndLookupValues AssetTypeLkp { get; protected set; }
        public long? AssetTypeLkpId { get; protected set; }

        [MaxLength(100)]
        public string AssetKey { get; protected set; }

        public long FaAssetCategoryId { get; protected set; }
        [ForeignKey(nameof(FaAssetCategoryId))]
        public FaAssetCategory AssetCategory { get; protected set; }

        public long Units { get; protected set; }

        public long? ParentAssetId { get; protected set; }
        [ForeignKey(nameof(ParentAssetId))]
        public FaAssets ParentAsset { get; protected set; }

        [MaxLength(200)]
        public string Manufacturer { get; protected set; }

        [MaxLength(200)]
        public string Model { get; protected set; }

        [MaxLength(200)]
        public string WarrantyNumber { get; protected set; }

        public bool? InUse { get; protected set; }

        public bool? InPhysicalInventory { get; protected set; }

        [ForeignKey(nameof(OwnershipLkpId)), Column(Order = 1)]
        public FndLookupValues OwnershipLkp { get; protected set; }
        public long? OwnershipLkpId { get; protected set; }

        [ForeignKey(nameof(BoughtLkpId)), Column(Order = 2)]
        public FndLookupValues BoughtLkp { get; protected set; }
        public long? BoughtLkpId { get; protected set; }

        public DateTime? DatePlacedInService { get; protected set; }

        [ForeignKey(nameof(BookingTypeLkpId)), Column(Order = 3)]
        public FndLookupValues BookingTypeLkp { get; protected set; }
        public long BookingTypeLkpId { get; protected set; }

        [MaxLength(200)]
        public string BookingName { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? CurrentCost { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? OriginalCost { get; protected set; }

        [ForeignKey(nameof(SalvageValueTypeLkpId)), Column(Order = 4)]
        public FndLookupValues SalvageValueTypeLkp { get; protected set; }
        public long? SalvageValueTypeLkpId { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? SalvageValue { get; protected set; }

        [ForeignKey(nameof(DeprenMethodLkpId)), Column(Order = 5)]
        public FndLookupValues DeprenMethodLkp { get; protected set; }

        public long? DeprenMethodLkpId { get; protected set; }

        public int? LifeInMonths { get; protected set; }

        public bool? IsDepreciate { get; protected set; }

        [MaxLength(30)]
        public string ProrateConversionCode { get; protected set; }

        public DateTime? ProrateDate { get; protected set; }

        public DateTime? AmortizationStartDate { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 6)]
        public FndLookupValues StatusLkp { get; protected set; }
        public long? StatusLkpId { get; protected set; }

        public int TenantId { get; set; }
    }
}
