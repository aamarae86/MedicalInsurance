using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModuleExtend._ApPaymentsTransactions.Dto
{
    public class ApPaymentsTransactionsSearchDto
    {
        public string PaymentNumber { get; set; }

        public string PaymentDate { get; set; }

        public long? StatusLkpId { get; set; }

        public long? VendorId { get; set; }

        public override string ToString()
           => $"Params.PaymentNumber={PaymentNumber}&Params.PaymentDate={PaymentDate}&Params.StatusLkpId={StatusLkpId}&Params.VendorId={VendorId}";

    }
}
