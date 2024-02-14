using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Web.UI.Models.ViewModels.Reports
{
    public class ItemStockVM
    {
        public long Id { get; set; }
        public string ItemName { get; set; }
        public string ItemNumber { get; set; }

        public decimal ItemQtys { get; set; }
        public decimal WhQty { get; set; }
    }
}
