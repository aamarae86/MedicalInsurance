using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpContracts._SpContractDetails
{
    public interface ISpContractDetailsManager : IDomainService
    {
        Task<Select2PagedResult> GetSpCasesWithSpContractDetailsSearchSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetSpCasesWithSpContractDetailsSelect2(long beneficentId, string searchTerm, int pageSize, int pageNumber, string lang);

    }
}
