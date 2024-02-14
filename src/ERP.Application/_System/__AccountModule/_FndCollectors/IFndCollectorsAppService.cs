using Abp.Application.Services;
using ERP._System._FndCollectors.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._FndCollectors
{
    public interface IFndCollectorsAppService : IAsyncCrudAppService<FndCollectorsDto, long, PagedFndCollectorsResultRequestDto, CreateFndCollectorsDto, FndCollectorsEditDto>
    {
        Task<bool> GetExistCollectorNameArAsync(string input, string Id);
        Task<bool> GetExistCollectorNameEnAsync(string input, string Id);

        Task<Select2PagedResult> GetFndCollectorsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

    }
}
