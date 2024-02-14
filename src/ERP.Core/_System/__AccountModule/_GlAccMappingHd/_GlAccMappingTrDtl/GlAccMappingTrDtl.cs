using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTr;
using ERP._System._FndLookupValues;
using ERP._System._GlAccounts;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTrDtl
{
    public class GlAccMappingTrDtl : AuditedEntity<long>, IMustHaveTenant
    {
        public long GlAccMappingTrId { get; protected set; }

        public long? TypeLkpId { get; protected set; }

        public long? FromAccId { get; protected set; }

        public long? ToAccId { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(FromAccId)), Column(Order = 0)]
        public GlAccounts GlAccDetailFrom { get; protected set; }

        [ForeignKey(nameof(ToAccId)), Column(Order = 1)]
        public GlAccounts GlAccDetailTo { get; protected set; }

        [ForeignKey(nameof(TypeLkpId))]
        public FndLookupValues FndTypeLkp { get; protected set; }

        [ForeignKey(nameof(GlAccMappingTrId))]
        public GlAccMappingTr GlAccMappingTr { get; protected set; }
    }
}
