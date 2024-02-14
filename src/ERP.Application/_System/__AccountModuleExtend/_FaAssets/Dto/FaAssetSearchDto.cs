namespace ERP._System.__AccountModuleExtend._FaAssets.Dto
{
    public class FaAssetSearchDto
    {
        public string Description { get; set; }
        public string AssetNumber { get; set; }
        public long? FaAssetCategoryId { get; set; }
        public long? AssetTypeLkpId { get; set; }
        public long? StatusId { get; set; }
        public override string ToString()
        {
            return $"Params.AssetNumber={AssetNumber}&Params.AssetTypeLkpId={AssetTypeLkpId}&Params.StatusId={StatusId}&Params.Description={Description}&Params.FaAssetCategoryId={FaAssetCategoryId}";
        }
    }
}
