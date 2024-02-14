using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System._ArPdcInterface;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class ArPdcInterfaceRepository : 
        ERPProcedureRepositoryBase<ArPdcInterface,long,PostDto,PostOutput>
        ,
        IArPdcInterfaceRepository
    {
        public ArPdcInterfaceRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}
