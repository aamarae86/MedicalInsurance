using ERP._System._ApMiscPaymentHeaders.ProcDto;
using ERP._System.PostRecords.Dto;

namespace ERP._System._ApMiscPaymentHeaders.Procs
{
    public interface IGetMiscPaymentScreenDataRepository
              : IExecuteProcedure<ApMiscPaymentHeaders, long, IdLangInputDto, MiscPaymentScreenDataOutput>
    {
    }
}
