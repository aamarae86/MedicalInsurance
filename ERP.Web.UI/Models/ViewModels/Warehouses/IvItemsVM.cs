using ERP.ResourcePack.Common;
using ERP.ResourcePack.Warehouses;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Warehouses
{
    public class IvItemsVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(IvItems.IvItemsTypesConfigureId), ResourceType = typeof(IvItems))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? IvItemsTypesConfigureId { get; set; }

        [Display(Name = nameof(IvItems.ItemNumber), ResourceType = typeof(IvItems))]
        [MaxLength(20)]
        public string ItemNumber { get; set; }

        [Display(Name = nameof(IvItems.ItemName), ResourceType = typeof(IvItems))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string ItemName { get; set; }

        [Display(Name = nameof(IvItems.ItemBarcode), ResourceType = typeof(IvItems))]
        [MaxLength(50)]
        public string ItemBarcode { get; set; }

        [Display(Name = nameof(IvItems.ItemRef1), ResourceType = typeof(IvItems))]
        [MaxLength(30)]
        public string ItemRef1 { get; set; }

        [Display(Name = nameof(IvItems.ItemRef2), ResourceType = typeof(IvItems))]
        [MaxLength(30)]
        public string ItemRef2 { get; set; }

        [Display(Name = nameof(IvItems.IvUnitId), ResourceType = typeof(IvItems))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? IvUnitId { get; set; }

        [Display(Name = nameof(IvItems.ItemOrdQty), ResourceType = typeof(IvItems))]
        public decimal? ItemOrdQty { get; set; }

        [Display(Name = nameof(IvItems.ItemMaxStk), ResourceType = typeof(IvItems))]
        public decimal? ItemMaxStk { get; set; }

        [Display(Name = nameof(IvItems.ItemMinStk), ResourceType = typeof(IvItems))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal? ItemMinStk { get; set; }

        [Display(Name = nameof(IvItems.ItemQtys), ResourceType = typeof(IvItems))]
        public decimal? ItemQtys { get; set; }

        [Display(Name = nameof(IvItems.AvgCost), ResourceType = typeof(IvItems))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal? AvgCost { get; set; }

        [Display(Name = nameof(IvItems.LastCost), ResourceType = typeof(IvItems))]
        public decimal? LastCost { get; set; }

        [Display(Name = nameof(IvItems.IsItemObsolete), ResourceType = typeof(IvItems))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public bool? IsItemObsolete { get; set; }

        public bool? IsItemObsoleteAlt { get; set; }

        [Display(Name = nameof(IvItems.ObsoleteDate), ResourceType = typeof(IvItems))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public DateTime? ObsoleteDate { get; set; }

        [Display(Name = nameof(IvItems.IsDonationItem), ResourceType = typeof(IvItems))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public bool? IsDonationItem { get; set; }

        public bool? IsDonationItemAlt { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Warehouses.IvItems.FndTaxtypeId), ResourceType = typeof(IvItems))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? FndTaxtypeId { get; set; }

        [Display(Name = nameof(IvItems.Total), ResourceType = typeof(IvItems))]
        public decimal? Total { get; set; }
        //[Display(Name = nameof(IvItems.TaxPercentageLkpId), ResourceType = typeof(IvItems))]
        //[Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        //public long? TaxPercentageLkpId { get; set; }
        public FndLookupValuesVM FndLookupValues { get; set; }
        public FndTaxTypeVM FndTaxType { get; set; }
        public IvItemsTypesConfigureVM IvItemsTypesConfigure { get; set; }
        public IvUnitsVM IvUnits { get; set; }
    }
}