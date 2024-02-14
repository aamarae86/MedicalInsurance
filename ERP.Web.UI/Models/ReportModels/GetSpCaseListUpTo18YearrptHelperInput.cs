using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class GetSpCaseListUpTo18YearrptHelperInput
    {
        public long? SpBeneficentId { get; set; }
        public string SpBeneficentIdtxt { get; set; }
        public string SpBeneficentIdNum { get; set; }
        public long? SponsorCategory { get; set; }
        public string SponsorCategorytxt { get; set; }
        public string Lang { get; set; }
        public int TenantId { get; set; }
        public override string ToString()
        {
            return $"?Lang={Lang}&TenantId={TenantId}&SponsorCategory={SponsorCategory}&SpBeneficentId={SpBeneficentId}";
        }
    }
}