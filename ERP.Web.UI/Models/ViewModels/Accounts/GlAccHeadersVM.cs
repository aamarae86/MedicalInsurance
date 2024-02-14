using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class GlAccHeadersVM : BaseAuditedEntityVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(GlAccHeaders.NameEn), ResourceType = typeof(GlAccHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string NameEn { get; set; }

        [Display(Name = nameof(GlAccHeaders.NameAr), ResourceType = typeof(GlAccHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string NameAr { get; set; }

        [Display(Name = nameof(GlAccHeaders.ShowOrder), ResourceType = typeof(GlAccHeaders))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public int ShowOrder { get; set; }

        public bool IsHide { get; set; }

        [Display(Name = nameof(GlAccHeaders.IsHide), ResourceType = typeof(GlAccHeaders))]
        public bool IsHideAlt { get; set; }

        [Display(Name = nameof(GlAccHeaders.Attribute), ResourceType = typeof(GlAccHeaders))]
        public long AttributeLkpId { get; set; }

        [Display(Name = nameof(GlAccHeaders.Parent), ResourceType = typeof(GlAccHeaders))]
        public Nullable<long> ParentId { get; set; }
        public bool? CanUpdated { get; set; }
        public GlAccHeadersVM Parent { get; set; }
        public FndLookupValuesVM FndLookupValues { get; set; }

    }
}