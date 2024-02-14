using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System._modules
{
    public interface ISelect2WithParent
    {
        Task<Select2PagedResult> GetSelect2(long parentId, string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
