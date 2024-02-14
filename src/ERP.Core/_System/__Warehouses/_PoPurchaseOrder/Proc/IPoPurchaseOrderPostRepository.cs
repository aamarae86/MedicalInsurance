using ERP._System.PostRecords.Dto;

namespace ERP._System.__Warehouses._PoPurchaseOrder.Proc
{
    public interface IPoPurchaseOrderPostRepository : 
        IExecuteProcedure<PoPurchaseOrderHd, long, PostDto, PostOutput>
    {
    }

}
