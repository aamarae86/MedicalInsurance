using ERP._System.PostRecords.Dto;

namespace ERP._System.__SalesModule.ArInvoiceSettlement
{
    public interface IArInvoiceSettlementHdRepository : IExecuteProcedure<ArInvoiceSettlementHd, long, PostDto, PostOutput>
    {
    }
}
