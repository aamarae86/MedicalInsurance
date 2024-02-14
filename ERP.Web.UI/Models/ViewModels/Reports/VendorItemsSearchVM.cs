using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Web.UI.Models.ViewModels.Reports
{
    public class VendorItemsSearchVM
    {
        public long? VendorId { get; set; }
        public string TenantName { get; set; }
       
        // public long? IvWarehouseId { get; set; }
        public bool? IsNotSettled { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Lang { get; set; }
        
        public override string ToString() => $"Params.VendorId={VendorId}&Params.FromDate={FromDate}&Params.ToDate={ToDate}&Params.IsNotSettled={IsNotSettled}";
    }
}
