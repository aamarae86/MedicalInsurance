using ERP.ResourcePack.Common;
using ERP.ResourcePack.PmPropertiesModule;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class FmMaintRequisitionsHdrVM : BaseAuditedEntityVM<long>
    {
        public string  EncId { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(FmMaintRequisitionsHdr.RequisitionNumber), ResourceType = typeof(FmMaintRequisitionsHdr))]
        public string RequisitionNumber { get; set; }

        [Display(Name = nameof(FmMaintRequisitionsHdr.RequisitionStatusLkpId), ResourceType = typeof(FmMaintRequisitionsHdr))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long RequisitionStatusLkpId { get; set; }

        [Display(Name = nameof(FmMaintRequisitionsHdr.PmPropertiesId), ResourceType = typeof(FmMaintRequisitionsHdr))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PmPropertiesId { get; set; }

        [Display(Name = nameof(FmMaintRequisitionsHdr.ComplaintTypeLkpId), ResourceType = typeof(FmMaintRequisitionsHdr))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long ComplaintTypeLkpId { get; set; }

        [Display(Name = nameof(FmMaintRequisitionsHdr.UnitTypeLkpId), ResourceType = typeof(FmMaintRequisitionsHdr))]
        public long? UnitTypeLkpId { get; set; }

        [Display(Name = nameof(FmMaintRequisitionsHdr.UnitId), ResourceType = typeof(FmMaintRequisitionsHdr))]
        public long? UnitId { get; set; }

        [Display(Name = nameof(FmMaintRequisitionsHdr.RequisitionDate), ResourceType = typeof(FmMaintRequisitionsHdr))]
        public string RequisitionDate { get; set; }

        [Display(Name = nameof(FmMaintRequisitionsHdr.RequisitionTime), ResourceType = typeof(FmMaintRequisitionsHdr))]
        public string RequisitionTime { get; set; }

        [MaxLength(150)]
        [Display(Name = nameof(FmMaintRequisitionsHdr.CallerName), ResourceType = typeof(FmMaintRequisitionsHdr))]
        public string CallerName { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(FmMaintRequisitionsHdr.PhoneNumber), ResourceType = typeof(FmMaintRequisitionsHdr))]
        public string PhoneNumber { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(FmMaintRequisitionsHdr.Mobile), ResourceType = typeof(FmMaintRequisitionsHdr))]
        public string Mobile { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(FmMaintRequisitionsHdr.ComplaintDetails), ResourceType = typeof(FmMaintRequisitionsHdr))]
        public string ComplaintDetails { get; set; }

        public FndLookupValuesVM FndComplaintTypeLkp { get; set; }

        public FndLookupValuesVM FndUnitTypeLkp { get; set; }

        public FndLookupValuesVM FndRequisitionStatusLkp { get; set; }

        public PmPropertiesVM PmProperties { get; set; }

        public PmPropertiesUnitsVM PmPropertiesUnits { get; set; }
    }
}