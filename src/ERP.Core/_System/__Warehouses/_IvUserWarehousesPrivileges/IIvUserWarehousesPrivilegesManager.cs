using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvUserWarehousesPrivileges
{
    public interface IIvUserWarehousesPrivilegesManager : IDomainService
    {
        Task<Select2PagedResult> GetIvUserWarehousesPrivilegesSelect2(long userId, string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
