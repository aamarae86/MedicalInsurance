using Abp.Application.Services.Dto;

namespace ERP._System.__CRM._CrmProjects.Dto
{
    public class CrmProjectsPagedDto : PagedAndSortedResultRequestDto
    {
        public CrmProjectsSearchDto Params { get; set; }
    }
}
