using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._ScCampainsDetail;
using ERP._System.__AidModule._ScCampainsDetail.Procs;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._ScCampains
{
    public class ScCampainsDetailPostRepository :
     ERPProcedureRepositoryBase<ScCampainsDetail, long, PostDto, PostOutput>, IScCampainsDetailPostRepository
    {

        public ScCampainsDetailPostRepository(
             IDbContextProvider<ERPDbContext> dbContextProvider,
             IActiveTransactionProvider activeTransactionProvider)
            : base(dbContextProvider, activeTransactionProvider)
        { }


    }
}
