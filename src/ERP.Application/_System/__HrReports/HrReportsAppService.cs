using Abp.Authorization;
using ERP._System.__HrReports.Inputs;
using ERP._System.__HrReports.Outputs;
using ERP._System.__HrReports.Procs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HrReports
{
    [AbpAuthorize]
    public class HrReportsAppService : ERPAppServiceBase, IHrReportsAppService
    {
        private readonly IGetPyPayrollDetailsRepository _getPyPayrollDetailsRepository;

        public HrReportsAppService(IGetPyPayrollDetailsRepository getPyPayrollDetailsRepository)
        {
            _getPyPayrollDetailsRepository = getPyPayrollDetailsRepository;
        }

        public async Task<IReadOnlyList<PyPayrollDetailsOutput>> GetPyPayrollDetails(PyPayrollDetailsInput input)
        {
            try
            {
                input.TenantId = AbpSession.TenantId ?? 0;

                var result = await _getPyPayrollDetailsRepository.Execute(input, "rptPyPayrollOperationPersons");

                return result.ToList();
            }
            catch (System.Exception x)
            {

                throw;
            }
            
        }
    }
}
