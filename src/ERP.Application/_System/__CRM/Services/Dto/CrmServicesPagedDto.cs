using Abp.Application.Services.Dto;

namespace ERP._System.__CRM._CrmServices.Dto
{
    public class CrmServicesPagedDto : PagedAndSortedResultRequestDto
    {
        public CrmServicesSearchDto Params { get; set; }
    }
}
