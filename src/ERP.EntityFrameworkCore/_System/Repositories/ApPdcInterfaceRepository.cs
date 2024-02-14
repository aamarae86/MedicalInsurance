using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System._ApPdcInterface;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class ApPdcInterfaceRepository : 
        ERPProcedureRepositoryBase<ApPdcInterface,long,PostDto,PostOutput>
        ,
        IApPdcInterfaceRepository
    {
        public ApPdcInterfaceRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}
