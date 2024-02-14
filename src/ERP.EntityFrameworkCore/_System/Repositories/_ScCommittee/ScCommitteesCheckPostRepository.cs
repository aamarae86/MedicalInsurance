using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScCommittee.Proc;
using ERP._System.__AidModule._ScCommitteesCheck;
using ERP._System.__AidModule._ScCommitteesCheck.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._ScCommittee
{
    public class ScCommitteesCheckPostRepository: ERPProcedureRepositoryBase<ScCommitteesCheck, long, PostDto, PostOutput>,
        IScCommitteesCheckPostRepository
    {
        public ScCommitteesCheckPostRepository(
               IDbContextProvider<ERPDbContext> dbContextProvider,
               IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
