using Abp.Domain.Entities;
using ERP._System.__AccountModule._GeneralUnPost;
using ERP._System._FndLookupValues;
using ERP._System._GlJeLines;
using ERP._System._GlPeriods;
using ERP.Currencies;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._GlJeHeaders
{
    public class GlJeHeaders : PostAuditedEntity<long>, IMustHaveTenant
    {
        #region Props

        [Required]
        [MaxLength(500)]
        public string JeName { get; protected set; }

        [Required]
        [MaxLength(100)]
        public string JeNumber { get; protected set; }

        public DateTime JeDate { get; protected set; }

        public DateTime? PostedDate { get; protected set; }

        public DateTime? UnPostedDate { get; protected set; }

        public long? PostedBy { get; protected set; }
        public long? UnPostedBy { get; protected set; }

        public long PeriodId { get; protected set; }

        public int CurrencyId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal CurrencyRate { get; set; }

        public Nullable<long> JeSourceId { get; set; }

        [MaxLength(4000)]
        public string JeNotes { get; protected set; }

        [MaxLength(20)]
        public string JeSourceNo { get; protected set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; protected set; }

        [ForeignKey(nameof(PeriodId))]
        public GlPeriodsDetails GlPeriodsDetails { get; protected set; }


        [ForeignKey(nameof(StatusFndLookupValues)), Column(Order = 0)]
        public Nullable<long> StatusLkpId { get; protected set; }

        [ForeignKey(nameof(JeSourceFndLookupValues)), Column(Order = 1)]
        public Nullable<long> JeSourceLkpId { get; protected set; }

        public virtual ICollection<GlJeLines> GlJeLines { get; set; }
        public virtual ICollection<GeneralUnPost> GeneralUnPost { get; set; }

        public FndLookupValues StatusFndLookupValues { get; protected set; }
        public FndLookupValues JeSourceFndLookupValues { get; protected set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }

        #endregion

        protected GlJeHeaders() { }
    }
}
