using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScCommittee.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._ScCommittee
{
    public class ScCommitteePostRepository : ERPProcedureRepositoryBase<ScCommittee, long, PostDto, PostOutput>,
        IScCommitteePostRepository
    {
        public ScCommitteePostRepository(IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
