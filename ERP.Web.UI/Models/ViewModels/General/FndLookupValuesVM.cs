using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.General
{
    public class FndLookupValuesVM : BaseAuditedEntityVM<long>
    {
        [MaxLength(200)]
        [Display(Name = nameof(FndLookupValues.NameEn), ResourceType = typeof(FndLookupValues))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string NameEn { get;  set; }

        [MaxLength(200)]
        [Display(Name = nameof(FndLookupValues.NameAr), ResourceType = typeof(FndLookupValues))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string NameAr { get;  set; }

        [MaxLength(100)]
        [Display(Name = nameof(FndLookupValues.LookupCode), ResourceType = typeof(FndLookupValues))]
        public string LookupCode { get;  set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = nameof(FndLookupValues.LookupType), ResourceType = typeof(FndLookupValues))]
        public string LookupType { get;  set; }

        [Required]
        public bool YesNo { get;  set; }

        public string AddedValues { get;  set; }
    }
}