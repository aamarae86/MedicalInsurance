using Abp.Application.Services;
using ERP._System.__AccountModule._TmCharityBoxesType.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._TmCharityBoxesType
{
    public interface ITmCharityBoxesTypeAppService : IAsyncCrudAppService<TmCharityBoxesTypeDto, long, PagedTmCharityBoxesTypeResultRequestDto, CreateTmCharityBoxesTypeDto, TmCharityBoxesTypeEditDto>
    {

        Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
