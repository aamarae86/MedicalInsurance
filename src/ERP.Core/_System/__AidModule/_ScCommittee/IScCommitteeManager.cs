using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScCommittee
{
    public interface IScCommitteeManager : IDomainService
    {
        Task<Select2PagedResult> GetScCommitteeForChecksSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
