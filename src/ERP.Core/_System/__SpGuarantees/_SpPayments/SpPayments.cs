using Abp.Domain.Entities;
using ERP._System.__SpGuarantees._SpCases;
using ERP._System._FndLookupValues;
using ERP._System._GlPeriods;
using ERP.Helpers.Core.__PostAudited;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpPayments
{
    public class SpPayments : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string PaymentNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string PaymentName { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long FromPeriodId { get; protected set; }

        public long ToPeriodId { get; protected set; }

        public long? SponsorCategoryLkpId { get; protected set; }

        public long? SpCaseId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public virtual FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(SponsorCategoryLkpId)), Column(Order = 1)]
        public virtual FndLookupValues FndSponsorCategoryLkp { get; protected set; }

        [ForeignKey(nameof(FromPeriodId)), Column(Order = 0)]
        public virtual GlPeriodsDetails FromPeriod { get; protected set; }

        [ForeignKey(nameof(ToPeriodId)), Column(Order = 1)]
        public virtual GlPeriodsDetails ToPeriod { get; protected set; }

        [ForeignKey(nameof(SpCaseId))]
        public virtual SpCases SpCases { get; protected set; }

        public virtual ICollection<SpPaymentPersons> SpPaymentPersons { get; protected set; }
    }
}
