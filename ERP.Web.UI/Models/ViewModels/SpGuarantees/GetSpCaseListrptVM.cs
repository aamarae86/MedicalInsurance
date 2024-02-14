using Abp.Domain.Entities;
using ERP.ResourcePack.SpGuarantees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.SpGuarantees
{
    public class GetSpCaseListrptVM : Entity<long>
    {
        [Display(Name = nameof(SpGuaranteesReports.CaseId), ResourceType = typeof(SpGuaranteesReports))]
        public long? CaseId { get; set; }
        public string CaseName { get; set; }
        [Display(Name = nameof(SpGuaranteesReports.CaseNumber), ResourceType = typeof(SpGuaranteesReports))]
        public string CaseNumber { get; set; }
        [Display(Name = nameof(SpGuaranteesReports.SpBeneficentId), ResourceType = typeof(SpGuaranteesReports))]
        public long? SpBeneficentId { get; set; }
        public string SpBeneficentName { get; set; }
        [Display(Name = nameof(SpGuaranteesReports.SpBeneficentNumber), ResourceType = typeof(SpGuaranteesReports))]
        public string SpBeneficentNumber { get; set; }
        [Display(Name = nameof(SpGuaranteesReports.StatuesId), ResourceType = typeof(SpGuaranteesReports))]
        public long? StatuesId { get; set; }
        public string StatuesName { get; set; }
        public string Lang { get; set; }
        public int TenantId { get; set; } = 0;
        public override string ToString() =>
            $"?Lang={Lang}" +
            $"&SpBeneficentId={SpBeneficentId}" +
            $"&CaseId={CaseId}" +
            $"&StatuesId={StatuesId}" +
            $"&TenantId={TenantId}";
    }
}