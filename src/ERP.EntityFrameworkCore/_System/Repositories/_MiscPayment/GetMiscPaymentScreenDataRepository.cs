using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._ApMiscPaymentHeaders.ProcDto;
using ERP._System._ApMiscPaymentHeaders.Procs;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._MiscPayment
{
    public class GetMiscPaymentScreenDataRepository : ERPProcedureRepositoryBase<ApMiscPaymentHeaders, long, IdLangInputDto, MiscPaymentScreenDataOutput>,
        IGetMiscPaymentScreenDataRepository
    {

        public GetMiscPaymentScreenDataRepository(IDbContextProvider<ERPDbContext> dbContextProvider,
              IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        {
        }

    }
}
