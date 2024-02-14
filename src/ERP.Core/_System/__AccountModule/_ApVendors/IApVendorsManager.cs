using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ApVendors
{
    public interface IApVendorsManager : IDomainService
    {
        Task<Select2PagedResult> GetVendorsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
