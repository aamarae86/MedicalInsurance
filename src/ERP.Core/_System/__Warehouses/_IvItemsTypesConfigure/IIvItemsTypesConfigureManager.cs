using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvItemsTypesConfigure
{
    public interface IIvItemsTypesConfigureManager : IDomainService
    {
        Task<Select2PagedResult> GetIvItemsTypesConfigureSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetIvItemsTypesConfigureWithParentSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
