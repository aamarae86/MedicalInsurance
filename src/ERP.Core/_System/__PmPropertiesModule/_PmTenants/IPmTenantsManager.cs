using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmTenants
{
    public interface IPmTenantsManager : IDomainService
    {
        Task<Select2PagedResult> PmTenantsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
      
        Task<Select2PagedResult> GetPmTenantsNameAndIdNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

    }

}
