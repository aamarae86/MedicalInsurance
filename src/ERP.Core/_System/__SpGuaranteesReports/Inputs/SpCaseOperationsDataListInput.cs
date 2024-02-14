using Abp.Domain.Entities;
using System;

namespace ERP._System.__SpGuaranteesReports.Inputs
{
    public class SpCaseOperationsDataListInputHelper : IMustHaveTenant
    {
        public long? CaseId { get; set; }

        public long? NewCaseId { get; set; }

        public long? SpBeneficentId { get; set; }

        public long? TypeId { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string Lang { get; set; }

        public int TenantId { get; set; }

        public override string ToString() =>
            $"?CaseId={CaseId}" +
            $"&ToDate={ToDate}" +
            $"&FromDate={FromDate}" +
            $"&TypeId={TypeId}" +
            $"&TenantId={TenantId}" +
            $"&SpBeneficentId={SpBeneficentId}" +
            $"&NewCaseId={NewCaseId}&Lang={Lang}";
    }

    public class SpCaseOperationsDataListInput : IMustHaveTenant
    {
        public long? CaseId { get; set; }

        public long? NewCaseId { get; set; }

        public long? SpBeneficentId { get; set; }

        public long? TypeId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Lang { get; set; }

        public int TenantId { get; set; }
    }
}
