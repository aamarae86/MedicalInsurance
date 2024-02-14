namespace ERP._System.__AccountModuleExtend._FaAssets.Dto
{
    public class FaAssetBaseWithLookupsDto : FaAssetBaseDto
    {
        public string AssetTypeLkpAr { get; set; }
        public string AssetTypeLkpEn { get; set; }
        public string FaAssetCategoryAr { get; set; }
        public string FaAssetCategoryEn { get; set; }
        public string ParentAssetDescription { get; set; }
        public string ParentAssetNumber { get; set; }
        public string OwnershipLkpAr { get; set; }
        public string OwnershipLkpEn { get; set; }
        public string BoughtLkpAr { get; set; }
        public string BoughtLkpEn { get; set; }
        public string BookingTypeLkpAr { get; set; }
        public string BookingTypeLkpEn { get; set; }
        public string SalvageValueTypeLkpAr { get; set; }
        public string SalvageValueTypeLkpEn { get; set; }
        public string DeprenMethodLkpAr { get; set; }
        public string DeprenMethodLkpEn { get; set; }
        public string StatusAr { get; set; }
        public string StatusEn { get; set; }
    }
}
