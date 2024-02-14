using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArJobCardPaymentHd.Dto
{
    public class ArJobCardPaymentHdSearchDto
    {
        public string TransactionDate { get; set; }
        public long? StatusLkpId { get; set; }
        public string JobNumberLkpId{ get; set; }
        public long? CustomerLkpId { get; set; }
        //public string CustomerNameAr { get; set; }
        public override string ToString() => $"Params.CustomerLkpId={CustomerLkpId}&Params.TransactionDate={TransactionDate}&Params.StatusLkpId={StatusLkpId}&Params.JobNumberLkpId={JobNumberLkpId}";
    }
}
