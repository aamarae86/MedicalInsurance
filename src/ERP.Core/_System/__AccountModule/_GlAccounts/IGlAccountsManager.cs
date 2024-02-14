using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System._GlAccounts
{
    public interface IGlAccountsManager : IDomainService
    {
        Task<Select2PagedResult> GetGlAccountsSelect2(string searchTerm, int pageSize, int pageNumber, string lang, string filterTrigger = null);

        Task<Select2PagedResult> GetGlAccountsForAccMappingSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
