using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._ArMiscReceiptHeaders.ProcDto;
using ERP._System._ArMiscReceiptHeaders.Procs;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._MiscReceipt
{
    public class GetMiscReceiptScreenDataRepository : ERPProcedureRepositoryBase<ArMiscReceiptHeaders, long, IdLangInputDto, MiscReceiptScreenDataOutput>,
          IGetMiscReceiptScreenDataRepository
    {
        public GetMiscReceiptScreenDataRepository(IDbContextProvider<ERPDbContext> dbContextProvider,
              IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }

    }
}

