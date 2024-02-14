using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._IvAdjustmentHd;
using ERP._System.__Warehouses._IvReceiveHd;
using ERP._System.__Warehouses._IvUserWarehousesPrivileges;
using ERP._System.__Warehouses._IvWarehouseItems;
using ERP._System._FndLookupValues;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses
{
    public class IvWarehouses : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(20)]
        public string WarehouseNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string WarehouseName { get; protected set; }

        public long CityLkpId { get; protected set; }

        public bool IsDefault { get; protected set; }

        [MaxLength(200)]
        public string WarehouseAddress { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(CityLkpId))]
        public FndLookupValues FndCityLkp { get; protected set; }

        public virtual ICollection<IvUserWarehousesPrivileges> IvUserWarehousesPrivileges { get; protected set; }
        public virtual ICollection<IvAdjustmentHd> IvAdjustmentHd { get; protected set; }
        public virtual ICollection<IvWarehouseItems> IvWarehouseItems { get; protected set; }

        public virtual ICollection<IvReceiveHd> IvReceiveHd { get; protected set; }

        public void SetIsDefault(bool input) => this.IsDefault = input;
    }
}
