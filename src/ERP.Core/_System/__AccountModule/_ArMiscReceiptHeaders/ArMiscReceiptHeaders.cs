using Abp.Domain.Entities;
using ERP._System.__AccountModule._GeneralUnPost;
using ERP._System.__SpGuarantees._SpBeneficent;
using ERP._System._ApBankAccounts;
using ERP._System._ArMiscReceiptDetails;
using ERP._System._ArMiscReceiptLines;
using ERP._System._FndCollectors;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ArMiscReceiptHeaders
{
    public class ArMiscReceiptHeaders : PostAuditedEntity<long>, IMustHaveTenant
    {
        #region Props
        [MaxLength(30)]
        public string ReceiptNumber { get; protected set; }

        public DateTime? MiscReceiptDate { get; protected set; }

        public long? BankAccountId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public long? PostedLkpId { get; protected set; }

        public long? TransactionTypeLkpId { get; protected set; }

        public long? CollectorId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Amount { get; protected set; }

        [MaxLength(100)]
        public string ManualReceiptNumber { get; protected set; }

        public long? BeneficentId { get; protected set; }

        public long? SourceCodeLkpId { get; protected set; }

        public long? SourceId { get; protected set; }

        public long? ReceiptTypeLkpId { get; protected set; }

        [ForeignKey(nameof(CollectorId))]
        public FndCollectors FndCollectors { get; protected set; }

        [ForeignKey(nameof(BeneficentId))]
        public SpBeneficent SpBeneficent { get; protected set; }

        [ForeignKey(nameof(BankAccountId))]
        public ApBankAccounts ApBankAccounts { get; set; }

        [ForeignKey(nameof(PostedLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValuesPostedLkp { get; protected set; }

        [ForeignKey(nameof(TransactionTypeLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesTransactionTypeLkp { get; protected set; }

        [ForeignKey(nameof(SourceCodeLkpId)), Column(Order = 2)]
        public FndLookupValues FndLookupValuesSourceCodeLkp { get; protected set; }

        [ForeignKey(nameof(ReceiptTypeLkpId)), Column(Order = 3)]
        public FndLookupValues FndReceiptTypeLkp { get; protected set; }

        public virtual ICollection<ArMiscReceiptLines> ArMiscReceiptLines { get; protected set; }

        public virtual ICollection<ArMiscReceiptDetails> ArMiscReceiptDetails { get; protected set; }
        public virtual ICollection<GeneralUnPost> GeneralUnPost { get; protected set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }
        #endregion
        protected ArMiscReceiptHeaders() { }

        public void SetDate(string dt) => DateTimeController.ConvertToDateTime(dt);
    }
}
