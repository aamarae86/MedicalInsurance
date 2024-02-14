using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs.Dto;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs.ProcDto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmDamagedCharityBoxs
{
    public interface ITmDamagedCharityBoxsAppService
       : IAsyncCrudAppService<TmDamagedCharityBoxsDto, long, PagedTmDamagedCharityBoxsResultRequestDto, TmDamagedCharityBoxsCreateDto, TmDamagedCharityBoxsEditDto>
    {
        Task<TmDamagedCharityBoxsDto> GetDetailAsync(EntityDto<long> input);

        Task<List<TmDamagedCharityBoxDetailsDto>> GetAllDetails(long id);

        Task<PostOutput> PostTmDamagedCharityBoxs(PostDto postDto);

        Task<List<TmDamagedCharityBoxesScreenDataOutput>> GetTmDamagedCharityBoxesScreenData(IdLangInputDto input);
    }
}
