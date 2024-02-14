using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._FaAssets
{
    public interface IFaAssetsManager : IDomainService
    {
        Task<Select2PagedResult> GetSelect2FaAssets(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
