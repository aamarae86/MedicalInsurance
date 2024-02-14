using ERP._System.__SpGuarantees._SpCaseEditData;
using ERP._System.__SpGuarantees._SpCases._SpCaseEditData.ProcDto;
using ERP._System.PostRecords.Dto;

namespace ERP._System.__SpGuarantees._SpCases._SpCaseEditData.Proc
{
    public interface ISpCaseEditDataRepository : IExecuteProcedure<SpCaseEditData, long, SpCaseEditDataInputDto, PostOutput>
    {
    }
}
