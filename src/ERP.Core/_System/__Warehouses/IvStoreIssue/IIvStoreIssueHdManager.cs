using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvStoreIssue
{
    public interface IIvStoreIssueHdManager : IDomainService
    {
        Task<Select2PagedResult> GetStoreIssueSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
