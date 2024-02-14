using ERP._System.PostRecords.Dto;

namespace ERP._System.__HR._HrPersonsAdditionHd.Proc
{
    public interface IHrPersonsAdditionPostRepository :
        IExecuteProcedure<HrPersonsAdditionHd, long, PostDto, PostOutput>
    {
    }
}
