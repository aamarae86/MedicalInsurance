using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using ERP.MultiTenancy;
using ERP.MultiTenancy.Input;
using ERP.MultiTenancy.Output;
using ERP.MultiTenancy.Proc;

namespace ERP._System.Repositories
{
    public class PrepareTenantDataRepository :
        ERPProcedureRepositoryBase<Tenant, int, PrepareTenantDataInput, PrepareTenantDataOutput>
        ,
        IPrepareTenantDataRepository
    {
        public PrepareTenantDataRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}
