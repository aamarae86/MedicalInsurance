using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._ScPortalRequest;
using ERP._System.__AidModule._ScPortalRequest.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._ScPortalRequest
{
    public class ScPortalRequestPostRepository : ERPProcedureRepositoryBase<ScPortalRequest, long, PostDto, PostOutput>,
        IScPortalRequestPostRepository
    {
        public ScPortalRequestPostRepository(
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
