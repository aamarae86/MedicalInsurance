using ERP.Core.Helpers.Core;
using ERP.ResourcePack.CharityBoxes;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.CharityBoxes
{
    public class TmCharityBoxesVM : BaseAuditedEntityVM<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [Display(Name = nameof(TmCharityBoxes.CharityBoxNumber), ResourceType = typeof(TmCharityBoxes))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(30)]
        public string CharityBoxNumber { get; set; }

        [Display(Name = nameof(TmCharityBoxes.CharityBoxName), ResourceType = typeof(TmCharityBoxes))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string CharityBoxName { get; set; }

        [Display(Name = nameof(TmCharityBoxes.CharityBoxBarcode), ResourceType = typeof(TmCharityBoxes))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(30)]
        public string CharityBoxBarcode { get; set; }

        [Display(Name = nameof(TmCharityBoxes.TmSupervisorId), ResourceType = typeof(TmCharityBoxes))]
        public long? TmSupervisorId { get; set; }
        public TmSupervisorsVM TmSupervisor { get; set; }

        [Display(Name = nameof(TmCharityBoxes.TmSubLocationId), ResourceType = typeof(TmCharityBoxes))]
        public long? TmSubLocationId { get; set; }
        [Display(Name = nameof(TmCharityBoxes.CityName), ResourceType = typeof(TmCharityBoxes))]
        public string CityName { get; set; }
        [Display(Name = nameof(TmCharityBoxes.RegionName), ResourceType = typeof(TmCharityBoxes))]
        public string RegionName { get; set; }
        [Display(Name = nameof(TmCharityBoxes.LocationName), ResourceType = typeof(TmLocations))]
        public string LocationName { get; set; }
        [Display(Name = nameof(TmCharityBoxes.SubLocationName), ResourceType = typeof(TmCharityBoxes))]
        public string SubLocationName { get; set; }

        [Display(Name = nameof(TmCharityBoxes.StatusLkpId), ResourceType = typeof(TmCharityBoxes))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }

        public FndLookupValuesVM FndLookupValues { get; set; }

        [Display(Name = nameof(TmCharityBoxes.CharityTypeId), ResourceType = typeof(TmCharityBoxes))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long CharityTypeId { get; set; }

        public TmCharityBoxesTypeVM CharityBoxesType { get; set; }
    }
}