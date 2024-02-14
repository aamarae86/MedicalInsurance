using ERP.ResourcePack.Common;
using ERP.ResourcePack.Warehouses;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Warehouses
{
    public class IvUnitsVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(IvUnits.UnitCode), ResourceType = typeof(IvUnits))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(20)]
        public string UnitCode { get; set; }

        [Display(Name = nameof(IvUnits.UnitName), ResourceType = typeof(IvUnits))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string UnitName { get; set; }
    }
}