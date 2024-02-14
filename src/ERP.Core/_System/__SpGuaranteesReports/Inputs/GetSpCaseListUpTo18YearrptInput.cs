using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SpGuaranteesReports.Inputs
{
    public class GetSpCaseListUpTo18YearrptInput
    {
        public long? SpBeneficentId { get; set; }
        public long? SponsorCategory { get; set; }
        public string Lang { get; set; }
        public int TenantId { get; set; }
    }
}
