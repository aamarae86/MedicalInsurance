using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._ArJobSurveyHd;
using ERP._System.__AccountModule._ArJobSurveyHd.Proc;
using ERP._System.__Warehouses._IvStoreIssue;
using ERP._System.__Warehouses._IvStoreIssue.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class GetrptArJobSurveyPostRepository :
    ERPProcedureRepositoryBase<ArJobSurveyHd, long, GetrptArJobSurveyPostInput, PostOutput>,
    IGetrptArJobSurveyPostRepository
    {
        public GetrptArJobSurveyPostRepository(
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
