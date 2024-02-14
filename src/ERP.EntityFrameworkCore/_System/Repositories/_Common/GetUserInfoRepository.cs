using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._Portal.Stored.Dto;
using ERP.Authorization.Users;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._Common
{
    public class GetUserInfoRepository : ERPProcedureRepositoryBase<PortalUser, long, GetUserInfoInput, User>, IGetUserInfoRepository
    {
        public GetUserInfoRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
