using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptArDebitCreditVM
    {
        public decimal CrAmount { get; set; }
        public decimal DrAmount { get; set; }
        public int CustomerNumber { get; set; }
        public string CustomerNameAr { get; set; }
        public long ArCustomerId { get; set; }
        public string DocDate { get; set; }
        public string Source { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string tel { get; set; }
        public string Comments { get; set; }
        public decimal Balance { get; set; }
    }
}