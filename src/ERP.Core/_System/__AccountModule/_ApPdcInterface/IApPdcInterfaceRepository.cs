using ERP._System.PostRecords.Dto;

namespace ERP._System._ApPdcInterface
{
    public interface IApPdcInterfaceRepository :
        IExecuteProcedure<ApPdcInterface, long, PostDto, PostOutput>
    {
    }
}
