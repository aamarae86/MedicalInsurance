using ERP._System.PostRecords.Dto;


namespace ERP._System.__SalesModule._IvSaleHd.Proc
{

    public interface IIvSaleHdPostRepository :
        IExecuteProcedure<IvSaleHd, long, PostDto, PostOutput>
    {
    }
}
