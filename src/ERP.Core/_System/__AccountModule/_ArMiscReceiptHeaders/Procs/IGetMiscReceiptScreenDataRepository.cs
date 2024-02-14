using ERP._System._ArMiscReceiptHeaders.ProcDto;
using ERP._System.PostRecords.Dto;

namespace ERP._System._ArMiscReceiptHeaders.Procs
{
    public interface IGetMiscReceiptScreenDataRepository
         : IExecuteProcedure<ArMiscReceiptHeaders, long, IdLangInputDto, MiscReceiptScreenDataOutput>
    {
    }
}
