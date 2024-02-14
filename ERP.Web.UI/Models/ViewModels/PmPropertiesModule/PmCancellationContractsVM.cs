using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class PmCancellationContractsVM : BasePostAuditedVM<long>
    {
        [Display(Name = nameof(ArCustomers.OperationNumber), ResourceType = typeof(ArCustomers))]
        [MaxLength(30)]
        public string CancellationNumber { get; set; }

        [Display(Name = nameof(ArCustomers.OperationDate), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string CancellationDate { get; set; }

        [Display(Name = nameof(ArCustomers.Status), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? StatusLkpId { get; set; }

        [Display(Name = nameof(ArCustomers.ContractNumber), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? PmContractId { get; set; }

        [Display(Name = nameof(ArCustomers.FinePeriodPerDays), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public int? FinePeriodPerDays { get; set; }

        [Display(Name = nameof(ArCustomers.FineAmount), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal? FineAmount { get; set; }

        [Display(Name = nameof(ArCustomers.Notes), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(4000)]
        public string Notes { get; set; }

        public long? AccountId { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }

        [Display(Name = nameof(ArCustomers.tenantname), ResourceType = typeof(ArCustomers))]
        public long? PmTenantName { get; set; }

        [Display(Name = nameof(ArCustomers.tenantname), ResourceType = typeof(ArCustomers))]
        public string PmTenantNameShow { get; set; }

        [Display(Name = nameof(ArCustomers.StartDate), ResourceType = typeof(ArCustomers))]
        public string StartDate { get; set; }

        [Display(Name = nameof(ArCustomers.EndDate), ResourceType = typeof(ArCustomers))]
        public string EndDate { get; set; }

        [Display(Name = nameof(ArCustomers.ContractAmount), ResourceType = typeof(ArCustomers))]
        public string ContractAmount { get; set; }

        [Display(Name = nameof(ArCustomers.FinePeriodPerDaysAmount), ResourceType = typeof(ArCustomers))]
        public string FinePeriodPerDaysAmount { get; set; }

        [Display(Name = nameof(ArCustomers.ReturnedAmount), ResourceType = typeof(ArCustomers))]
        public string ReturnedAmount { get; set; }

        public FndLookupValuesVM FndLookupValues { get; set; }
        public PmContractVM PmContract { get; set; }
    }
}