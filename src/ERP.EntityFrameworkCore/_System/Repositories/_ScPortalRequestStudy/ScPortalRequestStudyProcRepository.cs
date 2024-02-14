using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP._System.__AidModule._ScPortalRequestStudy.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._ScPortalRequestStudy
{
    public class ScPortalRequestStudyProcRepository : ERPProcedureRepositoryBase<ScPortalRequestStudy, long, PostDto, PostOutput>,
        IScPortalRequestStudyProcRepository
    {
        public ScPortalRequestStudyProcRepository(IDbContextProvider<ERPDbContext> dbContextProvider,
               IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
