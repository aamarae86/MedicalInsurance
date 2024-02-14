using Abp.Application.Services;
using ERP._System.__HrReports.Inputs;
using ERP._System.__HrReports.Outputs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__HrReports
{
    public interface IHrReportsAppService : IApplicationService
    {
        Task<IReadOnlyList<PyPayrollDetailsOutput>> GetPyPayrollDetails(PyPayrollDetailsInput input);
    }
}
