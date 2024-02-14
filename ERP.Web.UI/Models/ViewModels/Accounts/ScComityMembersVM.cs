using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ScComityMembersVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(ArCustomers.MemberNumber), ResourceType = typeof(ArCustomers))]
        [MaxLength(30)]
        public string MemberNumber { get; set; } = "1";

        [Display(Name = nameof(ArCustomers.MemberName), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string MemberName { get; set; }

        [Display(Name = nameof(ArCustomers.MemberCategoryLkpId), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long MemberCategoryLkpId { get; set; }

        [Display(Name = nameof(ArCustomers.IsActive), ResourceType = typeof(ArCustomers))]
        public bool IsActive { get; set; }

        public bool IsActiveAlt { get; set; }

        public FndLookupValuesVM FndLookupValues { get; set; }
    }
}