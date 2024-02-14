using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__HR._PyPayrollTypes
{
    public interface IPyPayrollTypesManager : IDomainService
    {
        Task<Select2PagedResult> GetPyPayrollTypesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
