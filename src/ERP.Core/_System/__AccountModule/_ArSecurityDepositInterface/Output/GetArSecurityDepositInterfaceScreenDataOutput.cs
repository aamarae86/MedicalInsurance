using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArSecurityDepositInterface.Output
{
    public class GetArSecurityDepositInterfaceScreenDataOutput
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
