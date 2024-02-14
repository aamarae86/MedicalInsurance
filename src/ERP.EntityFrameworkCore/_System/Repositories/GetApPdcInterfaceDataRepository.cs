using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._ApPdcInterface.Proc;
using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System._ApPdcInterface;
using ERP._System._ArPdcInterface;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class GetApPdcInterfaceDataRepository : ERPProcedureRepositoryBase<ApPdcInterface, long, GetApPdcInterfaceDataInput, GetApPdcInterfaceDataOutput>
        , IGetApPdcInterfaceDataRepository
    {
        public GetApPdcInterfaceDataRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }

    public class GetArPdcInterfaceDataRepository : ERPProcedureRepositoryBase<ArPdcInterface, long, GetArPdcInterfaceDataInput, GetArPdcInterfaceDataOutput>
        , IGetArPdcInterfaceDataRepository
    {
        public GetArPdcInterfaceDataRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
