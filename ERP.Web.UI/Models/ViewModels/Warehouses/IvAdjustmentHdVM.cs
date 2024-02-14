using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.Warehouses;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Warehouses
{
    public class IvAdjustmentHdVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(IvAdjustmentHd.AdjustmentNumber), ResourceType = typeof(IvAdjustmentHd))]
        [MaxLength(30)]
        public string AdjustmentNumber { get; set; }

        [Display(Name = nameof(IvAdjustmentHd.AdjustmentDate), ResourceType = typeof(IvAdjustmentHd))]
        //[Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string AdjustmentDate { get; set; }

        [Display(Name = nameof(IvAdjustmentHd.StatusLkpId), ResourceType = typeof(IvAdjustmentHd))]
        public long? StatusLkpId { get; set; }

        [Display(Name = nameof(IvAdjustmentHd.AdjustmentTypeLkpId), ResourceType = typeof(IvAdjustmentHd))]
        //[Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? AdjustmentTypeLkpId { get; set; }

        [Display(Name = nameof(IvAdjustmentHd.IvWarehouseId), ResourceType = typeof(IvAdjustmentHd))]
        //[Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? IvWarehouseId { get; set; }

        [Display(Name = nameof(IvAdjustmentHd.Notes), ResourceType = typeof(IvAdjustmentHd))]
        [MaxLength(4000)]
        public string Notes { get; set; }

        public FndLookupValuesVM FndLookupValuesAdjustmentTypeLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesStatusLkpIvAdjustmentHd { get; set; }

        public IvWarehousesVM IvWarehouses { get; set; }

        public string AdjustmentTrStr { get; set; }

        public ICollection<IvAdjustmentTrVM> AdjustmentTr => string.IsNullOrEmpty(AdjustmentTrStr) ?
                new List<IvAdjustmentTrVM>() : Helper<List<IvAdjustmentTrVM>>.Convert(AdjustmentTrStr);
    }
}