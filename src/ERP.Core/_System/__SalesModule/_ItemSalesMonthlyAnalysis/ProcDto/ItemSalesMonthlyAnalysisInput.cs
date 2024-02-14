using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SalesModule._ItemSalesMonthlyAnalysis
{
   public class ItemSalesMonthlyAnalysisInput
    {
        public long? TrItemId { get; set; }
        public long? IvItemsTypesConfigureId { get; set; }
        public string Year { get; set; }
        public string Lang { get; set; }
        public long TenantId { get; set; }
    }
}
