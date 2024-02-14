using Abp.Application.Services;
using ERP._System.__HR._PyPayrollTypes.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__HR._PyPayrollTypes
{
    public interface IPyPayrollTypesAppService : IAsyncCrudAppService<PyPayrollTypesDto, long, PyPayrollTypesPagedDto, PyPayrollTypesCreateDto, PyPayrollTypesEditDto>
    {
        Task<Select2PagedResult> GetPyPayrollTypesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
