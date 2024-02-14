using ERP.ResourcePack.Common;
using ERP.ResourcePack.Warehouses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Warehouses
{
    public class IvAdjustmentTrVM
    {
        public long? IvAdjustmentHdId { get; set; }
        [Display(Name = nameof(IvAdjustmentHd.IvItemId), ResourceType = typeof(IvAdjustmentHd))]
        public long? IvItemId { get; set; }
        public string IvItemName { get; set; }
        [Display(Name = nameof(IvAdjustmentHd.IvItemNumber), ResourceType = typeof(IvAdjustmentHd))]
        public string IvItemNumber { get; set; }
        [Display(Name = nameof(IvAdjustmentHd.CurrentQty), ResourceType = typeof(IvAdjustmentHd))]
        public decimal? CurrentQty { get; set; }
        [Display(Name = nameof(IvAdjustmentHd.Qty), ResourceType = typeof(IvAdjustmentHd))]
        public decimal? Qty { get; set; }
        public string rowStatus { get; set; }
    }
}