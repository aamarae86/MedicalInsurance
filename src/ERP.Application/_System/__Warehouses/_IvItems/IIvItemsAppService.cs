using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__Warehouses._IvItems.Dto;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvItems
{
    public interface IIvItemsAppService : IAsyncCrudAppService<IvItemsDto, long, IvItemsPagedDto, IvItemsCreateDto, IvItemsEditDto>
    {
        Task<IvItemsDto> GetDetailAsync(EntityDto<long> input);
        Task<IvItemsDto> GetItemDataByBarcode(string barcode, long IvPriceListHdId, long IvWarehouseId);
        Task<IvItemsDto> GetItemDataById(long id, long IvPriceListHdId, long IvWarehouseId);
        
    }
}
