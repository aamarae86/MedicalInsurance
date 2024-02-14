using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsPms.Output
{
    public class rptArDebitCreditOutput
    {
        public decimal CrAmount { get; set; }
        public decimal DrAmount { get; set; }
        public int CustomerNumber { get; set; }
        public string CustomerNameAr { get; set; }
        public long ArCustomerId { get; set; }
        public DateTime DocDate { get; set; }
        public string Source { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string tel { get; set; }
        public string Comments { get; set; }
    }
}
