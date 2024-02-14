using ERP._System.PostRecords.Dto;

namespace ERP._System.__Warehouses._IvReturnReceiveHd.Proc
{
    public interface IIvReturnReceiveHdPostRepository :
      IExecuteProcedure<IvReturnReceiveHd, long, PostDto, PostOutput>
    {
    }
   
}
