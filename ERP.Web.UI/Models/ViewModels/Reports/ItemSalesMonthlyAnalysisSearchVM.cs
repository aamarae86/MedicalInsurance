using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Reports
{
    public class ItemSalesMonthlyAnalysisSearchVM
    {
        public string Year { get; set; }
        public long? TrItemId { get; set; }
        public long? IvItemsTypesConfigureId { get; set; }
        public override string ToString() => $"Params.TrItemId={TrItemId}&Params.IvItemsTypesConfigureId={IvItemsTypesConfigureId}&Params.Year={Year}";
    }
}