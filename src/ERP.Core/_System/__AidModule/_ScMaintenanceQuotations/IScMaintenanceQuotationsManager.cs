using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScMaintenanceQuotations
{
    public interface IScMaintenanceQuotationsManager : IDomainService
    {
        Task<Select2PagedResult> GetScMaintenanceQuotationsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
