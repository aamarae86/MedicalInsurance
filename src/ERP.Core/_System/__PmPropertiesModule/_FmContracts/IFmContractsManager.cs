using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._FmContracts
{
    public interface IFmContractsManager :Abp.Domain.Services.IDomainService
    {
        Task<Select2PagedResult> GetFmContractsNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        
        Task<Select2PagedResult> GetFmContractsVisitsNumberSelect2(long contactId, string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
