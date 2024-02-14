using Abp.Application.Services.Dto;

namespace ERP._System.__AidModule._ScMaintenanceQuotations.Dto
{
    public class ScMaintenanceQuotationsPagedDto : PagedResultRequestDto
    {
        public ScMaintenanceQuotationsSearchDto Params { get; set; }
    }
}
