using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsPms.Input
{
    public class PmContractNotRenewedInput
    {
        public long? PropertyId { get; set; }
        public long? PMTenantId { get; set; }
        public long? PmUnitTypeLkpId { get; set; }
        public string Lang { get; set; }
        public int TenantId { get; set; }
    }
}
