using ERP.ResourcePack.CharityBoxes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.CharityBoxes
{
    public class TmCharityBoxListVM
    {
        [Display(Name = nameof(ReportsTms.CharityBox), ResourceType = typeof(ReportsTms))]
        public long? CharityId { get; set; }
        [Display(Name = nameof(ReportsTms.Barcode), ResourceType = typeof(ReportsTms))]
        public string CharityBoxBarcode { get; set; }
        [Display(Name = nameof(ReportsTms.Status), ResourceType = typeof(ReportsTms))]
        public long? CharityStatus { get; set; }
        [Display(Name = nameof(ReportsTms.BoxType), ResourceType = typeof(ReportsTms))]
        public long? BoxTypeName { get; set; }
        [Display(Name = nameof(ReportsTms.City), ResourceType = typeof(ReportsTms))]
        public long? CityId { get; set; }
        [Display(Name = nameof(ReportsTms.Region), ResourceType = typeof(ReportsTms))]
        public long? RegionId { get; set; }
        [Display(Name = nameof(ReportsTms.Location), ResourceType = typeof(ReportsTms))]
        public long? LocationId { get; set; }
        [Display(Name = nameof(ReportsTms.LocationSub), ResourceType = typeof(ReportsTms))]
        public long? LocationSubId { get; set; }
    }
}