using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArSecurityDepositInterface.Input
{
    public class GetArSecurityDepositInterfacerptInput
    {
        public long? ArCustomerId { get; set; }
        public long? StatusLkpId { get; set; }
        public string Lang { get; set; }
        public int TenantId { get; set; }
    }

    public class GetArSecurityDepositInterfacerptInputHelper
    {
        public long? ArCustomerId { get; set; }
        public string ArCustomerIdtxt { get; set; }
        public long? StatusLkpId { get; set; }
        public string StatusLkpIdtxt { get; set; }
        public string Lang { get; set; }
        public int TenantId { get; set; }
        public override string ToString()
        {
            return $"?Lang={Lang}&ArCustomerId={ArCustomerId}&StatusLkpId={StatusLkpId}&TenantId={TenantId}";
        }
    }
}
