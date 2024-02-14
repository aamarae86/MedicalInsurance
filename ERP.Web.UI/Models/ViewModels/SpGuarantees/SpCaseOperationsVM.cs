using Abp.Domain.Entities;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.SpGuarantees;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.SpGuarantees
{
    public class SpCaseOperationsVM : Entity<long>
    {
        [Display(Name = nameof(Settings.FromDate), ResourceType = typeof(Settings))]
        public string FromDate { get; set; }

        [Display(Name = nameof(Settings.ToDate), ResourceType = typeof(Settings))]
        public string ToDate { get; set; }

        public string EncId { get; set; }

        public DateTime OperationDate { get; set; }

        [Display(Name = nameof(SpCaseOperations.OperationDate), ResourceType = typeof(SpCaseOperations))]
        public string OperationDateStr { get; set; }

        [Display(Name = nameof(SpCaseOperations.ReasonLkpId), ResourceType = typeof(SpCaseOperations))]
        public long ReasonLkpId { get; set; }

        public long OperationTypeLkpId { get; set; }

        public long SpContractDetailsId { get; set; }

        [Display(Name = nameof(SpCaseOperations.ContractNumber), ResourceType = typeof(SpCaseOperations))]
        public string ContractNumber { get; set; }

        [Display(Name = nameof(SpCaseOperations.BeneficentName), ResourceType = typeof(SpCaseOperations))]
        public string BeneficentName { get; set; }

        [Display(Name = nameof(SpCaseOperations.BeneficentName), ResourceType = typeof(SpCaseOperations))]
        public long BeneficentId { get; set; }

        [Display(Name = nameof(SpCaseOperations.BeneficentNumber), ResourceType = typeof(SpCaseOperations))]
        public string BeneficentNumber { get; set; }

        [Display(Name = nameof(SpCaseOperations.CaseDate), ResourceType = typeof(SpCaseOperations))]
        public string CaseDate { get; set; }

        [Display(Name = nameof(SpCaseOperations.CaseNumber), ResourceType = typeof(SpCaseOperations))]
        public string CaseNumber { get; set; }

        [Display(Name = nameof(SpCaseOperations.CaseName), ResourceType = typeof(SpCaseOperations))]
        public long CaseId { get; set; }
        public string CaseName { get; set; }

        [Display(Name = nameof(SpCaseOperations.NewCaseId), ResourceType = typeof(SpCaseOperations))]
        public long NewCaseId { get; set; }

        [Display(Name = nameof(SpCaseOperations.NewCaseNumber), ResourceType = typeof(SpCaseOperations))]
        public string NewCaseNumber { get; set; }

        public string SponsorLkpNameAr { get; set; }

        public string SponsorLkpNameEn { get; set; }
    }
}