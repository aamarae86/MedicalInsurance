using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvUnits
{
    public interface IIvUnitsManager : IDomainService
    {
        Task<Select2PagedResult> GetIvUnitsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
