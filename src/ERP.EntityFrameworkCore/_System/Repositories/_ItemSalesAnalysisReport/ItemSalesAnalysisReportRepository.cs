using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__SalesModule._ItemSalesAnalysis.Proc;
using ERP._System.__SalesModule._ItemSalesAnalysis.ProcDto;
using ERP._System.__SalesModule._IvReturnSaleHd;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._ItemSalesAnalysisReport
{
  public  class ItemSalesAnalysisReportRepository : ERPProcedureRepositoryBase<IvReturnSaleHd, long, ItemSalesAnalysisInput, ItemSalesAnalysisOutput>, IItemSalesAnalysisReportRepository
    {
        public ItemSalesAnalysisReportRepository(
                 IDbContextProvider<ERPDbContext> dbContextProvider,
                 IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider) { }
    }
}
