using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._IvInventorySetting;
using ERP.Authorization.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._IvUserWarehousesPrivileges
{
    public class IvUserWarehousesPrivileges : AuditedEntity<long>, IMustHaveTenant
    {
        

        public long? UserId { get; protected set; }

        public bool HasIssue { get; protected set; }

        public bool HasReceive { get; protected set; }

        public long IvWarehouseId { get; protected set; }
        public long? IvInventorySettingId { get; protected set; }

        [ForeignKey(nameof(IvWarehouseId))]
        public IvWarehouses IvWarehouses { get; set; }       

        [ForeignKey(nameof(IvInventorySettingId))]
        public IvInventorySetting IvInventorySetting { get;  set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; protected set; }
        public int TenantId { get; set; }
    }
}
