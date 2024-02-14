using ERP._System.__SalesModule._ItemSalesMonthlyAnalysis.ProcDto;
using ERP._System.__SalesModule._IvReturnSaleHd;

namespace ERP._System.__SalesModule._ItemSalesMonthlyAnalysis.Proc
{
    public interface IItemSalesMonthlyAnalysisReportRepository :
       IExecuteProcedure<IvReturnSaleHd, long, ItemSalesMonthlyAnalysisInput, ItemSalesMonthlyAnalysisOutput>
    {
    }

}
