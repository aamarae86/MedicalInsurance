using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptArDebitCreditHelperInputSearchVM
    {
        public long? CustomerId { get; set; }
        public string Customertxt { get; set; }
        public string CustomerNumber { get; set; }
        public int? TenantId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Lang { get; set; }
        public bool IsNotSettled { get; set; }
        public override string ToString() => $"Params.Lang={Lang}&Params.FromDate={FromDate}&Params.ToDate={ToDate}&Params.IsNotSettled={IsNotSettled}&Params.TenantId={TenantId}&Params.CustomerId={CustomerId}";
    }
}