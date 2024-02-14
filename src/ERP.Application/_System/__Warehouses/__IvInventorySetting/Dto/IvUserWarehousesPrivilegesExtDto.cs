using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__Warehouses.Dto;
using ERP.Helpers.Core;
using ERP.Users.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses.__IvInventorySetting.Dto
{
   public class IvUserWarehousesPrivilegesExtDto : EntityDto<long>, IDetailRowStatus
    {
        public long? UserId { get; set; }

        public bool? HasIssue { get; set; }

        public bool? HasReceive { get; set; }

        public long IvWarehouseId { get; set; }
        public long IvInventorySettingId { get; set; }

        public string warehouseName { get; set; }
        //[ForeignKey(nameof(IvWarehouseId))]
        //public IvWarehouses IvWarehouses { get;  set; }

        //[ForeignKey(nameof(IvInventorySettingId))]
        //public IvInventorySetting IvInventorySetting { get; protected set; }

        //[ForeignKey(nameof(UserId))]
        //public User User { get; protected set; }

        public string rowStatus { get; set; }
    }
}
