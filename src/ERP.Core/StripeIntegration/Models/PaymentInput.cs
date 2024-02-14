using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.StripeIntegration.Models
{
    public class PaymentInput
    {
        public string Domain { get; set; }
        public long UnitAmount { get; set; }
        public string Currency { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

    }
}
