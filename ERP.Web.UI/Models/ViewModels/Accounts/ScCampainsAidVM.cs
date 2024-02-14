using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ScCampainsAidVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(ArCustomers.CampainsAidCategoryLkpId), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long CampainsAidCategoryLkpId { get; set; }

        [Display(Name = nameof(ArCustomers.AidName), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string AidName { get; set; }

        [Display(Name = nameof(ArCustomers.AidAmount), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal AidAmount { get; set; }

        [Display(Name = nameof(ArCustomers.IsActive), ResourceType = typeof(ArCustomers))]
        public bool IsActive { get; set; }

        public bool IsActiveAlt { get; set; }

        public FndLookupValuesVM FndLookupValues { get; set; }
    }
}