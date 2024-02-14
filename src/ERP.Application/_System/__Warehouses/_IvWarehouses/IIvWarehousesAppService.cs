using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__Warehouses._IvWarehouses.Dto;
using ERP._System.__Warehouses.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses
{
    public interface IIvWarehousesAppService : IAsyncCrudAppService<IvWarehousesDto, long, IvWarehousesPagedDto, IvWarehousesCreateDto, IvWarehousesEditDto>
    {
        Task<IvWarehousesDto> GetDetailAsync(EntityDto<long> input);
        Task<Select2PagedResult> GetIvWarehousesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<IvWarehousesDto> GetFirstWarehousesByUserId();
    }
}
