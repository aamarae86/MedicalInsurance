using Abp.Application.Services.Dto;

namespace ERP._System.__SpGuarantees._SpFamilies.Dto
{
    public class PagedSpFamiliesResultRequestDto : PagedAndSortedResultRequestDto
    {
        public SpFamiliesSearchDto Params { get; set; }
    }
}
