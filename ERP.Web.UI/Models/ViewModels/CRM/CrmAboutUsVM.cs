
using ERP._System.__CRM.AboutUs.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.CRM.aboutUs;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.CRM
{
    public class CrmAboutUsVM : BaseAuditedEntityVM<long>
    {
        public string EncId { get; set; }

        [StringLength(200)]
        [Required]
        [Display(Name = nameof(aboutUs.HeaderNameAr), ResourceType = typeof(aboutUs))]
        public string HeaderNameAr { get; set; }

        [StringLength(200)]
        [Required]
        [Display(Name = nameof(aboutUs.HeaderNameEn), ResourceType = typeof(aboutUs))]
        public string HeaderNameEN { get; set; }

        [StringLength(4000)]
        [Display(Name = nameof(aboutUs.ContentAr), ResourceType = typeof(aboutUs))]
        public string ContentAr { get; set; }

        [StringLength(4000)]
        [Display(Name = nameof(aboutUs.HeaderNameEn), ResourceType = typeof(aboutUs))]
        public string ContentEn { get; set; }

        [StringLength(4000)]
        [Display(Name = nameof(aboutUs.AboutUsFilepath), ResourceType = typeof(aboutUs))]
        public string AboutUsFilepath { get; set; }
 

        public string AttachmentsListStr { get; set; }

        public ICollection<AboutUSSliderDto> AboutUSSliderDtoList => string.IsNullOrEmpty(AttachmentsListStr) ?
                 new List<AboutUSSliderDto>() : Helper<List<AboutUSSliderDto>>.Convert(AttachmentsListStr);
    }
}