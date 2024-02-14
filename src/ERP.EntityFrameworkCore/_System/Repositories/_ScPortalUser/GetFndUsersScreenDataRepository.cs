using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._Portal._PortalFndUsers.Proc;
using ERP._System.__AidModule._Portal._PortalFndUsers.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization.Users;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;


namespace ERP._System.Repositories._ScPortalUser
{
    public class GetFndUsersScreenDataRepository :
           ERPProcedureRepositoryBase<PortalUser, long, IdLangInputDto, FndUsersScreenDataOutput>,
        IGetFndUsersScreenDataRepository
    {
        public GetFndUsersScreenDataRepository(
                    IDbContextProvider<ERPDbContext> dbContextProvider,
                    IActiveTransactionProvider activeTransactionProvider
                ) : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
