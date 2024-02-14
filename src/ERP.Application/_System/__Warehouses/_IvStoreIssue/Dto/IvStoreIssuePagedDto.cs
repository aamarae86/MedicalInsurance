using Abp.Application.Services.Dto;

namespace ERP._System.__Warehouses._IvStoreIssue.Dto
{
    public class IvStoreIssuePagedDto : PagedAndSortedResultRequestDto
    {
        public IvStoreIssueSearchDto Params { get; set; }
    }
}
