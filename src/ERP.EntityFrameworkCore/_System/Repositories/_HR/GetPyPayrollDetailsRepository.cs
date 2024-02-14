using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__HR._PyPayrollTypes;
using ERP._System.__HrReports.Inputs;
using ERP._System.__HrReports.Outputs;
using ERP._System.__HrReports.Procs;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._HR
{
    public class GetPyPayrollDetailsRepository : ERPProcedureRepositoryBase<PyPayrollTypes, long, PyPayrollDetailsInput, PyPayrollDetailsOutput>,
          IGetPyPayrollDetailsRepository
    {
        public GetPyPayrollDetailsRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
