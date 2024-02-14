using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScFndPortalIntervalSettingVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(NumberOfRequest), ResourceType = typeof(ScFndPortalIntervalSetting))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public int NumberOfRequest { get; set; }

        [Display(Name = nameof(Settings.FromDate), ResourceType = typeof(Settings))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string FromDate { get; set; }

        [Display(Name = nameof(Settings.ToDate), ResourceType = typeof(Settings))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ToDate { get; set; }

        [Display(Name = nameof(ScFndPortalIntervalSetting.FromTimeStr), ResourceType = typeof(ScFndPortalIntervalSetting))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ToTime { get; set; }

        [Display(Name = nameof(ScFndPortalIntervalSetting.ToTimeStr), ResourceType = typeof(ScFndPortalIntervalSetting))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string FromTime { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }

    }
}