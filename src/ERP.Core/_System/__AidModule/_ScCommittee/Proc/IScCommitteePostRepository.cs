using ERP._System.PostRecords.Dto;

namespace ERP._System.__AidModule._ScCommittee.Proc
{
    public interface IScCommitteePostRepository : IExecuteProcedure<ScCommittee, long, PostDto, PostOutput>
    {
    }
}
