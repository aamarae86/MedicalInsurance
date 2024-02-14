using Abp.Application.Services.Dto;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto
{
    public class ScMaintenanceTechnicalReportPagedDto : PagedResultRequestDto
    {
        public ScMaintenanceTechnicalReportSearchDto Params { get; set; }
    }
}
