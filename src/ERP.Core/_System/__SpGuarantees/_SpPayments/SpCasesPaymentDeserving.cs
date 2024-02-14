using Abp.Domain.Entities;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP._System._FndLookupValues;
using ERP._System._GlPeriods;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpPayments
{
    public class SpCasesPaymentDeserving : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string DeservingNumber { get; protected set; }

        public DateTime DeservingDate { get; protected set; }

        public long SpContractDetailsId { get; protected set; }

        public long DeservingPeriodId { get; protected set; }

        public long CaseStatusLkpId { get; protected set; }

        public long StatusLkpId { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal DeservingAmount { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public virtual FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(CaseStatusLkpId)), Column(Order = 1)]
        public virtual FndLookupValues FndCaseStatusLkp { get; protected set; }

        [ForeignKey(nameof(SpContractDetailsId))]
        public virtual SpContractDetails SpContractDetails { get; protected set; }

        [ForeignKey(nameof(DeservingPeriodId))]
        public virtual GlPeriodsDetails DeservingPeriod { get; protected set; }

        public virtual ICollection<SpPaymentPersonDetails> SpPaymentPersonDetails { get; protected set; }

    }
}
