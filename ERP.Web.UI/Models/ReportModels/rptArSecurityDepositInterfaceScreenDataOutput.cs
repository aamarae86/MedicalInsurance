using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptArSecurityDepositInterfaceScreenDataOutput
    {
        public string SecurityDepositInterfaceNumber { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }
        public string NameSrc { get; set; }
        public string NameStat { get; set; }
        public string CustomerNameAr { get; set; }
        public int CustomerNumber { get; set; }
    }
}