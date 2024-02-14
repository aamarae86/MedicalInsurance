using Abp.Application.Services.Dto;

namespace ERP._System.__AidModule._ScMaintenancePayments.Dto
{
    public class ScMaintenancePaymentsPagedDto : PagedResultRequestDto
    {
        public ScMaintenancePaymentsSearchDto Params { get; set; }
    }
}
