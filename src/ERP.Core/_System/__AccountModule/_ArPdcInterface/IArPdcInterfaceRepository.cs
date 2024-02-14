using ERP._System._ArPdcInterface;
using ERP._System.PostRecords.Dto;

namespace ERP._System._ArPdcInterface
{
    public interface IArPdcInterfaceRepository :
    IExecuteProcedure<ArPdcInterface, long, PostDto, PostOutput>
    {
    }
}
