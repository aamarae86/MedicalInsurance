using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;
using _CrmContactUs = ERP.ResourcePack.CRM.CrmContactUs.CrmContactUs;

namespace ERP.Web.UI.Models.ViewModels.CRM.CrmContactUs
{
    public class CrmContactUsVM: BaseAuditedEntityVM<long>
    {
        public string EncId { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(_CrmContactUs.HeaderNameAr), ResourceType = typeof(_CrmContactUs))]
        public string HeaderNameAr { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        [Display(Name = nameof(_CrmContactUs.HeaderNameEn), ResourceType = typeof(_CrmContactUs))]
        public string HeaderNameEn { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(4000)]
        [Display(Name = nameof(_CrmContactUs.ContentAr), ResourceType = typeof(_CrmContactUs))]
        public string ContentAr { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(4000)]
        [Display(Name = nameof(_CrmContactUs.ContentEn), ResourceType = typeof(_CrmContactUs))]
        public string ContentEn { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(_CrmContactUs.Phone1), ResourceType = typeof(_CrmContactUs))]
        public string Phone1 { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(_CrmContactUs.Phone2), ResourceType = typeof(_CrmContactUs))]
        public string Phone2 { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(_CrmContactUs.Fax), ResourceType = typeof(_CrmContactUs))]
        public string Fax { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(_CrmContactUs.WorkingHours), ResourceType = typeof(_CrmContactUs))]
        public string WorkingHours { get; set; }

        [MaxLength(30)]
        [EmailAddress]
        [Display(Name = nameof(_CrmContactUs.Email), ResourceType = typeof(_CrmContactUs))]
        public string Email { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(_CrmContactUs.FilePath), ResourceType = typeof(_CrmContactUs))]
        public string FilePath { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(_CrmContactUs.Address), ResourceType = typeof(_CrmContactUs))]
        public string Address { get; set; }
    }
}