using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__CharityBoxes._TmCharityBoxes.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxes
{
    public interface ITmCharityBoxesAppService : IAsyncCrudAppService<TmCharityBoxesDto, long, PagedTmCharityBoxesResultRequestDto, CreateTmCharityBoxesDto, TmCharityBoxesEditDto>
    {
        Task<TmCharityBoxesDto> GetDetailAsync(EntityDto<long> input);

        Task<List<TransOutput>> GetTmCharityBoxesTrans(PostDto idLangInputDto);

        Task<(long id, string text)> GetCharityBoxByLocation(long locationsubId);

        Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang, long? statuslkpId = null);
    }
}
