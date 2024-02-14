using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._ScCampains;
using ERP._System.__AidModule._ScCampains.Procs;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._ScCampains
{
    public class ScCampainsPostRepository :
             ERPProcedureRepositoryBase<ScCampains, long, PostDto, PostOutput>, IScCampainsPostRepository
    {
        public ScCampainsPostRepository(IDbContextProvider<ERPDbContext> dbContextProvider,
            IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }

    }
}
