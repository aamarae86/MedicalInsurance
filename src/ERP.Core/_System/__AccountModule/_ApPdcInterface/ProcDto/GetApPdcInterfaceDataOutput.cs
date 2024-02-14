using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ApPdcInterface.ProcDto
{
    public class GetApPdcInterfaceDataOutput
    {
        public string CheckNumber { get; set; }

        public decimal Amount { get; set; }

        //------------------------
        public string SourceName { get; set; }
        public DateTime MaturityDate { get; set; }
        public string SourceNumber { get; set; }
        public string BankAccountName { get; set; }
        public string Notes { get; set; }

        public string StatusName { get; set; }
        public long StatusLkpId { get; set; }
    }
}
