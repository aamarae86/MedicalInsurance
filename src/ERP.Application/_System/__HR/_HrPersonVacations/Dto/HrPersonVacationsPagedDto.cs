using Abp.Application.Services.Dto;

namespace ERP._System.__HR._HrPersonVacations.Dto
{
    public class HrPersonVacationsPagedDto : PagedAndSortedResultRequestDto
    {
        public HrPersonVacationsSearchDto Params { get; set; }
    }
}
