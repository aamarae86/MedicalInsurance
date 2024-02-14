using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SalesModule._ItemSalesAnalysis.ProcDto
{
  public  class ItemSalesAnalysisInput
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long? TrItemId { get; set; }
        public long? IvItemsTypesConfigureId { get; set; }
        public string Lang { get; set; }
        public long TenantId { get; set; }
    }
}
