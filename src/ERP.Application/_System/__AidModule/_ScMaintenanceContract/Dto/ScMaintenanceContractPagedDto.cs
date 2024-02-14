using Abp.Application.Services.Dto;

namespace ERP._System.__AidModule._ScMaintenanceContract.Dto
{
    public class ScMaintenanceContractPagedDto : PagedResultRequestDto
    {
        public ScMaintenanceContractSearchDto Params { get; set; }
    }
}
