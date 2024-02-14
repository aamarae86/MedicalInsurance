using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptGlAccBalanceOutput
    {
        public string level_desc { get; set; }

        public string acc_code { get; set; }

        public string ACC_DESC { get; set; }

        public decimal balance { get; set; }

        public decimal debit { get; set; }

        public decimal credit { get; set; }

        public decimal obdebit { get; set; }

        public decimal obcredit { get; set; }

        public decimal DeptOBCalc { get; set; }

        public decimal CreditOBCalc { get; set; }

        public decimal EndDept { get; set; }

        public decimal EndCredit { get; set; }

        public string entity_id { get; set; }

        public bool IsAccount { get; set; }
    }
}