using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__SalesModule._ItemSalesMonthlyAnalysis;
using ERP._System.__SalesModule._ItemSalesMonthlyAnalysis.Proc;
using ERP._System.__SalesModule._ItemSalesMonthlyAnalysis.ProcDto;
using ERP._System.__SalesModule._IvReturnSaleHd;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._ItemSalesMonthlyAnalysisReport
{
   public class ItemSalesMonthlyAnalysisReportRepository : ERPProcedureRepositoryBase<IvReturnSaleHd, long, ItemSalesMonthlyAnalysisInput, ItemSalesMonthlyAnalysisOutput>, IItemSalesMonthlyAnalysisReportRepository
    {
        public ItemSalesMonthlyAnalysisReportRepository(
                 IDbContextProvider<ERPDbContext> dbContextProvider,
                 IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider) { }
    }
}
