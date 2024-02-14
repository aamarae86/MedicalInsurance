using Abp.Application.Services;
using ERP._System.__SpGuaranteesReports.Inputs;
using ERP._System.__SpGuaranteesReports.Outputs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__SpGuaranteesReports
{
    public interface ISpGuaranteesReportsAppService : IApplicationService
    {
        Task<List<SpCaseOperationsDataListOutput>> GetCaseOperationsDataList(SpCaseOperationsDataListInputHelper input);
        Task<List<GetSpCaseListrptOutput>> GetIGetSpCaseListrpt(GetSpCaseListrptInput input);
        Task<List<GetSpCaseListUpTo18YearrptOutput>> GetSpCaseListUpTo18Yearrpt(GetSpCaseListUpTo18YearrptInput input);
    }
}
