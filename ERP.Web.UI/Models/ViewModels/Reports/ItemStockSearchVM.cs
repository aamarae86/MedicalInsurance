using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Web.UI.Models.ViewModels.Reports
{
    public class ItemStockSearchVM
    {
        public long? ItemId { get; set; }
        public long? IvWarehouseId { get; set; }
        public string ShowZero { get; set; }
       
        public override string ToString() => $"Params.ItemId={ItemId}&Params.IvWarehouseId={IvWarehouseId}&Params.ShowZero={ShowZero}";
    }
}
