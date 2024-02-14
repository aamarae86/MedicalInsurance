using ERP._System.__Warehouses._IvReceiveHd.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.Warehouses;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Warehouses
{
    public class IvReceiveHdVM : BasePostAuditedVM<long>
    {
        #region MainProps

        public string Status { get; set; }

        public string EncId { get; set; }

        [Display(Name = nameof(IvReceiveHd.HdReceiveNumber), ResourceType = typeof(IvReceiveHd))]
        public string HdReceiveNumber { get; set; }

        [Display(Name = nameof(IvReceiveHd.HdReceiveDate), ResourceType = typeof(IvReceiveHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string HdReceiveDate { get; set; }

        [Display(Name = nameof(IvReceiveHd.CurrencyRate), ResourceType = typeof(IvReceiveHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal CurrencyRate { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(IvReceiveHd.Comment), ResourceType = typeof(IvReceiveHd))]
        public string Comment { get; set; }

        [Display(Name = nameof(IvReceiveHd.IvWarehouseId), ResourceType = typeof(IvReceiveHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long IvWarehouseId { get; set; }

        [Display(Name = nameof(IvReceiveHd.StatusLkpId), ResourceType = typeof(IvReceiveHd))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(IvReceiveHd.CurrencyId), ResourceType = typeof(IvReceiveHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public int CurrencyId { get; set; }

        [Display(Name = nameof(IvReceiveHd.VendorId), ResourceType = typeof(IvReceiveHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long VendorId { get; set; }

        //[Display(Name = nameof(IvReceiveHd.ReceiveTypeLkpId), ResourceType = typeof(IvReceiveHd))]
        //[Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        //public long ReceiveTypeLkpId { get; set; }

        [Display(Name = nameof(IvReceiveHd.PoPurchaseOrderHdId), ResourceType = typeof(IvReceiveHd))]
        public long? PoPurchaseOrderHdId { get; set; }
        public long? FndTaxtypeId { get; set; }
        public decimal Percentage { get; set; }
        
        public IvWarehousesVM IvWarehouses { get; set; }

        public ApVendorsVM ApVendors { get; set; }

        public PoPurchaseOrderVM PoPurchaseOrderHd { get; set; }

        public CurrenciesVM Currency { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public FndLookupValuesVM FndReceiveTypeLkp { get; set; }

        public string ListIvReceiveDetailsStr { get; set; }

        public ICollection<IvReceiveTrDto> IvReceiveDetails => string.IsNullOrEmpty(ListIvReceiveDetailsStr) ?
                new List<IvReceiveTrDto>() : Helper<List<IvReceiveTrDto>>.Convert(ListIvReceiveDetailsStr);

        public ICollection<IvReceiveTrDto> IvReceiveTr { get; set; }
        #endregion

        #region DetailsProps

        public long? PoPurchaseOrderTrId { get; set; }

        public long IvReceiveHdId { get; set; }

        [Display(Name = nameof(IvReceiveHd.IvItemId), ResourceType = typeof(IvReceiveHd))]
        public long IvItemId { get; set; }

        [Display(Name = nameof(IvReceiveHd.IvUnitId), ResourceType = typeof(IvReceiveHd))]
        public long IvUnitId { get; set; }

        [Display(Name = nameof(IvReceiveHd.Qty), ResourceType = typeof(IvReceiveHd))]
        public decimal Qty { get; set; }

        [Display(Name = nameof(IvReceiveHd.UnitPrice), ResourceType = typeof(IvReceiveHd))]
        public decimal UnitPrice { get; set; }

        [Display(Name = nameof(IvReceiveHd.TaxAmount), ResourceType = typeof(IvReceiveHd))]
        public decimal? TaxAmount { get; set; }

        [Display(Name = nameof(IvReceiveHd.ItemNumber), ResourceType = typeof(IvReceiveHd))]
        public string ItemNumber { get; set; }

        [Display(Name = nameof(IvReceiveHd.Amount), ResourceType = typeof(IvReceiveHd))]
        public string Amount { get; set; }

        [Display(Name = nameof(IvReceiveHd.TotalAmount), ResourceType = typeof(IvReceiveHd))]
        public string TotalAmount { get; set; }

        public string Item { get; set; }

        public string Unit { get; set; }
        #endregion
    }
}