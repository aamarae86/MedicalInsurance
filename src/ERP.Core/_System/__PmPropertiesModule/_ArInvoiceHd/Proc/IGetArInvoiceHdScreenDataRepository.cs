using ERP._System.__PmPropertiesModule._ArInvoiceHd.ProcDto;
using ERP._System.PostRecords.Dto;

namespace ERP._System.__PmPropertiesModule._ArInvoiceHd.Proc
{
    public interface IGetArInvoiceHdScreenDataRepository
             : IExecuteProcedure<ArInvoiceHd, long, IdLangInputDto, ArInvoiceHdScreenDataOutput>
    { }
}
