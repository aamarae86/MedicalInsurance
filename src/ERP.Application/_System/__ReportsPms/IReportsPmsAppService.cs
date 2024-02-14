using Abp.Application.Services;
using ERP._System.__ReportsPms.Input;
using ERP._System.__ReportsPms.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__ReportsPms
{
    public interface IReportsPmsAppService : IApplicationService
    {
        Task<List<PmPropertiesUnitsUnoccupiedOutput>> GetPmPropertiesUnitsUnoccupied(PmPropertiesUnitsUnoccupiedInput input);

        Task<List<PmContractNotRenewedOutput>> GetPmContractNotRenewed(PmContractNotRenewedInput input);

        Task<List<PmContractsOutput>> GetPmContracts(PmContractsHelperInput input);

        Task<List<rptArDebitCreditOutput>> GetrptArDebitCredit(rptArDebitCreditInputHelper input);

        Task<List<rptPmPropertiesIncomeOutput>> GetrptPmPropertiesIncome(rptPmPropertiesIncomeHelperInput input);
    }
}
