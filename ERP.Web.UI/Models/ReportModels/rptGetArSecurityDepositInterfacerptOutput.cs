using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptGetArSecurityDepositInterfacerptOutput
    {
        public string SecurityDepositInterfaceNumber { get; set; }
        public string SourceLkpNameAr { get; set; }
        public string SourceNo { get; set; }
        public DateTime CreationTime { get; set; }
        public int CustomerNumber { get; set; }
        public string CustomerNameAr { get; set; }
        public decimal Amount { get; set; }
    }
}