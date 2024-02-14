using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__SpGuarantees._SpCases;
using ERP._System._FndLookupValues;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpPayments
{
    public class SpPaymentPersons : AuditedEntity<long>, IMustHaveTenant
    {
        public long SpPaymentId { get; protected set; }

        public long SpCaseId { get; protected set; }

        public long CaseStatusLkpId { get; protected set; }

        public long SponsorCategoryLkpId { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalAmount { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(SponsorCategoryLkpId)), Column(Order = 0)]
        public virtual FndLookupValues FndSponsorCategoryLkp { get; protected set; }

        [ForeignKey(nameof(CaseStatusLkpId)), Column(Order = 1)]
        public virtual FndLookupValues FndCaseStatusLkp { get; protected set; }

        [ForeignKey(nameof(SpCaseId))]
        public virtual SpCases SpCases { get; protected set; }

        [ForeignKey(nameof(SpPaymentId))]
        public virtual SpPayments SpPayments { get; protected set; }

        public virtual ICollection<SpPaymentPersonDetails> SpPaymentPersonDetails { get; protected set; }
    }
}
