using Abp.Application.Services.Dto;

namespace ERP._System.__Warehouses._IvReceiveHd.Dto
{
    public class IvReceiveHdPagedDto : PagedAndSortedResultRequestDto
    {
        public IvReceiveHdSearchDto Params { get; set; }

    }
}
