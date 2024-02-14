using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptGlAccProLosOutput
    {
        public int level_desc { get; set; }

        public string acc_code { get; set; }

        public string ACC_DESC { get; set; }

        public decimal Amount { get; set; }

        public decimal OB_Amount { get; set; }
    }
}