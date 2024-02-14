using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.Home.Input;
using ERP._System.Home.Ouput;
using ERP._System.Home.Proc;
using ERP.Authorization.Users;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using ERP.MultiTenancy.Input;
using ERP.MultiTenancy.Output;

namespace ERP._System.Repositories
{
    public class GetTopGraphHomePageRepository :
        ERPProcedureRepositoryBase<User, long, GetTopGraphHomePageInput, GetTopGraphHomePageOutput>
        ,
        IGetTopGraphHomePageRepository
    {
        public GetTopGraphHomePageRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}
