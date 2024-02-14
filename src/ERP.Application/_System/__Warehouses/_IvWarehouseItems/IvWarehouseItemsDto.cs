using Abp.AutoMapper;
using ERP._System.__Warehouses._IvItems;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvWarehouseItems
{
    [AutoMap(typeof(IvWarehouseItems))]
   public class IvWarehouseItemsDto : PostAuditedEntityDto<long>
    {
        public long? IvItemId { get; protected set; }
        public long? IvWarehouseId { get; protected set; }
        public decimal? CurrentOnHand { get; protected set; }
        public int TenantId { get; set; }

        public IvItems IvItems { get; protected set; }


        public IvWarehouses IvWarehouses { get; protected set; }
    }
}
