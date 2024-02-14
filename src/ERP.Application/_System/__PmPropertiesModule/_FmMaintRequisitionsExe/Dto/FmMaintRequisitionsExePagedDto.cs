using Abp.Application.Services.Dto;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe.Dto
{
    public class FmMaintRequisitionsExePagedDto  : PagedAndSortedResultRequestDto
    {
        public FmMaintRequisitionsExeSearchDto Params { get; set; }
    }
}
