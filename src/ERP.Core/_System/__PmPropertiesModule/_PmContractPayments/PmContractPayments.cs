using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System._FndLookupValues;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__PmPropertiesModule._PmContractPayments
{
    public class PmContractPayments : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string CheckNumber { get; protected set; }

        public long PmContractId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Amount { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal PaymentNo { get; protected set; }

        public DateTime PaymentDate { get; protected set; }

        [MaxLength(4000)]
        public string Comments { get; protected set; }

        public long PaymentTypeLkpId { get; protected set; }

        // public long PaymentSourceLkpId { get; protected set; }

        public long? BankLkpId { get; protected set; }

        [ForeignKey(nameof(PaymentTypeLkpId)), Column(Order = 0)]
        public FndLookupValues FndPaymentTypeLkp { get; set; }

        //[ForeignKey(nameof(PaymentSourceLkpId)), Column(Order = 1)]
        //public FndLookupValues FndPaymentSourceLkp { get; set; }

        [ForeignKey(nameof(BankLkpId)), Column(Order = 1)]
        public FndLookupValues FndBankLkp { get; set; }

        [ForeignKey(nameof(PmContractId))]
        public PmContract PmContract { get; protected set; }

        public int TenantId { get; set; }

        protected PmContractPayments() { }

    }
}
