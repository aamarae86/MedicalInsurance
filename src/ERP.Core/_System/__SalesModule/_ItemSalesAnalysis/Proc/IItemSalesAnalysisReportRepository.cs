using ERP._System.__SalesModule._ItemSalesAnalysis.ProcDto;
using ERP._System.__SalesModule._IvReturnSaleHd;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SalesModule._ItemSalesAnalysis.Proc
{
  public  interface IItemSalesAnalysisReportRepository :
       IExecuteProcedure<IvReturnSaleHd, long, ItemSalesAnalysisInput, ItemSalesAnalysisOutput>
    {
    }
}
