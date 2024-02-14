using Abp.Application.Services.Dto;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders.Dto
{
    public class GlJeIntegrationHeadersPagedDto : PagedResultRequestDto
    {
        public GlJeIntegrationHeadersSearchDto Params { get; set; }
    }
}
