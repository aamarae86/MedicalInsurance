using ERP.ResourcePack.CharityBoxes;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.CharityBoxes
{
    public class TmCharityBoxCollectMembersVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(TmCharityBoxCollectMembers.MemberNumber), ResourceType = typeof(TmCharityBoxCollectMembers))]
        public string MemberNumber { get; set; }

        [Display(Name = nameof(TmCharityBoxCollectMembers.MemberName), ResourceType = typeof(TmCharityBoxCollectMembers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string MemberName { get; set; }

        [Display(Name = nameof(TmCharityBoxCollectMembers.MemberCategoryLkpId), ResourceType = typeof(TmCharityBoxCollectMembers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long MemberCategoryLkpId { get; set; }

        [Display(Name = nameof(TmCharityBoxCollectMembers.IsActive), ResourceType = typeof(TmCharityBoxCollectMembers))]
        public bool IsActive { get; set; }

        [Display(Name = nameof(TmCharityBoxCollectMembers.IsActive), ResourceType = typeof(TmCharityBoxCollectMembers))]
        public bool IsActiveAlt { get; set; }

        public FndLookupValuesVM FndMemberCategoryValues { get; set; }
    }
}