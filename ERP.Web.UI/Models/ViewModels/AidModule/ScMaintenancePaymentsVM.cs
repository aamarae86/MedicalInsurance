using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScMaintenancePaymentsVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(ScMaintenancePayments.MaintenancePaymentNumber), ResourceType = typeof(ScMaintenancePayments))]
        public string MaintenancePaymentNumber { get; set; }

        [Display(Name = nameof(ScMaintenancePayments.MaintenanceContractDate), ResourceType = typeof(ScMaintenancePayments))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string MaintenancePaymentDate { get; set; }

        [Display(Name = nameof(ScMaintenancePayments.StatusLkpId), ResourceType = typeof(ScMaintenancePayments))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(ScMaintenancePayments.ScMaintenanceContractPaymentId), ResourceType = typeof(ScMaintenancePayments))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long ScMaintenanceContractPaymentId { get; set; }

        [Display(Name = nameof(ScMaintenancePayments.ScMaintenanceContractId), ResourceType = typeof(ScMaintenancePayments))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long ScMaintenanceContractId { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ScMaintenancePayments.Notes), ResourceType = typeof(ScMaintenancePayments))]
        public string Notes { get; set; }

        [Display(Name = nameof(ScMaintenancePayments.AchievementRate), ResourceType = typeof(ScMaintenancePayments))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal AchievementRate { get; set; }

        [Display(Name = nameof(ScMaintenancePayments.Amount), ResourceType = typeof(ScMaintenancePayments))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal Amount { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.PortalRequestNumber), ResourceType = typeof(ScMaintenanceQuotations))]
        public string PortalRequestNumber { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.PortalUserName), ResourceType = typeof(ScMaintenanceQuotations))]
        public string PortalUserName { get; set; }

        [Display(Name = nameof(ScMaintenanceContract.MaintenanceContractNumber), ResourceType = typeof(ScMaintenanceContract))]
        public string MaintenanceContractNumber { get; set; }

        public string MaintenanceContractPaymentsNumber { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.VendorId), ResourceType = typeof(ScMaintenanceQuotations))]
        public string Vendor { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.VendorId), ResourceType = typeof(ScMaintenanceQuotations))]
        public long VendorId { get; set; }

        [Display(Name = nameof(ResourcePack.Accounts.ApMiscPaymentHeaders.MaturityDate), ResourceType = typeof(ResourcePack.Accounts.ApMiscPaymentHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string MaturityDate { get; set; }

        public virtual FndLookupValuesVM FndStatusLkp { get; set; }
    }
}