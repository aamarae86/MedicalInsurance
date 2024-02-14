using ERP._System.__HR._HrPersonsAdditionHd;
using ERP._System.__HR._PyPayrollOperations.Input;
using ERP._System.PostRecords.Dto;

namespace ERP._System
{
    public interface IIdLangPostRepository : IExecuteProcedure<HrPersonsAdditionHd, long, IdLangInputDto, PostOutput>
    {
    }
}
