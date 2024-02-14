using Abp.Application.Services.Dto;

namespace ERP._System.__SpGuarantees._SpContracts.Dto
{
    public class PagedSpContractsResultRequestDto : PagedAndSortedResultRequestDto
    {
        public SpContractsSearchDto Params { get; set; }

    }
}
