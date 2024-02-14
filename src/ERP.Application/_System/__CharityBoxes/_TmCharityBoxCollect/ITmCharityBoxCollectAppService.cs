using Abp.Application.Services;
using ERP._System.__CharityBoxes._TmCharityBoxCollect.Dto;
using ERP._System.__CharityBoxes._TmCharityBoxCollect.ProcDto;
using ERP._System.__CharityBoxes._TmCharityBoxCollectMembers.Dto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollect
{
    public interface ITmCharityBoxCollectAppService
        : IAsyncCrudAppService<TmCharityBoxCollectDto, long, PagedTmCharityBoxCollectResultRequestDto, TmCharityBoxCollectCreateDto, TmCharityBoxCollectEditDto>
    {
        Task<TmCharityBoxCollectDto> GetDetailAsync(Abp.Application.Services.Dto.EntityDto<long> input);

        Task<List<TmCharityBoxCollectMembersDetailDto>> GetAllMembersDetails(long id);

        Task<List<TmCharityBoxCollectDetailsDto>> GetAllDetails(long id);

        Task<PostOutput> PostTmCharityBoxCollect(PostDto postDto);

        Task<List<TmCharityBoxCollectScreenDataOutput>> GetTmCharityBoxCollectScreenData(IdLangInputDto input);
    }
}
