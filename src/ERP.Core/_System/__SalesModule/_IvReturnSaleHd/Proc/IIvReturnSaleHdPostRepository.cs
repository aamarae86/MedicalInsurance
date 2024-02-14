using ERP._System.PostRecords.Dto;

namespace ERP._System.__SalesModule._IvReturnSaleHd.Proc
{

    public interface IIvReturnSaleHdPostRepository :
       IExecuteProcedure<IvReturnSaleHd, long, PostDto, PostOutput>
    {
    }
    
}
