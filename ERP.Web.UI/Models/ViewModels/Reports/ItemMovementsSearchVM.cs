using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Web.UI.Models.ViewModels.Reports
{
    public class ItemMovementsSearchVM
    {
        public long? IvItemId { get; set; }
        public long? IvWarehouseId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public override string ToString() => $"Params.IvItemId={IvItemId}&Params.IvWarehouseId={IvWarehouseId}&Params.FromDate={FromDate}&Params.ToDate={ToDate}";
    }
}
