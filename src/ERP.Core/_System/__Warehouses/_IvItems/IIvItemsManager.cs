using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvItems
{
    public interface IIvItemsManager : IDomainService
    {
        Task<Select2PagedResult> GetIvItemsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetIvItemsForReceiveSelect2(long IvReceiveHdReceiveTypeId, string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
