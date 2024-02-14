using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAccounts.Inputs
{
    public class PrepareRPTInput
    {
        public long PERIOD_ID_From { get; set; }

        public long PERIOD_ID_To { get; set; }

        public long user_id { get; set; }
        public string lang { get; set; }
    }
}
