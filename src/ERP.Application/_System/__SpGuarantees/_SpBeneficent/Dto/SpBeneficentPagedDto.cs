using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__SpGuarantees._SpBeneficent.Dto
{
    public class SpBeneficentPagedDto : PagedAndSortedResultRequestDto
    {
        public SpBeneficentSearchDto Params { get; set; }
    }
}
