using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._FndLookupValues;
using ERP._System._GlCodeComDetails;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ArMiscReceiptLines
{
    public class ArMiscReceiptLines : AuditedEntity<long>, IMustHaveTenant
    {
        #region Props
        public long? MiscReceiptId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? MiscReceiptAmount { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? AdministrativePercent { get; protected set; }

        [Column(TypeName = "nvarchar(4000)")]
        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public long? ReceiptTypeLkpId { get; protected set; }

        public long? CaseId { get; protected set; }

        public long? AccountId { get; protected set; }

        public long? AdminAccountID { get; protected set; }

        [Column(TypeName = "nvarchar(100)")]
        [MaxLength(100)]
        public string ManualReceiptNumber { get; protected set; }

        public long? SourceCodeLkpId { get; protected set; }

        public long? SourceId { get; protected set; }

        public long? SpContractDetailsId { get; protected set; }

        [ForeignKey(nameof(SpContractDetailsId))]
        public SpContractDetails SpContractDetails { get; protected set; }

        [ForeignKey(nameof(MiscReceiptId))]
        public ArMiscReceiptHeaders ArMiscReceiptHeaders { get; protected set; }

        [ForeignKey(nameof(AccountId)), Column(Order = 0)]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        [ForeignKey(nameof(AdminAccountID)), Column(Order = 0)]
        public GlCodeComDetails AdminGlCodeComDetails { get; protected set; }

        [ForeignKey(nameof(ReceiptTypeLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValuesReceiptTypeLkp { get; protected set; }

        [ForeignKey(nameof(SourceCodeLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesSourceCodeLkp { get; protected set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }
        #endregion

        protected ArMiscReceiptLines() { }

        protected ArMiscReceiptLines(
            long? miscReceiptId,
            decimal? miscReceiptAmount,
            decimal? administrativePercent,
            long? receiptTypeLkpId,
            long? caseId,
            long? accountId,
            string manualReceiptNumber,
            long? sourceCodeLkpId,
            long? sourceId,
            long? adminAccountId,
            string notes,
            long? spContractDetailsId)
        {
            this.Notes = notes;
            this.MiscReceiptAmount = miscReceiptAmount;
            this.MiscReceiptId = miscReceiptId;
            this.AdministrativePercent = administrativePercent;
            this.ReceiptTypeLkpId = receiptTypeLkpId;
            this.AccountId = accountId;
            this.ManualReceiptNumber = manualReceiptNumber;
            this.CaseId = caseId;
            this.SourceCodeLkpId = sourceCodeLkpId;
            this.SourceId = sourceId;
            this.AdminAccountID = adminAccountId;
            this.Notes = notes;
            this.SpContractDetailsId = spContractDetailsId;
        }

        public static ArMiscReceiptLines Create(
            long? miscReceiptId,
            decimal? miscReceiptAmount,
            decimal? administrativePercent,
            long? receiptTypeLkpId,
            long? caseId,
            long? accountId,
            string manualReceiptNumber,
            long? sourceCodeLkpId,
            long? sourceId,
            long? adminAccountId,
            string notes,
            long? spContractDetailsId)
        => new ArMiscReceiptLines(
             miscReceiptId,
             miscReceiptAmount,
             administrativePercent,
             receiptTypeLkpId,
             caseId,
             accountId,
             manualReceiptNumber,
             sourceCodeLkpId,
             sourceId,
             adminAccountId,
             notes, spContractDetailsId);
    }
}
