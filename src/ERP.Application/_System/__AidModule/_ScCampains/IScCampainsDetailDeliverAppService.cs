using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._ScCampains.Dto;
using ERP._System.PostRecords.Dto;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScCampains
{
    public interface IScCampainsDetailDeliverAppService : IApplicationService
    {
        Task<PagedResultDto<MasterDetailDto>> GetAllForDetials(PagedMasterDetailResultRequestDto input);
        Task<PostOutput> scCampainsDetailDeliver(PostDto postDto);

    }
}
