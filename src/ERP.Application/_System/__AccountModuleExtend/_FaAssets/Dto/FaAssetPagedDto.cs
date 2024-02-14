using Abp.Application.Services.Dto;

namespace ERP._System.__AccountModuleExtend._FaAssets.Dto
{
    public class FaAssetPagedDto : PagedAndSortedResultRequestDto
    {
        public FaAssetSearchDto Params { get; set; }
    }
}
