using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._ScCampains.Dto;
using ERP._System.__AidModule._ScCampains.Outputs;
using ERP._System.__AidModule._ScCampainsDetail.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScCampains
{
    public interface IScCampainsAppService : IAsyncCrudAppService<ScCampainsDto, long, PagedScCampainsResultRequestDto, CreateScCampainsDto, ScCampainsEditDto>
    {
        Task<ScCampainsDto> GetDetailAsync(EntityDto<long> input);

        Task<List<ScCampainsDetailDto>> GetAllDetails(long id);

        Task<PagedResultDto<MasterDetailDto>> GetAllForDetials(PagedMasterDetailResultRequestDto input);

        Task<Select2PagedResult> GetCampainsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetPortalUsersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<PostOutput> PostScCampainsDetail(PostDto postDto);

        Task<PostOutput> PostScCampains(PostDto postDto);

        Task<PostOutput> scCampainsDetailDeliver(PostDto postDto);

        Task<List<ScCampainssScreenDataOutput>> GetScCampainssScreenData(IdLangInputDto idLangInputDto);
    }
}
