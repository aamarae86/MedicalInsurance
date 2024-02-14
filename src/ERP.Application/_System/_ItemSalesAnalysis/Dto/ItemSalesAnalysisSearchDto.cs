using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ItemSalesAnalysis.Dto
{
   public class ItemSalesAnalysisSearchDto
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public long? TrItemId { get; set; }
        public long? IvItemsTypesConfigureId { get; set; }
    }
}
