using Abp.Application.Services.Dto;

namespace ERP._System.__AccountModule._ArJobCardHd.Dto
{
    public class ArJobCardHdPagedDto : PagedAndSortedResultRequestDto
    {
        public ArJobCardHdSearchDto Params { get; set; }
    }
}
