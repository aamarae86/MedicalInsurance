using ERP._System.__HR._PyPayrollTypes;
using ERP._System.__HrReports.Inputs;
using ERP._System.__HrReports.Outputs;

namespace ERP._System.__HrReports.Procs
{
    public interface IGetPyPayrollDetailsRepository : IExecuteProcedure<PyPayrollTypes, long, PyPayrollDetailsInput, PyPayrollDetailsOutput>
    {
    }
}
