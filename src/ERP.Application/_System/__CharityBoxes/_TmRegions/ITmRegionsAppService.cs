using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__CharityBoxes._TmRegions.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmRegions
{
    public interface ITmRegionsAppService : IAsyncCrudAppService<TmRegionsDto, long, PagedTmRegionsResultRequestDto, CreateTmRegionsDto, TmRegionsEditDto>
    {
        Task<TmRegionsDto> GetDetailAsync(EntityDto<long> input);

        Task<Select2PagedResult> GetTmRegionsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
