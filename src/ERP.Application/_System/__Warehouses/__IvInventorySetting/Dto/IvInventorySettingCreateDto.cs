using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__Warehouses._IvInventorySetting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses.__IvInventorySetting.Dto
{
    [AutoMap(typeof(IvInventorySetting))]
    public class IvInventorySettingCreateDto
    {
        [MaxLength(20)]
        public string SettingNumber { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public bool ShowItemCost { get; set; }

        public ICollection<IvInventorySettingPriceListDto> InventorySettingPriceListDetails { get; set; }

        public ICollection<IvUserWarehousesPrivilegesExtDto> UserWarehousesPrivilegesDetails { get; set; }
    }
}
