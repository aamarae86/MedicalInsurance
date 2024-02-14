using ERP._System.__Warehouses.__IvInventorySetting.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.HR;
using ERP.ResourcePack.Warehouses;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Warehouses
{
    public class IvInventorySettingVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [MaxLength(20)]
        [Display(Name = nameof(IvInventorySetting.SettingNumber), ResourceType = typeof(IvInventorySetting))]
        public string SettingNumber { get; set; }

        [Required]
        [Display(Name = nameof(IvInventorySetting.UserName), ResourceType = typeof(IvInventorySetting))]
        public long? UserId { get; set; }

        public string UserName { get; set; }

        [Required]
        public bool ShowItemCost { get; set; }


        #region details
        [Display(Name = nameof(IvInventorySetting.IvPriceListHdId), ResourceType = typeof(IvInventorySetting))]
        public long IvPriceListHdId { get; set; }
        [Display(Name = nameof(IvInventorySetting.PriceListName), ResourceType = typeof(IvInventorySetting))]
        public string PriceListName { get; set; }
        public string IvInventorySettingPriceListDetailsListStr { get; set; }

        #endregion
        public ICollection<IvInventorySettingPriceListDto> InventorySettingPriceListDetails => string.IsNullOrEmpty(IvInventorySettingPriceListDetailsListStr) ?
               new List<IvInventorySettingPriceListDto>() : Helper<List<IvInventorySettingPriceListDto>>.Convert(IvInventorySettingPriceListDetailsListStr);

        #region user warehaouse previlage
        [Display(Name = nameof(IvUserWarehousesPrivileges.HasIssue), ResourceType = typeof(IvUserWarehousesPrivileges))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public bool HasIssue { get; set; }

        [Display(Name = nameof(IvUserWarehousesPrivileges.HasReceive), ResourceType = typeof(IvUserWarehousesPrivileges))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public bool HasReceive { get; set; }
        [Display(Name = nameof(IvUserWarehousesPrivileges.IvWarehouseId), ResourceType = typeof(IvUserWarehousesPrivileges))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long IvWarehouseId { get; set; }
        public IvWarehousesVM IvWarehouses { get; set; }

        //public FndLookupValuesVM FndIvWarehouseLkp { get; set; }

        public string UserWarehousesPrivilegesListStr { get; set; }
        public ICollection<IvUserWarehousesPrivilegesExtDto> UserWarehousesPrivilegesDetails => string.IsNullOrEmpty(UserWarehousesPrivilegesListStr) ?
       new List<IvUserWarehousesPrivilegesExtDto>() : Helper<List<IvUserWarehousesPrivilegesExtDto>>.Convert(UserWarehousesPrivilegesListStr);

        #endregion



    }
}