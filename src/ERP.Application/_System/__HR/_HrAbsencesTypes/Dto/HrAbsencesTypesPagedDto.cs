using Abp.Application.Services.Dto;

namespace ERP._System.__HR._HrAbsencesTypes.Dto
{
    public class HrVacationsTypesPagedDto : PagedAndSortedResultRequestDto
    {
        public HrAbsencesTypesSearchDto Params { get; set; }
    }
}
