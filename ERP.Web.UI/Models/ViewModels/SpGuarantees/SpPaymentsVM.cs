using ERP._System.__SpGuarantees._SpPayments.Dto;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.SpGuarantees;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.SpGuarantees
{
    public class SpPaymentsVM : BaseAuditedEntityVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(SpContracts.StatusLkpId), ResourceType = typeof(SpContracts))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(SpContracts.SpCaseId), ResourceType = typeof(SpContracts))]
        public long? SpCaseId { get; set; }

        [Display(Name = nameof(SpPayments.PaymentName), ResourceType = typeof(SpPayments))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string PaymentName { get; set; }

        public string SpCase { get; set; }

        [Display(Name = nameof(SpContracts.CaseStatusLkpId), ResourceType = typeof(SpContracts))]
        public string CaseStatus { get; set; }

        public string CaseStatusLkp { get; set; }

        [Display(Name = nameof(SpContracts.StartDate), ResourceType = typeof(SpContracts))]
        public string StartDate { get; set; }

        [Display(Name = nameof(SpContracts.EndDate), ResourceType = typeof(SpContracts))]
        public string EndDate { get; set; }

        [Display(Name = nameof(SpContracts.Amount), ResourceType = typeof(SpContracts))]
        public decimal? Amount { get; set; }

        [Display(Name = nameof(SpContracts.AccountNumber), ResourceType = typeof(SpContracts))]
        public string AccountNumber { get; set; }

        [Display(Name = nameof(SpContracts.AccountOwnerName), ResourceType = typeof(SpContracts))]
        public string AccountOwnerName { get; set; }

        [Display(Name = nameof(SpContracts.CaseNumber), ResourceType = typeof(SpContracts))]
        public string CaseNumber { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(SpPayments.PaymentNumber), ResourceType = typeof(SpPayments))]
        public string PaymentNumber { get; set; }

        [Display(Name = nameof(SpPayments.FromPeriodId), ResourceType = typeof(SpPayments))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long FromPeriodId { get; set; }

        [Display(Name = nameof(SpPayments.ToPeriodId), ResourceType = typeof(SpPayments))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long ToPeriodId { get; set; }

        [Display(Name = nameof(SpPayments.SponsorCategoryLkpId), ResourceType = typeof(SpPayments))]
        public long? SponsorCategoryLkpId { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(SpPayments.Notes), ResourceType = typeof(SpPayments))]
        public string Notes { get; set; }

        [Display(Name = nameof(SpPayments.Total), ResourceType = typeof(SpPayments))]
        public decimal Total { get; set; }

        [Display(Name = nameof(SpPayments.Period), ResourceType = typeof(SpPayments))]
        public string Period { get; set; }

        [Display(Name = nameof(SpPayments.ContractStartDate), ResourceType = typeof(SpPayments))]
        public string ContractStartDate { get; set; }

        [Display(Name = nameof(SpPayments.ContractEndDate), ResourceType = typeof(SpPayments))]
        public string ContractEndDate { get; set; }

        [Display(Name = nameof(Settings.FromDate), ResourceType = typeof(Settings))]
        public string FromDate { get; set; }

        [Display(Name = nameof(Settings.ToDate), ResourceType = typeof(Settings))]
        public string ToDate { get; set; }

        public virtual FndLookupValuesVM FndStatusLkp { get; set; }

        public virtual FndLookupValuesVM FndSponsorCategoryLkp { get; set; }

        public virtual GlPeriodsDetailsVM FromPeriod { get; set; }

        public virtual GlPeriodsDetailsVM ToPeriod { get; set; }

        public virtual SpCasesVM SpCases { get; set; }
    }
}