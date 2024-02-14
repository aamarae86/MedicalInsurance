using ERP.Helpers.Core.__PostAudited;

namespace ERP._System.__AccountModuleExtend._FaAssets.Dto
{
    public class FaAssetBaseDto : PostAuditedEntityDto<long>
    {

        public string Description { get; set; }

        public string TagNumber { get; set; }

        public string SerialNumber { get; set; }

        public long? AssetTypeLkpId { get; set; }

        public string AssetKey { get; set; }

        public long FaAssetCategoryId { get; set; }

        public long Units { get; set; }

        public long? ParentAssetId { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string WarrantyNumber { get; set; }

        public bool? InUse { get; set; }

        public bool? InPhysicalInventory { get; set; }

        public long? OwnershipLkpId { get; set; }

        public long? BoughtLkpId { get; set; }

        public string DatePlacedInService { get; set; }

        public long BookingTypeLkpId { get; set; }

        public string BookingName { get; set; }

        public decimal? CurrentCost { get; set; }

        public decimal? OriginalCost { get; set; }

        public long? SalvageValueTypeLkpId { get; set; }

        public decimal? SalvageValue { get; set; }

        public long? DeprenMethodLkpId { get; set; }

        public int? LifeInMonths { get; set; }

        public bool? IsDepreciate { get; set; }

        public string ProrateConversionCode { get; set; }

        public string ProrateDate { get; set; }

        public string AmortizationStartDate { get; set; }

        public bool? IsAmortizeAdjustment { get; set; }

        public long? StatusLkpId { get; set; }
    }
}
