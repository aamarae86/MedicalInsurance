using Abp.Application.Services.Dto;

namespace ERP._System.__HR._HrOrganizations.Dto
{
    public class HrOrganizationsPagedDto : PagedAndSortedResultRequestDto
    {
        public HrOrganizationsSearchDto Params { get; set; }

    }
}
