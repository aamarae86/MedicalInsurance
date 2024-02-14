using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SpGuaranteesReports.Inputs
{
    public class GetSpCaseListrptInput : IMustHaveTenant
    {
        public long? CaseId { get; set; }
        public long? SpBeneficentId { get; set; }
        public long? StatuesId { get; set; }
        public string Lang { get; set; }
        public int TenantId { get; set; }

        public override string ToString() =>
            $"?Lang={Lang}" +
            $"&SpBeneficentId={SpBeneficentId}" +
            $"&CaseId={CaseId}" +
            $"&StatuesId={StatuesId}" +
            $"&TenantId={TenantId}";
    }
}
