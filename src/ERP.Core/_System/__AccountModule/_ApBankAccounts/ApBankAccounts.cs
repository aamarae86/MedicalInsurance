using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._ArReceipts;
using ERP._System.__AccountModuleExtend._ApPaymentsTransactions;
using ERP._System.__AidModule._ScCommitteesCheck;
using ERP._System.__CharityBoxes._TmCharityBoxCollect;
using ERP._System._ApBanks;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._ApPdcInterface;
using ERP._System._ApUserBankAccess;
using ERP._System._ArMiscReceiptDetails;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._ArPdcInterface;
using ERP._System._GlCodeComDetails;
using ERP.Currencies;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ApBankAccounts
{
    public class ApBankAccounts : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        [MaxLength(100)]
        public string BankAccountNameAr { get; protected set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        [MaxLength(100)]
        public string BankAccountNameEn { get; protected set; }

        public int CurrencyId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal CurrencyRate { get; protected set; }

        public long? AccountId { get; protected set; }

        public long? cPdcAccountId { get; protected set; }

        public long? PdcCollAccountId { get; protected set; }

        public long? ApPdcCollAccountId { get; protected set; }

        public long BankId { get; protected set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; protected set; }

        [ForeignKey(nameof(AccountId)), Column(Order = 0)]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        [ForeignKey(nameof(cPdcAccountId)), Column(Order = 1)]
        public GlCodeComDetails GlCodeComDetailscPdcAccount { get; protected set; }

        [ForeignKey(nameof(PdcCollAccountId)), Column(Order = 2)]
        public GlCodeComDetails GlCodeComDetailsPdcCollAccount { get; protected set; }

        [ForeignKey(nameof(ApPdcCollAccountId)), Column(Order = 3)]
        public GlCodeComDetails GlCodeComDetailsApPdcCollAccount { get; protected set; }

        public virtual ICollection<ApUserBankAccess> ApUserBankAccess { get; protected set; }

        [InverseProperty(nameof(ArPdcInterface.ApBankAccounts))]
        public virtual ICollection<ApPdcInterface> ApPdcInterfaceBankAccount { get; protected set; }

        [InverseProperty(nameof(ArPdcInterface.DepositApBankAccounts))]
        public virtual ICollection<ArPdcInterface> ArPdcInterfaceDeposit { get; protected set; }

        [InverseProperty(nameof(ArReceipts.BankAccount))]
        public virtual ICollection<ArReceipts> ArReceiptBankAccounts { get; protected set; }

        [InverseProperty(nameof(ArReceipts.RemitanceBank))]
        public virtual ICollection<ArReceipts> ArReceiptRemitanceBanks { get; protected set; }

        public virtual ICollection<ArMiscReceiptHeaders> ArMiscReceiptHeaders { get; protected set; }
        public virtual ICollection<ArMiscReceiptDetails> ArMiscReceiptDetails { get; protected set; }
        public virtual ICollection<ApMiscPaymentHeaders> ApMiscPaymentHeaders { get; protected set; }
        public virtual ICollection<ScCommitteesCheck> ScCommitteesCheck { get; protected set; }
        public virtual ICollection<TmCharityBoxCollect> TmCharityBoxCollect { get; protected set; }
        public virtual ICollection<ApPaymentsTransactions> ApPaymentsTransactions { get; protected set; }

        [ForeignKey(nameof(BankId))]
        public ApBanks ApBanks { get; protected set; }


        public bool IsActive { get; set; }
        public int TenantId { get; set; }

        public long? TenxMigrationId { get; set; }
        protected ApBankAccounts(
            string bankAccountNameAr,
            string bankAccountNameEn,
            int currencyId,
            decimal currencyRate,
            long? accountId,
            long? cPdcAccountId,
            long? pdcCollAccountId,
            long? apPdcCollAccountId,
            long bankId,
            bool isActive
            )
        {
            this.BankAccountNameAr = bankAccountNameAr;
            this.BankAccountNameEn = bankAccountNameEn;
            this.CurrencyId = currencyId;
            this.CurrencyRate = currencyRate;
            this.AccountId = accountId;
            this.cPdcAccountId = cPdcAccountId;
            this.PdcCollAccountId = pdcCollAccountId;
            this.ApPdcCollAccountId = apPdcCollAccountId;
            this.BankId = bankId;
            this.IsActive = isActive;
        }

        public static ApBankAccounts Create(string bankAccountNameAr,
            string bankAccountNameEn,
            int currencyId,
            decimal currencyRate,
            long? accountId,
            long? cPdcAccountId,
            long? pdcCollAccountId,
            long? apPdcCollAccountId,
            long bankId,
            bool isActive)
        =>
            new ApBankAccounts(bankAccountNameAr, bankAccountNameEn, currencyId,
             currencyRate, accountId, cPdcAccountId, pdcCollAccountId,
              apPdcCollAccountId, bankId, isActive);
    }
}
