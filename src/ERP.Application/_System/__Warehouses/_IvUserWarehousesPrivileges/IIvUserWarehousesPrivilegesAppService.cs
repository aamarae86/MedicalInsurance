using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__Warehouses._IvUserWarehousesPrivileges.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvUserWarehousesPrivileges
{
    public interface IIvUserWarehousesPrivilegesAppService : IAsyncCrudAppService<IvUserWarehousesPrivilegesDto, long, IvUserWarehousesPrivilegesPagedDto, IvUserWarehousesPrivilegesCreateDto, IvUserWarehousesPrivilegesEditDto>
    {
        Task<IvUserWarehousesPrivilegesDto> GetDetailAsync(EntityDto<long> input);
        Task<Select2PagedResult> GetIvWarehousesForIssueUserSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetIvUserWarehousesPrivilegesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
