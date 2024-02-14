using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System._modules
{
    public interface ISelect2
    {
        Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
