using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__SpGuarantees._SpBeneficent;
using ERP._System.__SpGuarantees._SpCases;
using ERP._System.__SpGuarantees._SpCases._SpCaseOperations;
using ERP._System.__SpGuarantees._SpPayments;
using ERP._System._ArMiscReceiptLines;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpContracts._SpContractDetails
{
    public class SpContractDetails : AuditedEntity<long>, IMustHaveTenant
    {
        public long SpContractId { get; protected set; }

        public long SpCaseId { get; protected set; }

        public long CaseStatusLkpId { get; protected set; }

        public DateTime StartDate { get; protected set; }

        public DateTime? EndDate { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? Amount { get; protected set; }

        [MaxLength(200)]
        public string SponsFor { get; protected set; }

        public long? SpBeneficentBankId { get; protected set; }

        public long? BankLkpId { get; protected set; }

        [MaxLength(50)]
        public string AccountNumber { get; protected set; }

        [MaxLength(200)]
        public string AccountOwnerName { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(CaseStatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndCaseStatusLkp { get; protected set; }

        [ForeignKey(nameof(BankLkpId)), Column(Order = 1)]
        public FndLookupValues FndBankLkp { get; protected set; }

        [ForeignKey(nameof(SpContractId))]
        public SpContracts SpContracts { get; protected set; }

        [ForeignKey(nameof(SpCaseId))]
        public SpCases SpCases { get; protected set; }

        [ForeignKey(nameof(SpBeneficentBankId))]
        public SpBeneficentBanks SpBeneficentBanks { get; protected set; }

        [InverseProperty(nameof(SpCaseOperations.SpContractDetails))]
        public virtual ICollection<SpCaseOperations> SpCaseOperationsCollection { get; protected set; }

        [InverseProperty(nameof(SpCaseOperations.NewwSpContractDetails))]
        public virtual ICollection<SpCaseOperations> SpCaseOperationsNewCollection { get; protected set; }

        public virtual ICollection<ArMiscReceiptLines> ArMiscReceiptLines { get; protected set; }

        public virtual ICollection<SpCasesPaymentDeserving> SpCasesPaymentDeserving { get; protected set; }

        public virtual ICollection<SpPaymentPersonDetails> SpPaymentPersonDetails { get; protected set; }
    }
}
