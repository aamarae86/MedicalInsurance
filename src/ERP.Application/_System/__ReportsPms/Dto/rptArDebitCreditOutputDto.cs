using Abp.AutoMapper;
using ERP._System.__ReportsPms.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsPms.Dto
{
    [AutoMap(typeof(rptArDebitCreditOutput))]
    public class rptArDebitCreditOutputDto
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
