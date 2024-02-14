using Abp.Application.Services.Dto;

namespace ERP._System.__AccountModuleExtend._GlAccMapping.Dto
{
    public class GlAccMappingHdPagedDto : PagedResultRequestDto
    {
        public GlAccMappingHdSearchDto Params { get; set; }
    }
}
