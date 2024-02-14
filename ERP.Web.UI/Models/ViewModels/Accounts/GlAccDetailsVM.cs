using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Accounts;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class GlAccDetailsVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(GlAccDetails.Code), ResourceType = typeof(GlAccDetails))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        //[Remote(nameof(GlAccDetailsController.CheckCodeExist), "GlAccDetails", AdditionalFields = nameof(Id), HttpMethod = "POST", ErrorMessageResourceName = nameof(Settings.CodeExistBefore), ErrorMessageResourceType = typeof(Settings))]
        public string Code { get; set; }

        [Display(Name = nameof(GlAccDetails.NameAr), ResourceType = typeof(GlAccDetails))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Remote(nameof(GlAccDetailsController.CheckNameExist), "GlAccDetails", AdditionalFields = nameof(Id), HttpMethod = "POST", ErrorMessageResourceName = nameof(Settings.NameExistBefore), ErrorMessageResourceType = typeof(Settings))]
        public string NameAr { get; set; }

        [Display(Name = nameof(GlAccDetails.NameEn), ResourceType = typeof(GlAccDetails))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Remote(nameof(GlAccDetailsController.CheckNameExist), "GlAccDetails", AdditionalFields = nameof(Id), HttpMethod = "POST", ErrorMessageResourceName = nameof(Settings.NameExistBefore), ErrorMessageResourceType = typeof(Settings))]
        public string NameEn { get; set; }

        [Display(Name = nameof(GlAccDetails.GlAccHeader), ResourceType = typeof(GlAccDetails))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long GlAccHeaderId { get; set; }
        public long GlAccHeaderSearchId { get; set; }

        [Display(Name = nameof(GlAccDetails.IsDefault), ResourceType = typeof(GlAccDetails))]
        public bool IsDefault { get; set; }

        public bool IsDefaultAlt { get; set; }


        [Display(Name = nameof(GlAccDetails.Parent), ResourceType = typeof(GlAccDetails))]
        public long? ParentId { get; set; }

        public long? UpdateParentId { get; set; }

        public bool NameExistBefore { get; set; }
        public bool CodeExistBefore { get; set; }
        public bool? CanUpdated { get; set; }
        public GlAccHeadersVM GlAccHeader { get; set; }

        public GlAccDetailsVM GlAccDetail { get; set; }

    }
}