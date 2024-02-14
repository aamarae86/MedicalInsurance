using ERP._System.__SpGuarantees._SpCases._SpCaseOperations.ProcDto;
using ERP._System.PostRecords.Dto;

namespace ERP._System.__SpGuarantees._SpCases._SpCaseOperations.Proc
{
    public interface ISpCaseOperationsRepository : IExecuteProcedure<SpCaseOperations, long, SpCaseOperationsInputDto_Proc, PostOutput>
    {
    }
}
