using ERP.ResourcePack.Common;
using ERP.ResourcePack.HR;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Controllers.HR;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class HrOrganizationsVM : BaseAuditedEntityVM<long>
    {
        [MaxLength(200)]
        [Display(Name = nameof(HrOrganizations.OrganizationName), ResourceType = typeof(HrOrganizations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Remote(nameof(HrOrganizationsController.CheckIsExistsOrganizationName), "HrOrganizations", AdditionalFields = nameof(Id), HttpMethod = "POST", ErrorMessageResourceName = nameof(Settings.nameExist), ErrorMessageResourceType = typeof(Settings))]
        public string OrganizationName { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(HrOrganizations.ShortName), ResourceType = typeof(HrOrganizations))]
        public string ShortName { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(HrOrganizations.Notes), ResourceType = typeof(HrOrganizations))]
        public string Notes { get; set; }

        [Display(Name = nameof(HrOrganizations.OrganizationTypeLkpId), ResourceType = typeof(HrOrganizations))]
        public long OrganizationTypeLkpId { get; set; }

        [Display(Name = nameof(HrOrganizations.ParentId), ResourceType = typeof(HrOrganizations))]
        public long? ParentId { get; set; }

        [Display(Name = nameof(HrOrganizations.ParentId), ResourceType = typeof(HrOrganizations))]
        public string ParentPath { get; set; }

        public HrOrganizationsVM Parent { get; set; }

        public FndLookupValuesVM FndOrganizationTypeLkp { get; set; }
    }
}