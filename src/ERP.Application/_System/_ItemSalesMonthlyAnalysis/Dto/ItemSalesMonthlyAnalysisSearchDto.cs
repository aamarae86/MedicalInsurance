using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ItemSalesMonthlyAnalysis.Dto
{
   public class ItemSalesMonthlyAnalysisSearchDto
    {
        public string Year { get; set; }
        public long? TrItemId { get; set; }
        public long? IvItemsTypesConfigureId { get; set; }
    }
}
