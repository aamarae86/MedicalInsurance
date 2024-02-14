using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._ArReceipts;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class GetReceiptScreenDataRepository :  ERPProcedureRepositoryBase<ArReceipts, long, IdLangInputDto, receipttScreenDataOutput>
        ,
        IGetReceiptScreenDataRepository
    {
        public GetReceiptScreenDataRepository(
                  IDbContextProvider<ERPDbContext> dbContextProvider,
                  IActiveTransactionProvider activeTransactionProvider
              ) : base(dbContextProvider, activeTransactionProvider)
        {
        }

    }
}
