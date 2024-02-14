using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Reports
{
    public class ItemSalesAnalysisSearchVM
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public long? TrItemId { get; set; }
        public long? IvItemsTypesConfigureId { get; set; }
        public override string ToString() => $"Params.TrItemId={TrItemId}&Params.IvItemsTypesConfigureId={IvItemsTypesConfigureId}&Params.FromDate={FromDate}&Params.ToDate={ToDate}";
    }
}