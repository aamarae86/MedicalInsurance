using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAccounts.Outputs
{
    public class GetFaAssetListDataOutput
    {
        public string CategoryName { get; set; }
        public long CategoryId { get; set; }
        public string StatusName { get; set; }
        public string AssetNumber { get; set; }
        public DateTime DatePlacedInService { get; set; }
        public int LifeInMonths { get; set; }
        public string Decsription { get; set; }
        public decimal CurrentCost { get; set; }
        public decimal OriginalCost { get; set; }
    }
}
