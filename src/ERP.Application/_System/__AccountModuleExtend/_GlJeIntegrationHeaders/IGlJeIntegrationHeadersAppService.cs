using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders
{
    public interface IGlJeIntegrationHeadersAppService : IAsyncCrudAppService<GlJeIntegrationHeadersDto, long, GlJeIntegrationHeadersPagedDto, GlJeIntegrationHeadersCreateDto, GlJeIntegrationHeadersEditDto>
    {
        Task<PostOutput> PostGlJeIntegrationHeaders(PostDto postDto);

        Task<List<GlJeIntegrationAccountsLinesDto>> GetAllAccountLineData(EntityDto<long> input, string lang); 

        Task<List<GlJeIntegrationCustomersLinesDto>> GetAllCustomerLineData(EntityDto<long> input);

        Task<List<GlJeIntegrationVendorsLinesDto>> GetAllVendorLineData(EntityDto<long> input); 
        Task<Select2PagedResult> GetGlJeIntegration_Headers_Line_Cr_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetGlJeIntegration_Headers_Line_Dr_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang);
    }
}
