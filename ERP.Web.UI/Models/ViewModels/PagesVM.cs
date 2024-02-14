using Abp.Domain.Entities;
using ERP.ResourcePack.Common;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels
{
    public class PagesVM : Entity
    {
        [MaxLength(100)]
        [Display(Name = nameof(Pages.NameAr), ResourceType = typeof(Pages))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string NameAr { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Pages.NameEn), ResourceType = typeof(Pages))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string NameEn { get; set; }

        [MaxLength(100)]
        public string Selector { get; set; }

        [MaxLength(100)]
        public string Link { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(Pages.Icon), ResourceType = typeof(Pages))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string Icon { get; set; }

        [Display(Name = nameof(Pages.ModuleName), ResourceType = typeof(Pages))]
        public int ModuleId { get; set; }

        //[MaxLength(200)]
        public string VideoUrlAr { get; set; }

        //[MaxLength(200)]
        public string VideoUrlEn { get; set; }

        [MaxLength(200)]
        public string DocPathAr { get; set; }

        [MaxLength(200)]
        public string DocPathEn { get; set; }

        public string ModuleAr { get; set; }

        public string ModuleEn { get; set; }
    }
}