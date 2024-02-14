using Abp.Application.Services.Dto;

namespace ERP._System.__AccountModule._FaAssetDeprn.Dto
{
    public class FaAssetDeprnHdPagedDto : PagedAndSortedResultRequestDto
    {
        public FaAssetDeprnHdSearchDto Params { get; set; }
    }

}
