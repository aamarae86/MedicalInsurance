using Abp.Domain.Entities;
using ERP._System._ApBankAccounts;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ApPdcInterface
{
    public class ApPdcInterface : PostAuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        public long? SourceCodeLkpId { get; protected set; }

        public long? SourceId { get; protected set; }

        public long? StatusLkpId { get; protected set; }

        [MaxLength(30)]
        public string SourceNumber { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Amount { get; protected set; }

        [MaxLength(30)]
        public string CheckNumber { get; protected set; }

        public DateTime? MaturityDate { get; protected set; }

        public long? BankAccountId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public DateTime? ConfirmedDate { get; protected set; }

        public DateTime? ReversedDate { get; protected set; }

        public long? VendorId { get; protected set; }

        public long? ChqReturnResonLKPId { get; set; }

        [ForeignKey(nameof(SourceCodeLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValuesSourceCodeLkp { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesStatusLkp { get; protected set; }

        [ForeignKey(nameof(ChqReturnResonLKPId)), Column(Order = 2)]
        public FndLookupValues FndLookupValuesChqReturnResonLKP { get; protected set; }

        [ForeignKey(nameof(BankAccountId))]
        public ApBankAccounts ApBankAccounts { get; set; }

        public bool IsActive { get; set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }

        public void UpdateData(string maturityDate, long? chqReturnResonLKPId, string notes)
        {
            this.MaturityDate = DateTimeController.ConvertToDateTime(maturityDate);
            this.ChqReturnResonLKPId = chqReturnResonLKPId;
            this.Notes = notes;
        }
    }
}
