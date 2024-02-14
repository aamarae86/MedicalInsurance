using ERP._System.PostRecords.Dto;

namespace ERP._System.__AidModule._ScCommitteesCheck.Proc
{
    public interface IScCommitteesCheckPostRepository
                : IExecuteProcedure<ScCommitteesCheck, long, PostDto, PostOutput>
    {
    }
}
