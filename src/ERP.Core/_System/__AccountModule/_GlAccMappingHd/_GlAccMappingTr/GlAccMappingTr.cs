using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTrDtl;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTr
{
    public class GlAccMappingTr : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(200)]
        public string TrName { get; protected set; }

        public long GlAccMappingHdId { get; protected set; }

        public long? TrNo { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(GlAccMappingHdId))]
        public GlAccMappingHd GlAccMappingHd { get; protected set; }

        public virtual ICollection<GlAccMappingTrDtl> GlAccMappingTrDtl { get; protected set; }

    }
}
