using ERP._System.PostRecords.Dto;

namespace ERP._System.__Warehouses._IvStoreIssue.Proc
{
    public interface IIvStoreIssuePostRepository : 
        IExecuteProcedure<IvStoreIssueHd, long, PostDto, PostOutput>
    {
    }

}
