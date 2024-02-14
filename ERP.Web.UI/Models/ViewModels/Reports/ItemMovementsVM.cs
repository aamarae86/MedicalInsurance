using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Web.UI.Models.ViewModels.Reports
{
    public class ItemMovementsVM
    {
        public string Id { get; set; } = "1";
        public string Date { get; set; }
        public decimal QtyIn { get; set; }
        public decimal QtyOut { get; set; }
        public decimal Balance { get; set; }
        public string TranType { get; set; }
        public string InvNo { get; set; }
        public string Customer { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
