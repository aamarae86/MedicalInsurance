using Abp.Application.Services.Dto;

namespace ERP._System.__HR._PyPayrollTypes.Dto
{
    public class PyPayrollTypesPagedDto : PagedAndSortedResultRequestDto
    {
        public PyPayrollTypesSearchDto Params { get; set; }

    }
}
