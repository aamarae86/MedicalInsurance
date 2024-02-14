using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._GlPeriods
{
    public interface IGlPeriodsYearsAppService : IAsyncCrudAppService<GlPeriodsYearsDto, long, PagedGlPeriodsYearsResultRequestDto, CreateGlPeriodsYearsDto, GlPeriodsYearsEditDto>
    {
        Task<GlPeriodsYearsDto> GetDetailAsync(EntityDto<long> input);
        Task<List<GlPeriodsDetailsDto>> GetAllDetails(long glPeriodsYearsId);
        Task<bool> GetIsExistingPeriodAsync(string input, string Id);

        Task<bool> UpdateStatusLkp(long statusLkpId,long id);

        Task<Select2PagedResult> GetGlPeriodsYearsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
