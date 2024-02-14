using ERP._System.PostRecords.Dto;

namespace ERP._System._ApMiscPaymentHeaders
{
    public interface IApMiscPaymentHeadersRepository : 
        IExecuteProcedure<ApMiscPaymentHeaders, long,PostDto,PostOutput>
    {
    }
}
