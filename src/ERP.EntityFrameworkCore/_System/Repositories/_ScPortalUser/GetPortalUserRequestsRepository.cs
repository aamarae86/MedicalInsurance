using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._Portal.Stored.Dto;
using ERP.Authorization.Users;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._ScPortalUser
{
    public class GetPortalUserRequestsRepository :
        ERPProcedureRepositoryBase<PortalUser, long, UsersAidsInputDto, UsersAidsOutputDto>, IGetPortalUserRequestsRepository
    {
        public GetPortalUserRequestsRepository(
            IDbContextProvider<ERPDbContext> dbContextProvider,
            IActiveTransactionProvider activeTransactionProvider)
            : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
