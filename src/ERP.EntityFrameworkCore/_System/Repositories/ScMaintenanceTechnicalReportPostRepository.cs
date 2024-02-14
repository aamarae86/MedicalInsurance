using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories
{
    public class ScMaintenanceTechnicalReportPostRepository : ERPProcedureRepositoryBase<ScMaintenanceTechnicalReport, long, PostDto, PostOutput>,
        IScMaintenanceTechnicalReportPostRepository
    {
        public ScMaintenanceTechnicalReportPostRepository(
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}
