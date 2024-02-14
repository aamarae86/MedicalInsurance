using ERP.ResourcePack.Common;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.General
{
    public class SpecialPermissionVM
    {

        [Display(Name = nameof(Settings.UserName), ResourceType = typeof(Settings))]
        public long UserId { get; set; }
        [Display(Name = nameof(Settings.SpecialPostAction), ResourceType = typeof(Settings))]
        public bool PostAction { get; set; }
        [Display(Name = nameof(Settings.SpecialPostAction), ResourceType = typeof(Settings))]
        public bool HasPostActionAlt { get; set; }
        [Display(Name = nameof(Settings.SpecialPostponeAction), ResourceType = typeof(Settings))]
        public bool PostponeAction { get; set; }
        [Display(Name = nameof(Settings.SpecialPostponeAction), ResourceType = typeof(Settings))]
        public bool HasPostponeActionAlt { get; set; }
        [Display(Name = nameof(Settings.SpecialRejectAction), ResourceType = typeof(Settings))]
        public bool RejectAction { get; set; }
        [Display(Name = nameof(Settings.SpecialRejectAction), ResourceType = typeof(Settings))]
        public bool HasRejectActionAlt { get; set; }

    }
}