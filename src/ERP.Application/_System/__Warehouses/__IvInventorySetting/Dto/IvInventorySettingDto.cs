using Abp.AutoMapper;
using ERP._System.__Warehouses._IvInventorySetting;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses.__IvInventorySetting.Dto
{
    [AutoMap(typeof(IvInventorySetting))]
    public class IvInventorySettingDto : PostAuditedEntityDto<long>
    {
         public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        [Required]
        [MaxLength(20)]
        public string SettingNumber { get; set; }

        [Required]
        public long UserId { get; set; }
        public string UserName { get; set; }
        
        public User User { get; set; }

        [Required]
        public bool ShowItemCost { get; set; } = false;
        public ICollection<IvInventorySettingPriceListDto> InventorySettingPriceListDetails { get; set; }
        public ICollection<IvUserWarehousesPrivilegesExtDto> UserWarehousesPrivilegesDetails { get; set; }

    }
}
