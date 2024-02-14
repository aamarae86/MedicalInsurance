using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._GlCodeComDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._GlPeriods
{
    public class GlPeriodsYears : AuditedEntity<long>,IMustHaveTenant
    {
        #region Props

        public int PeriodYear { get; protected set; }

        public DateTime StartDate { get; protected set; }

        public DateTime EndDate { get; protected set; }

        public long? AccountId { get; protected set; }

        public long? JeId { get; protected set; }

        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        public virtual ICollection<GlPeriodsDetails> GlPeriodsDetails { get; protected set; }

        public int TenantId { get; set; }

        #endregion

        protected GlPeriodsYears() { }
    }
}
