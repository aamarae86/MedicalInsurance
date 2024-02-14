using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._ScPortalRequestMgrDecision.Dto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScPortalRequestMgrDecision
{
    public interface IScPortalRequestMgrDecisionAppService : IAsyncCrudAppService<ScPortalRequestMgrDecisionDto, long, PagedScPortalRequestMgrDecisionResultRequestDto, CreateScPortalRequestMgrDecisionDto, ScPortalRequestMgrDecisionEditDto>
    {
        Task<ScPortalRequestMgrDecisionDto> GetDetailAsync(EntityDto<long> input);

        Task<PostOutput> PostRefuse(RefuseDto refuseDto);

        Task<PostOutputWithId> PostManagerRefuseReason(ManagerRefuseReasonInput refuseDto);

        Task<PostOutput> ScPortalRequestMgrDecisionRefuse(PostDto postDto);

        Task<PostOutputWithId> ScScPortalRequestMgrDecisionPost(PostDto postDto);

        Task<IReadOnlyList<ScPRMgrDecisionElectronicAidDto>> GetAllScPRMgrDecisionElectronicAid(EntityDto<long> input);
    }
}
