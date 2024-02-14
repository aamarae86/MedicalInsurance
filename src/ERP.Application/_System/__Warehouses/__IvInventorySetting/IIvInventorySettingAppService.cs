using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__Warehouses.__IvInventorySetting.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ERP._System.__Warehouses.__IvInventorySetting
{
    public interface IIvInventorySettingAppService : IAsyncCrudAppService<IvInventorySettingDto, long, IvInventorySettingPagedDto, IvInventorySettingCreateDto, IvInventorySettingEditDto>
    {
        Task<IvInventorySettingDto> GetDetailAsync(EntityDto<long> input);
        Task<Select2PagedResult> GetPricelistByUserIdSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<IvInventorySettingPriceListDto> GetFirstPricelistByUserId();
    }
}
