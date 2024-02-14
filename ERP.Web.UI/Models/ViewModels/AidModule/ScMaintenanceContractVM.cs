using ERP._System.__AidModule._ScMaintenanceContract.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScMaintenanceContractVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(ScMaintenanceContract.MaintenanceContractNumber), ResourceType = typeof(ScMaintenanceContract))]
        public string MaintenanceContractNumber { get; set; }

        [Display(Name = nameof(ScMaintenanceContract.MaintenanceContractDate), ResourceType = typeof(ScMaintenanceContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string MaintenanceContractDate { get; set; }

        [Display(Name = nameof(ScMaintenanceContract.ScMaintenanceQuotationId), ResourceType = typeof(ScMaintenanceContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long ScMaintenanceQuotationId { get; set; }

        [Display(Name = nameof(ScMaintenanceContract.StatusLkpId), ResourceType = typeof(ScMaintenanceContract))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(ScMaintenanceContract.DurationOfImplementation), ResourceType = typeof(ScMaintenanceContract))]
        public string DurationOfImplementation { get; set; }

        [Display(Name = nameof(ScMaintenanceContract.StartDate), ResourceType = typeof(ScMaintenanceContract))]
        public string StartDate { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ScMaintenanceContract.ContractTerms), ResourceType = typeof(ScMaintenanceContract))]
        public string ContractTerms { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ScMaintenanceContract.OtherContractTerms), ResourceType = typeof(ScMaintenanceContract))]
        public string OtherContractTerms { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ScMaintenanceContract.Notes), ResourceType = typeof(ScMaintenanceContract))]
        public string Notes { get; set; }

        [Display(Name = nameof(ScMaintenanceContract.PayemtNo), ResourceType = typeof(ScMaintenanceContract))]
        public int PayemtNo { get; set; }

        [Display(Name = nameof(ScMaintenanceContract.Amount), ResourceType = typeof(ScMaintenanceContract))]
        public decimal Amount { get; set; }

        [Display(Name = nameof(ScMaintenanceContract.PaymentCondition), ResourceType = typeof(ScMaintenanceContract))]
        public string PaymentCondition { get; set; }

        [Display(Name = nameof(ResourcePack.AidModule.ScMaintenanceQuotations.PortalRequestNumber), ResourceType = typeof(ScMaintenanceQuotations))]
        public string PortalRequestNumber { get; set; }

        [Display(Name = nameof(ResourcePack.AidModule.ScMaintenanceQuotations.PortalUserName), ResourceType = typeof(ScMaintenanceQuotations))]
        public string PortalUserName { get; set; }

        [Display(Name = nameof(ResourcePack.AidModule.ScMaintenanceQuotations.VendorId), ResourceType = typeof(ScMaintenanceQuotations))]
        public string Vendor { get; set; }

        [Display(Name = nameof(ResourcePack.AidModule.ScMaintenanceQuotations.TotalAmount), ResourceType = typeof(ScMaintenanceQuotations))]
        public decimal TotalAmount { get; set; }

        [Display(Name = nameof(ResourcePack.Accounts.ApMiscPaymentHeaders.MaturityDate), ResourceType = typeof(ResourcePack.Accounts.ApMiscPaymentHeaders))]
        public string MaturityDate { get; set; }

        public string ScMaintenanceContractPaymentsListStr { get; set; }

        public virtual FndLookupValuesVM FndStatusLkp { get; set; }

        public virtual ScMaintenanceQuotationsVM ScMaintenanceQuotations { get; set; }

        public virtual ICollection<ScMaintenanceContractPaymentsDto> MaintenanceContractPayments => string.IsNullOrEmpty(ScMaintenanceContractPaymentsListStr) ?
               new List<ScMaintenanceContractPaymentsDto>() : Helper<List<ScMaintenanceContractPaymentsDto>>.Convert(ScMaintenanceContractPaymentsListStr);
    }
}