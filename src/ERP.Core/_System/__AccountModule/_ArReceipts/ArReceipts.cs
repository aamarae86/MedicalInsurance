using Abp.Domain.Entities;
using ERP._System._ApBankAccounts;
using ERP._System._ArCustomers;
using ERP._System._FndLookupValues;
using ERP.Currencies;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModule._ArReceipts
{
    public class ArReceipts : PostAuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string ReceiptNumber { get; protected set; }
        [Required]
        public DateTime ReceiptDate { get; protected set; }
        [Required]
        public long StatusLkpId { get; protected set; }
        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndStatusLkp { get; protected set; }

        public long? ArCustomerId { get; protected set; }
        [ForeignKey(nameof(ArCustomerId))]
        public ArCustomers ArCustomer { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }
        [Required]
        public long BankAccountId { get; protected set; }
        [ForeignKey(nameof(BankAccountId)), Column(Order = 0)]
        public ApBankAccounts BankAccount { get; protected set; }

        [Required]
        public int CurrencyId { get; protected set; }
        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        [Required]
        public decimal CurrencyRate { get; protected set; }
        public long? RemitanceBankId { get; protected set; }
        [ForeignKey(nameof(RemitanceBankId)), Column(Order = 1)]
        public ApBankAccounts RemitanceBank { get; protected set; }

        [MaxLength(30)]
        public string ManualReceiptNo { get; protected set; }
        public long? SourceCodeLkpId { get; protected set; }
        public long? SourceId { get; protected set; }
        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }
        public virtual ICollection<ArReceiptDetails> ArReceiptDetails { get; protected set; }
        public virtual ICollection<ArReceiptsOnAccount> ArReceiptsOnAccount { get; protected set; }
    }
}
