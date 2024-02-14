using ERP._System.__SpGuarantees._SpCases._SpCaseOperations;
using ERP._System.__SpGuaranteesReports.Inputs;
using ERP._System.__SpGuaranteesReports.Outputs;

namespace ERP._System.__SpGuaranteesReports.Proc
{
    public interface ISpCaseOperationsDataListRepository : IExecuteProcedure<SpCaseOperations, long, SpCaseOperationsDataListInput, SpCaseOperationsDataListOutput>
    {
    }
}
