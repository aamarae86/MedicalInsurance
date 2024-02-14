using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._ScPortalRequestStudy.Dto;
using ERP._System.__AidModule._ScPortalRequestStudy.ProcDto;
using ERP._System.__AidModule._ScPortalRequestStudyAttachment.Dto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScPortalRequestStudy
{
    public interface IScPortalRequestStudyAppService : IAsyncCrudAppService<ScPortalRequestStudyDto, long, PagedScPortalRequestStudyResultRequestDto, CreateScPortalRequestStudyDto, ScPortalRequestStudyEditDto>
    {
        Task<ScPortalRequestStudyDto> GetDetailAsync(EntityDto<long> input);

        Task<List<ScPortalRequestStudyAttachmentDto>> GetAllAttachments(EntityDto<long> input);

        Task<PostOutputWithId> ScPortalRequestStudyPostCommittee(PostDto idLangInputDto);

        Task<PostOutputWithId> ScPortalRequestStudyPostManager(PostDto idLangInputDto);

        Task<PostOutputWithId> UnPostScPortalRequestStudy(PostDto postDto);

        Task<PostOutput> ScPortalRequestStudyRefuse(PostDto postDto, long? RefuseLkpId, string RefuseDescription);

        Task<List<ScPortalRequestStudyScreenDataOutput>> GetScPortalRequestStudyScreenData(IdLangInputDto input);
    }
}
