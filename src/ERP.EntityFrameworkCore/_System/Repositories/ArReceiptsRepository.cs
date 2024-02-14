using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._ArReceipts;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    
    public class ArReceiptsRepository :
        ERPProcedureRepositoryBase<ArReceipts, long, PostDto, PostOutput>
        ,
        IArReceiptsRepository
    {
        public ArReceiptsRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}
