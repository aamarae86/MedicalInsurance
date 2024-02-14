using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._FmEngineers
{
    public interface IFmEngineersManager : IDomainService
    {
        Task<Select2PagedResult> GetFmEngineersNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
