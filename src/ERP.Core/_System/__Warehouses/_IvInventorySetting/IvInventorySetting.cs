using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._IvItems;
using ERP.Authorization.Users;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._IvInventorySetting
{
    public class IvInventorySetting : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(20)]
        public string SettingNumber { get; protected set; }

        [Required]
        public long UserId { get; protected set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Required]
        public bool ShowItemCost { get; set; } = false;
        public int TenantId { get; set; }
    }
}
