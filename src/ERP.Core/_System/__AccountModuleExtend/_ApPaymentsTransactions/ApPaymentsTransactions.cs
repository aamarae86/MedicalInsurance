using Abp.Domain.Entities;
using ERP._System._ApBankAccounts;
using ERP._System._ApVendors;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModuleExtend._ApPaymentsTransactions
{
    public class ApPaymentsTransactions : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string PaymentNumber { get; protected set; }

        [MaxLength(30)]
        public string CheckNumber { get; protected set; }

        public DateTime PaymentDate { get; protected set; }

        public DateTime? MaturityDate { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal PaymentAmount { get; protected set; }

        public bool AccPayeeOnly { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long PaymentTypeLkpId { get; protected set; }

        public long? BankAccountId { get; protected set; }

        public long VendorId { get; protected set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(PaymentTypeLkpId)), Column(Order = 1)]
        public FndLookupValues FndPaymentTypeLkp { get; protected set; }

        [ForeignKey(nameof(BankAccountId))]
        public ApBankAccounts ApBankAccounts { get; protected set; }

        [ForeignKey(nameof(VendorId))]
        public ApVendors ApVendors { get; protected set; }
    }
}
