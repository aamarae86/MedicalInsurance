using Abp.Domain.Entities;
using ERP._System._FndLookupValues;
using ERP._System._GlCodeComDetails;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModuleExtend._ApPrepaid
{
    public class ApPrepaid : PostAuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(20)]
        public string SourceNo { get; protected set; }

        public DateTime TransactionDate { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Amount { get; protected set; }

        public long? DrAccountId { get; protected set; }

        public long? CrAccountId { get; protected set; }

        public long? SourceId { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long SourceCodeLkpId { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(SourceCodeLkpId)), Column(Order = 1)]
        public FndLookupValues FndSourceCodeLkp { get; protected set; }

        [ForeignKey(nameof(DrAccountId)), Column(Order = 0)]
        public GlCodeComDetails DrGlCodeComDetails { get; protected set; }

        [ForeignKey(nameof(CrAccountId)), Column(Order = 1)]
        public GlCodeComDetails CrGlCodeComDetails { get; protected set; }

    }
}
