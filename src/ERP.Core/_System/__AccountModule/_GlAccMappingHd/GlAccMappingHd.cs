using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTr;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._GlAccMappingHd
{
    public class GlAccMappingHd : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(200)]
        public string MapName { get; protected set; }

        [MaxLength(30)]
        public string MapNumber { get; protected set; }

        public int TenantId { get; set; }

        public virtual ICollection<GlAccMappingTr> GlAccMappingTr { get; protected set; }
    }
}
