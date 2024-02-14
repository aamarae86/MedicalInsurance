using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._FaAssetDeprn.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._FaAssetDeprnHdDeprn
{
    public interface IFaAssetDeprnHdAppService : IAsyncCrudAppService<FaAssetDeprnHdDto, long, FaAssetDeprnHdPagedDto, FaAssetDeprnHdCreateDto, FaAssetDeprnHdEditDto>
    {
        Task<PostOutput> PostFaAssetDeprnHd(PostDto postDto);

        Task<PostOutput> PostFaAssetDeprnHdGl(PostDto postDto);

        Task<List<FaAssetDeprnTrDto>> GetAllFaAssetDeprnTr(EntityDto<long> input);

        Task<List<FaAssetDeprnTrDtlDto>> GetAllFaAssetDeprnTrDtl(EntityDto<long> input);

        Task<Select2PagedResult> GetSelect2FaAssets(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
