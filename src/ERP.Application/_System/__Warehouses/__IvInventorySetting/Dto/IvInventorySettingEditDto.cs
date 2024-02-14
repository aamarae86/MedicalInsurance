using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses.__IvInventorySetting.Dto
{
    public class IvInventorySettingEditDto : EntityDto<long>
    {
        public bool ShowItemCost { get; set; }
        public ICollection<IvInventorySettingPriceListDto> InventorySettingPriceListDetails { get; set; }
        public ICollection<IvUserWarehousesPrivilegesExtDto> UserWarehousesPrivilegesDetails { get; set; }
    }
}
