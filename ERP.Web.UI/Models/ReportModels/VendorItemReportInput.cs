using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class VendorItemReportInput
    {
        public long? VendorId { get; set; }
        // public long? IvWarehouseId { get; set; }
        public bool? IsNotSettled { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Lang { get; set; }



        public long TenantId { get; set; }
        public override string ToString()
        {
            return $"?Lang={Lang}&ToDate={ToDate}&VendorId={VendorId}&FromDate={FromDate}&TenantId={TenantId}&IsNotSettled={IsNotSettled}";
        }
    }
}