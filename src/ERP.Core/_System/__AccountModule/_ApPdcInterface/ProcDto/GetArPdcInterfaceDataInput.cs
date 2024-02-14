using Abp.Domain.Entities;
using System;

namespace ERP._System.__AccountModule._ApPdcInterface.ProcDto
{
    public class GetArPdcInterfaceDataInput : IMustHaveTenant
    {
        
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public long? StatusLkpId { get; set; }

        public int TenantId { get; set; }
    }

    public class GetArPdcInterfaceDataInputHelper
    {
       
        public string FromDate { get; set; }

        public string Lang { get; set; }
        public string ToDate { get; set; }

        public long? StatusLkpId { get; set; }

        public string StatusLkpIdtxt { get; set; }

        public override string ToString() => $"?FromDate={FromDate}&ToDate={ToDate}&StatusLkpId={StatusLkpId}";
    }
}
