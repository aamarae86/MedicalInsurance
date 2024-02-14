using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._IvItems;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._IvItemsTypesConfigure
{
    public class IvItemsTypesConfigure : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(200)]
        public string NameEn { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string NameAr { get; protected set; }

        public long? ParentId { get; protected set; }

        [Required]
        [MaxLength(100)]
        public string ConfigureCode { get; protected set; }

        [MaxLength(2000)]
        public string ParentPath { get; protected set; }

        [ForeignKey(nameof(ParentId))]
        public IvItemsTypesConfigure Parent { get; protected set; }

        public virtual ICollection<IvItems> IvItems { get; protected set; }

        public int TenantId { get; set; }
    }
}
