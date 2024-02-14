using ERP._System.PostRecords.Dto;

namespace ERP._System.__AidModule._ScPortalRequest.Proc
{
    public interface IScPortalRequestPostRepository : IExecuteProcedure<ScPortalRequest, long, PostDto, PostOutput>
    {
    }
}
