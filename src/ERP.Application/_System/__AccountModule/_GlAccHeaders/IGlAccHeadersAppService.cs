using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._GlAccHeaders.Dto;
using ERP._System._GlAccHeaders.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System._GlAccHeaders
{
    public interface IGlAccHeadersAppService : IAsyncCrudAppService<GlAccHeadersDto, long, PagedGlAccHeadersResultRequestDto, CreateGlAccHeadersDto, GlAccHeadersEditDto>
    {
        Task<GlAccHeadersDetailDto> GetDetailAsync(EntityDto<long> input);

        Task<ListResultDto<GlAccHeadersListDto>> GetGlAccHeadersAsync();

        Task<Select2PagedResult> GetGlAccHeadersSelect2(string searchTerm, int pageSize, int pageNumber, string lang, string trigger, long? updatedId);
    }
}
