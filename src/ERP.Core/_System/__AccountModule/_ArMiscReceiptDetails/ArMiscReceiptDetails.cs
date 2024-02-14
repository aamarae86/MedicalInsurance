using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._ApBankAccounts;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System._ArMiscReceiptDetails
{
    public class ArMiscReceiptDetails : AuditedEntity<long>, IMustHaveTenant
    {
        #region Props
        public long? MiscReceiptId { get; protected set; }

        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        public string CheckNumber { get; protected set; }

        public DateTime? MaturityDate { get; protected set; }

        public long? BankLkpId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Amount { get; protected set; }

        public long? BankAccountId { get; protected set; }

        [ForeignKey(nameof(BankLkpId))]
        public FndLookupValues FndLookupValues { get; protected set; }

        [ForeignKey(nameof(BankAccountId))]
        public ApBankAccounts ApBankAccounts { get; set; }

        [ForeignKey(nameof(MiscReceiptId))]
        public ArMiscReceiptHeaders ArMiscReceiptHeaders { get; protected set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }
        #endregion

        protected ArMiscReceiptDetails() {}

        protected ArMiscReceiptDetails(
            long? miscReceiptId,
            string checkNumber,
            DateTime? maturityDate,
            long? bankLkpId,
            decimal? amount,
            long? bankAccountId)
        {
            this.MiscReceiptId = miscReceiptId;
            this.CheckNumber = checkNumber;
            this.MaturityDate = maturityDate;
            this.BankAccountId = bankAccountId;
            this.Amount = amount;
            this.BankAccountId = bankAccountId;
            this.BankLkpId = bankLkpId;
        }


        public static ArMiscReceiptDetails Create(long? miscReceiptId,
            string checkNumber,
            DateTime? maturityDate,
            long? bankLkpId,
            decimal? amount,
            long? bankAccountId)
                => new ArMiscReceiptDetails(
                    miscReceiptId,
                     checkNumber,
                     maturityDate,
                     bankLkpId,
                    amount,
                    bankAccountId);
    }
}
