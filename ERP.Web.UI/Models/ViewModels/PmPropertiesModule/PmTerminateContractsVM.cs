using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class PmTerminateContractsVM : BasePostAuditedVM<long>
    {
        [Display(Name = nameof(ArCustomers.ContractNumber), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? PmContractId { get; set; }

        [Display(Name = nameof(ArCustomers.Status), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? StatusLkpId { get; set; }

        [Display(Name = nameof(ArCustomers.OperationDate), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string TerminationDate { get; set; }

        [Display(Name = nameof(ArCustomers.OperationNumber), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(30)]
        public string TerminationNumber { get; set; }

        [Display(Name = nameof(ArCustomers.FineAmount), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal? FineAmount { get; set; }

        [Display(Name = nameof(ArCustomers.Notes), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(4000)]
        public string Notes { get; set; }

        [Display(Name = nameof(ArCustomers.IsTransferDepositToCustomer), ResourceType = typeof(ArCustomers))]
        public bool IsTransferDepositToCustomer { get; set; }

        public bool IsTransferDepositToCustomerAlt { get; set; }

        [Display(Name = nameof(ArCustomers.tenantname), ResourceType = typeof(ArCustomers))]
        public long? PmTenantId { get; set; }

        [Display(Name = nameof(ArCustomers.tenantname), ResourceType = typeof(ArCustomers))]
        public string PmTenantName { get; set; }

        [Display(Name = nameof(ArCustomers.StartDate), ResourceType = typeof(ArCustomers))]
        public string StartDate { get; set; }

        [Display(Name = nameof(ArCustomers.EndDate), ResourceType = typeof(ArCustomers))]
        public string EndDate { get; set; }

        [Display(Name = nameof(ArCustomers.ContractAmount), ResourceType = typeof(ArCustomers))]
        public string ContractAmount { get; set; }

        public string Lang { get; set; }

        public FndLookupValuesVM FndLookupValuesPmTerminateContractsStatusLkp { get; set; }

        public PmContractVM PmContract { get; set; }
    }
}