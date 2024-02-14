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
    public class GetBarChartItemSoldbyValueRepository :
        ERPProcedureRepositoryBase<User, long, GetTopGraphHomePageInput, GetBarChartItemSoldbyValueOutput>
        ,
        IGetBarChartItemSoldbyValueRepository
    {
        public GetBarChartItemSoldbyValueRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}
