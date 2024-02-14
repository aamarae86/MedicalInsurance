using Abp.Application.Services.Dto;

namespace ERP._System.__HR._HrPersons.Dto
{
    public class HrPersonsPagedDto : PagedAndSortedResultRequestDto
    {
        public HrPersonsSearchDto Params { get; set; }

    }

}
