using Abp.Domain.Entities;
using System;

namespace ERP._System.__AccountModule._ApPdcInterface.ProcDto
{
    public class GetApPdcInterfaceDataInput : IMustHaveTenant
    {
        public long? BankAccountId { get; set; }
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public long? StatusLkpId { get; set; }

        public int TenantId { get; set; }
    }

    public class GetApPdcInterfaceDataInputHelper
    {
        public long? BankAccountId { get; set; }
        public string FromDate { get; set; }

        public string Lang { get; set; }
        public string ToDate { get; set; }

        public long? StatusLkpId { get; set; }

        public string StatusLkpIdtxt { get; set; }

        public override string ToString() => $"?BankAccountId={BankAccountId}&FromDate={FromDate}&ToDate={ToDate}&StatusLkpId={StatusLkpId}";
    }
}
