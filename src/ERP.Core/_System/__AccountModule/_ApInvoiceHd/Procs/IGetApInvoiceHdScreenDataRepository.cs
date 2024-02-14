using ERP._System.__AccountModule._ApInvoiceHd.ProcDto;
using ERP._System.PostRecords.Dto;

namespace ERP._System.__AccountModule._ApInvoiceHd.Procs
{
    public interface IGetApInvoiceHdScreenDataRepository : IExecuteProcedure<ApInvoiceHd, long, IdLangInputDto, ApInvoiceHdScreenDataOutput>
    { }
}
