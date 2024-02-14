using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__CharityBoxes._TmSupervisors.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmSupervisors
{
    public interface ITmSupervisorsAppService : IAsyncCrudAppService<TmSupervisorsDto, long, PagedTmSupervisorsResultRequestDto, CreateTmSupervisorsDto, TmSupervisorsEditDto>
    {
        Task<TmSupervisorsDto> GetDetailAsync(EntityDto<long> input);

        Task<Select2PagedResult> GetTmSupervisorsBoxesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

    }
}
