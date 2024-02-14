using Abp.Application.Services.Dto;

namespace ERP._System.__PmPropertiesModule._FmEngineers.Dto
{
    public class FmEngineersPagedDto : PagedAndSortedResultRequestDto
    {
        public FmEngineersSearchDto Params { get; set; }
    }
}
