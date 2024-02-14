using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpFamilies
{
    public interface ISpFamiliesManager : IDomainService
    {
        Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetGaurdiantSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
