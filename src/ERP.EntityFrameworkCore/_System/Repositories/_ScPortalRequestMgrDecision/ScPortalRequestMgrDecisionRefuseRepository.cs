using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._ScPortalRequestMgrDecision;
using ERP._System.__AidModule._ScPortalRequestMgrDecision.Procs;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._ScPortalRequestMgrDecision
{
    public class ScPortalRequestMgrDecisionRefuseRepository :
        ERPProcedureRepositoryBase<ScPortalRequestMgrDecision, long, PostDto, PostOutput>, IScPortalRequestMgrDecisionRefuseRepository
    {
        public ScPortalRequestMgrDecisionRefuseRepository(IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider)
               : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
