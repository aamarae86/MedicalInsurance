using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._GlAccMappingHd
{
    public interface IGlAccMappingHdManager : IDomainService
    {
        Task<Select2PagedResult> GetGlAccMappingHdSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
