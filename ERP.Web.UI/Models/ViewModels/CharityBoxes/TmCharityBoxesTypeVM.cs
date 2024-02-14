using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.CharityBoxes
{
    public class TmCharityBoxesTypeVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(ArCustomers.TypeCode), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(20)]
        public string TypeCode { get; set; }

        [Display(Name = nameof(ArCustomers.CharityBoxTypeName), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string CharityBoxTypeName { get; set; }

        [Display(Name = nameof(ArCustomers.Notes), ResourceType = typeof(ArCustomers))]
        [MaxLength(4000)]
        public string Notes { get; set; }

        [Display(Name = nameof(ArCustomers.Active), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public bool IsActive { get; set; }

        public bool IsActiveAlt { get; set; }

        public string Lang { get; set; }

    }
}