using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptArDebitCreditHelperInput
    {
        public long? CustomerId { get; set; }
        public string Customertxt { get; set; }
        public string CustomerNumber { get; set; }
        public int? TenantId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Lang { get; set; }
        public bool IsNotSettled { get; set; }
        public override string ToString()
        {
            return $"?Lang={Lang}&ToDate={ToDate}&FromDate={FromDate}&TenantId={TenantId}&CustomerId={CustomerId}&IsNotSettled={IsNotSettled}";
        }
    }
}