using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP._System._GlPeriods;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpPayments
{
    public class SpPaymentPersonDetails : AuditedEntity<long>, IMustHaveTenant
    {
        public long SpPaymentPersonId { get; protected set; }

        public long SpContractDetailsId { get; protected set; }

        public long PeriodId { get; protected set; }

        public long? SpCasesPaymentDeservingId { get; protected set; }

        public DateTime ContractStartDate { get; protected set; }

        public DateTime? ContractEndDate { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal ContractAmount { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal ManagementPercentage { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(SpCasesPaymentDeservingId))]
        public virtual SpCasesPaymentDeserving SpCasesPaymentDeserving { get; protected set; }

        [ForeignKey(nameof(PeriodId))]
        public virtual GlPeriodsDetails Period { get; protected set; }

        [ForeignKey(nameof(SpContractDetailsId))]
        public virtual SpContractDetails SpContractDetails { get; protected set; }

        [ForeignKey(nameof(SpPaymentPersonId))]
        public virtual SpPaymentPersons SpPaymentPersons { get; protected set; }
    }
}
