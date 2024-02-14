using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__Warehouses._IvPriceListHd;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._IvInventorySetting
{
    public class IvInventorySettingPriceList : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        public long IvInventorySettingId { get; protected set; }

        [Required]
        public long IvPriceListHdId { get; protected set; }



        [ForeignKey(nameof(IvPriceListHdId))]
        public IvPriceListHd IvPriceListHd { get; set; }


        [ForeignKey(nameof(IvInventorySettingId))]
        public IvInventorySetting IvInventorySetting { get; set; }

        public int TenantId { get; set; }





    }
}
