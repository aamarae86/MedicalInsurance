using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class PmOtherPaymentTypesVM : BaseAuditedEntityVM<long>
    {
        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }

        [Display(Name = nameof(ArCustomers.PaymentTypes), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string PaymentTypeName { get; set; }

        public long AccountId { get; set; }

        [Display(Name = nameof(ArCustomers.IsActive), ResourceType = typeof(ArCustomers))]
        public bool IsActive { get; set; }

        public bool IsActiveAlt { get; set; }
    }
}