using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScMaintenanceContract
{
    public interface IScMaintenanceContractManager : IDomainService
    {
        Task<Select2PagedResult> GetScMaintenanceContractPaymentsByContractNumberSelect2(string contactNumber, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetScMaintenanceContractSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetScMaintenanceContractPaymentsSelect2(long contractId, string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
