using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.CharityBoxes
{
    public class TmRegionsVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(ArCustomers.CityLkpId), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long CityLkpId { get; set; }

        [Display(Name = nameof(ArCustomers.RegionNumber), ResourceType = typeof(ArCustomers))]
        [MaxLength(30)]
        public string RegionNumber { get; set; }

        [Display(Name = nameof(ArCustomers.RegionName), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string RegionName { get; set; }

        public FndLookupValuesVM FndLookupValues { get; set; }

        public string Lang { get; set; }
    }
}