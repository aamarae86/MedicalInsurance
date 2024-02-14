using Abp.Application.Services.Dto;

namespace ERP._System.__SpGuarantees._SpCases.Dto
{
    public class SpCasesPagedDto : PagedAndSortedResultRequestDto
    {
        public SpCasesSearchDto Params { get; set; }
    }
}
