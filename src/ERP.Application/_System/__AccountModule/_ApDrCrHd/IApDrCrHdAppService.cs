using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._ApDrCrHd.Dto;
using ERP._System.__AccountModule._ApDrCrTr.Dto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ApDrCrHd
{
    public interface IApDrCrHdAppService : IAsyncCrudAppService<ApDrCrHdDto, long, PagedApDrCrHdResultRequestDto, ApDrCrHdCreateDto, ApDrCrHdEditDto>
    {
        Task<ApDrCrHdDto> GetDetailAsync(EntityDto<long> input);

        Task<List<ApDrCrTrDto>> GetAllApDrCrHdDetails(long gljeheaderId);

        Task<PostOutput> PostApDrCrHd(PostDto postDto);
    }
}
