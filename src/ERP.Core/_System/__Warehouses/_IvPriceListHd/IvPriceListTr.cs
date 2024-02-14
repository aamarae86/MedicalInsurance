using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._IvItems;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._IvPriceListHd
{
   public class IvPriceListTr : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        public long IvPriceListHdId { get; protected set; }

        [Required]
        public long IvItemId { get; protected set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal Price { get; protected set; }

        [ForeignKey(nameof(IvPriceListHdId))]
        public IvPriceListHd IvPriceListHd { get; protected set; }

        [ForeignKey(nameof(IvItemId))]
        public IvItems IvItems { get;  set; }

       public int TenantId { get; set; }

    }
}
