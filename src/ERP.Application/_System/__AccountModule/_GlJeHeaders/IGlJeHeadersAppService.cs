using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._GlJeHeaders.Dto;
using ERP._System._GlJeHeaders.Dto;
using ERP._System._GlJeHeaders.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System._GlJeHeaders
{
    public interface IGlJeHeadersAppService : IAsyncCrudAppService<GlJeHeadersDto, long, PagedGlJeHeadersResultRequestDto, CreateGlJeHeadersDto, GlJeHeadersEditDto>
    {
        Task<GlJeHeadersDetailDto> GetDetailAsync(EntityDto<long> input);

        Task<List<GlJeLinesDetailsVM>> GetAllGlJeHeaderLinesDetails(long gljeheaderId);

        Task<PostOutput> PostGlJeHeader(PostDto input);

        Task<PostOutput> CopyGlJeHeader(PostDto input);

        Task<List<GlJeScreenDataOutput>> GetGlJeScreenData(IdLangInputDto input);
    }

}
