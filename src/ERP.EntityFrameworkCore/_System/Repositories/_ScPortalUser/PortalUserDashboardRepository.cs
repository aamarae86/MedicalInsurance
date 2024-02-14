using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System._Portal;
using ERP._System._Portal.Stored.Dto;
using ERP.Authorization.Users;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._ScPortalUser
{
    public class PortalUserDashboardRepository :
        ERPProcedureRepositoryBase<PortalUser, long, DashboardDto, DashboardOutput>
        ,
        IPortalUserDashboardRepository
    {
        public PortalUserDashboardRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}
