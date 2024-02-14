using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._IvItems;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._IvPriceListHd
{
   public class IvPriceListHd : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(20)]
        public string PriceListNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string PriceListName { get; protected set; }


        public int TenantId { get; set; }
    }
}
