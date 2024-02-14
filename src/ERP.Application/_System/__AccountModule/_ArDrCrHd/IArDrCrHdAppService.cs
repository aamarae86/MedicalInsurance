using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._ArDrCrHd.Dto;
using ERP._System._ArDrCrHd.Dto;
using ERP._System._ArDrCrTr.Dto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System._ArDrCrHd
{
    public interface IArDrCrHdAppService : IAsyncCrudAppService<ArDrCrHdDto, long, PagedArDrCrHdResultRequestDto, CreateArDrCrHdDto, ArDrCrHdEditDto>
    {
        Task<ArDrCrHdDto> GetDetailAsync(EntityDto<long> input);

        Task<List<ArDrCrTrVM>> GetAllArDrCrHdDetails(long gljeheaderId);

        Task<PostOutput> PostArDrCrHd(PostDto postDto);
    }
}
