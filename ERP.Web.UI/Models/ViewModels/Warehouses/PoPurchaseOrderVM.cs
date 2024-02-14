using ERP._System.__Warehouses._PoPurchaseOrder.Dto;
using ERP.Core.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.Warehouses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Warehouses
{
    public class PoPurchaseOrderVM : Controllers.Base.BasePostAuditedVM<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        #region Search Params
        [Display(Name = nameof(PoPurchaseOrder.PurchaseOrderDate), ResourceType = typeof(PoPurchaseOrder))]
        public DateTime? Search_PurchaseOrderDate { get; set; }
        [Display(Name = nameof(PoPurchaseOrder.PurchaseOrderNumber), ResourceType = typeof(PoPurchaseOrder))]
        public string Search_OrderNumber { get; set; }
        [Display(Name = nameof(PoPurchaseOrder.VendorId), ResourceType = typeof(PoPurchaseOrder))]
        public long? Search_VendorId { get; set; }
        [Display(Name = nameof(PoPurchaseOrder.IvWarehouseId), ResourceType = typeof(PoPurchaseOrder))]
        public long? Search_IvWarehouseId { get; set; }
        [Display(Name = nameof(PoPurchaseOrder.StatusLkpId), ResourceType = typeof(PoPurchaseOrder))]
        public long? Search_StatusId { get; set; }

        #endregion

        #region Master Properties
        [Display(Name = nameof(PoPurchaseOrder.PurchaseOrderDate), ResourceType = typeof(PoPurchaseOrder))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string PurchaseOrderDate { get; set; }

        [Display(Name = nameof(PoPurchaseOrder.StatusLkpId), ResourceType = typeof(PoPurchaseOrder))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }
        [Display(Name = nameof(PoPurchaseOrder.VendorId), ResourceType = typeof(PoPurchaseOrder))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long VendorId { get; set; }
        [Display(Name = nameof(PoPurchaseOrder.IvWarehouseId), ResourceType = typeof(PoPurchaseOrder))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long IvWarehouseId { get; set; }
        [Display(Name = nameof(PoPurchaseOrder.ConditionsForOrdering), ResourceType = typeof(PoPurchaseOrder))]
        public string ConditionsForOrdering { get; set; }

        #endregion

        #region Master Mapped Properties
        [Display(Name = nameof(PoPurchaseOrder.PurchaseOrderNumber), ResourceType = typeof(PoPurchaseOrder))]
        public string PurchaseOrderNumber { get; set; }
        public string VendorNameEn { get; set; }
        public string VendorNameAr { get; set; }
        public string IvWarehouseName { get; set; }
        public string StatusEn { get; set; }
        public string StatusAr { get; set; }

        public string Status => PoPurchaseOrder.NewStatus;
        #endregion

        #region Detail Properties
        [Display(Name = nameof(PoPurchaseOrder.IvItemNumber), ResourceType = typeof(PoPurchaseOrder))]
        public string IvItemNumber { get; set; }
        [Display(Name = nameof(PoPurchaseOrder.IvItemId), ResourceType = typeof(PoPurchaseOrder))]
        public long? IvItemId { get; set; }
        [Display(Name = nameof(PoPurchaseOrder.QtyOrdered), ResourceType = typeof(PoPurchaseOrder))]
        public decimal QtyOrdered { get; set; }
        [Display(Name = nameof(PoPurchaseOrder.UnitPrice), ResourceType = typeof(PoPurchaseOrder))]
        public decimal UnitPrice { get; set; }
        [Display(Name = nameof(PoPurchaseOrder.ReceivedQty), ResourceType = typeof(PoPurchaseOrder))]
        public decimal? ReceivedQty { get; set; }
        [Display(Name = nameof(PoPurchaseOrder.ReceivedDate), ResourceType = typeof(PoPurchaseOrder))]
        public string ReceivedDate { get; set; }

        [Display(Name = nameof(PoPurchaseOrder.Total), ResourceType = typeof(PoPurchaseOrder))]
        public decimal? Total { get; set; }

        #endregion

        #region Detail Listings
        public string ListPoPurchaseOrderDetails { get; set; }

        public virtual ICollection<PoPurchaseOrderDetailsCreateDto> ListOfDetails { get; set; }

        public virtual ICollection<PoPurchaseOrderDetailsEditDto> ListOfEditDetails { get; set; }

        public virtual ICollection<PoPurchaseOrderDetailsCreateDto> ListOfCreateDetails { get; set; }
        #endregion
    }
}