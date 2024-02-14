using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Authentications
{
    public class RolesVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(Name), ResourceType = typeof(ResourcePack.Authentications.Roles))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(64)]
        public string Name { get; set; }

        [Display(Name = nameof(DisplayName), ResourceType = typeof(ResourcePack.Authentications.Roles))]
        [Required]
        [MaxLength(64)]
        public string DisplayName { get; set; }

        [Display(Name = nameof(Description), ResourceType = typeof(ResourcePack.Authentications.Roles))]
        [Required]
        [MaxLength(256)]
        public string Description { get; set; }

        [Display(Name = nameof(NormalizedName), ResourceType = typeof(ResourcePack.Authentications.Roles))]
        [Required]
        [MaxLength(256)]
        public string NormalizedName { get; set; }

        [Display(Name = nameof(GrantedPermissions), ResourceType = typeof(ResourcePack.Authentications.Roles))]
        public string[] GrantedPermissions { get; set; }

        [Display(Name = nameof(IsStatic), ResourceType = typeof(ResourcePack.Authentications.Roles))]
        public bool IsStatic { get; set; }

        [Display(Name = nameof(IsStatic), ResourceType = typeof(ResourcePack.Authentications.Roles))]
        public bool IsStaticAlt { get; set; }

        [Display(Name = nameof(IsDefault), ResourceType = typeof(ResourcePack.Authentications.Roles))]
        public bool IsDefault { get; set; }

        [Display(Name = nameof(IsDefault), ResourceType = typeof(ResourcePack.Authentications.Roles))]
        public bool IsDefaultAlt { get; set; }

        [Display(Name = nameof(ShowOrder), ResourceType = typeof(ResourcePack.Authentications.Roles))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public int ShowOrder { get; set; }
    }
}