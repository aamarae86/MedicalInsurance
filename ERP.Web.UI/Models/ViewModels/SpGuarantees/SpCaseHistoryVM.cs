using Abp.Domain.Entities.Auditing;
using ERP.ResourcePack.SpGuarantees;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.SpGuarantees
{
    public class SpCaseHistoryVM : AuditedEntity<long>
    {
        [Display(Name = nameof(SpCaseHistory.OprationDate), ResourceType = typeof(SpCaseHistory))]
        public string OprationDateStr => this.CreationTime.ToString("yyyy-MM-dd");

        [Display(Name = nameof(SpCaseHistory.SpCaseId), ResourceType = typeof(SpCaseHistory))]
        public long SpCaseId { get; set; }

        [Display(Name = nameof(SpCaseHistory.OperationTypeLkpId), ResourceType = typeof(SpCaseHistory))]
        public long OperationTypeLkpId { get; set; }

        [Display(Name = nameof(SpCaseHistory.CaseStatusLkpId), ResourceType = typeof(SpCaseHistory))]
        public long CaseStatusLkpId { get; set; }

        [Display(Name = nameof(SpCaseHistory.BeneficentId), ResourceType = typeof(SpCaseHistory))]
        public long BeneficentId { get; set; }

        [Display(Name = nameof(SpCaseHistory.SourceId), ResourceType = typeof(SpCaseHistory))]
        public long? SourceId { get; set; }

        [Display(Name = nameof(SpCaseHistory.OperationNotes), ResourceType = typeof(SpCaseHistory))]
        public string OperationNotes { get; set; }

        [Display(Name = nameof(SpCaseHistory.CreatedBy), ResourceType = typeof(SpCaseHistory))]
        public string Creator { get; set; }

        public SpCasesVM SpCases { get; set; }

        public SpBeneficentVM SpBeneficent { get; set; }

        public FndLookupValuesVM FndOperationTypeLkp { get; set; }

        public FndLookupValuesVM FndCaseStatusLkp { get; set; }
    }
}