using ERP._System.PostRecords.Dto;

namespace ERP._System.__AccountModule._ArReceipts
{
    public interface IArReceiptsRepository : IExecuteProcedure<ArReceipts, long, PostDto, PostOutput>
    {
    }
}
