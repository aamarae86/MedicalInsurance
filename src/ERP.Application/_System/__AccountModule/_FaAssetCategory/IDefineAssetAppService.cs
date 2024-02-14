using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._FaAssetCategory.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._FaAssetCategory
{
    public interface IDefineAssetAppService : IAsyncCrudAppService<FaAssetCategoryDto, long, FaAssetCategoryPagedDto, FaAssetCategoryCreateDto, FaAssetCategoryEditDto>
    {
        Task<FaAssetCategoryDto> GetDetailAsync(EntityDto<long> input);
        Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
