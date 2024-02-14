using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__CharityBoxes._TmCharityBoxActions.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxActions
{
    public interface ITmCharityBoxActionsAppService
        : IAsyncCrudAppService<TmCharityBoxActionsDto, long, PagedTmCharityBoxActionsResultRequestDto, CreateTmCharityBoxActionsDto, TmCharityBoxActionsEditDto>
    {
        Task<TmCharityBoxActionsDto> GetDetailAsync(EntityDto<long> input);

        Task<List<TmCharityBoxActionDetailsDto>> GetAllDetails(long id);

        Task<PostOutput> PostTmCharityBoxActions(PostDto postDto);

        Task<Select2PagedResult> GetCharityBoxActionDetailsForCollectSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetCharityBoxActionDetailsForDamagedSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
