using Abp.Domain.Entities;
using ERP._System._FndLookupValues;
using ERP._System._GlPeriods;
using ERP.Currencies;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders
{
    public class GlJeIntegrationHeaders : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(500)]
        public string JeName { get; protected set; }

        [Required]
        [MaxLength(100)]
        public string GlJeIntegrationNumber { get; protected set; }

        public DateTime GlJeIntegrationDate { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal CurrencyRate { get; protected set; }

        [MaxLength(4000)]
        public string GlJeIntegrationNotes { get; protected set; }

        [MaxLength(20)]
        public string GlJeIntegrationSourceNo { get; protected set; }

        public long PeriodId { get; protected set; }

        [ForeignKey(nameof(PeriodId))]
        public GlPeriodsDetails GlPeriodsDetails { get; protected set; }

        public int CurrencyId { get; protected set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; protected set; }

        public long? StatusLkpId { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        public long? GlJeIntegrationSourceLkpId { get; protected set; }

        [ForeignKey(nameof(GlJeIntegrationSourceLkpId)), Column(Order = 1)]
        public FndLookupValues FndGlJeIntegrationSourceLkp { get; protected set; }

        public long? GlJeIntegrationSourceId { get; protected set; }

        public virtual ICollection<GlJeIntegrationLines> GlJeIntegrationLines { get; protected set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }
    }
}
