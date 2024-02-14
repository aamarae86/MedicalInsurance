using Abp.AutoMapper;

namespace ERP._System.__AccountModuleExtend._FaAssets.Dto
{
    [AutoMap(typeof(FaAssets))]
    public class FaAssetCreateDto : FaAssetBaseDto
    {
        public string AssetNumber { get; set; }
    }
}
