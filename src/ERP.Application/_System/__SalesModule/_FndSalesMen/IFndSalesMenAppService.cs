using Abp.Application.Services;
using ERP._System.__SalesModule._FndSalesMen.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__SalesModule._FndSalesMen
{
    public interface IFndSalesMenAppService : IAsyncCrudAppService<FndSalesMenDto, long, PagedFndSalesMenResultRequestDto, CreateFndSalesMenDto, FndSalesMenEditDto>
    {
        Task<bool> GetExistSalesMenNameArAsync(string input, string Id);
        Task<bool> GetExistSalesMenNameEnAsync(string input, string Id);
        Task<Select2PagedResult> GetFndSalesMenSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<long?> GetSalesMenNameByNameAsync(string name);
    }
}
