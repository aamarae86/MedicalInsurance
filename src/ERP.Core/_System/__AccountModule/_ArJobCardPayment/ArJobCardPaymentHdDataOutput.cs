using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArJobCardPayment
{
    public class ArJobCardPaymentHdDataOutput
    {

        public string JobNumber { get; set; }


        public string SourceNameAr { get; set; }
        public string SourceNameEn { get; set; }
        public string PaymentDate { get; set; }
        public string Notes { get; set; }
        public decimal? Amount { get; set; }

        public string CustomerNameAr { get; set; }
        public string CustomerNameEn { get; set; }


    }
}
