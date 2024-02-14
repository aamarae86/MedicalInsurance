using Abp.Domain.Entities;
using ERP._System._ApBankAccounts;
using ERP._System._ArCustomers;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ArPdcInterface
{
    public class ArPdcInterface : PostAuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        public long? SourceCodeLkpId { get; protected set; }

        public long? SourceId { get; protected set; }

        [MaxLength(30)]
        public string SourceNumber { get; protected set; }

        public long? StatusLkpId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Amount { get; protected set; }

        [MaxLength(30)]
        public string CheckNumber { get; protected set; }

        public DateTime? MaturityDate { get; protected set; }

        public long? BankAccountId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public DateTime? ConfirmedDate { get; protected set; }

        public DateTime? ReversedDate { get; protected set; }

        public long? CustomerId { get; protected set; }

        public long? BankLkpId { get; protected set; }


        [ForeignKey(nameof(SourceCodeLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValuesSourceCodeLkp { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesStatusLkp { get; protected set; }

        [ForeignKey(nameof(BankLkpId)), Column(Order = 2)]
        public FndLookupValues FndLookupValuesBankLkp { get; protected set; }

        [ForeignKey(nameof(CustomerId))]
        public ArCustomers ArCustomers { get; protected set; }

        public bool IsActive { get; set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }

        public long? DepositBankAccountId { get; protected set; }

        [ForeignKey(nameof(BankAccountId)), Column(Order = 0)]
        public ApBankAccounts ApBankAccounts { get; protected set; }

        [ForeignKey(nameof(DepositBankAccountId)), Column(Order = 1)]
        public ApBankAccounts DepositApBankAccounts { get; protected set; }

        protected ArPdcInterface() { }


        public void SetNeededUpdatedData(string notes, long? depositBankAccountId, DateTime? maturityDate)
        {
            this.MaturityDate = maturityDate;
            this.Notes = notes;
            this.DepositBankAccountId = depositBankAccountId;
        }
    }
}
