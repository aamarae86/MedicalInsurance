using Abp.Domain.Entities;
using ERP._System.__AccountModule._GeneralUnPost;
using ERP._System._ApBankAccounts;
using ERP._System._ApMiscPaymentDetails;
using ERP._System._ApMiscPaymentLines;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ApMiscPaymentHeaders
{
    public class ApMiscPaymentHeaders : PostAuditedEntity<long>, IMustHaveTenant
    {
        #region Props

        [MaxLength(30)]
        public string PaymentNumber { get; protected set; }

        public DateTime? MiscPaymentDate { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [MaxLength(200)]
        public string BeneficiaryName { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Amount { get; protected set; }

        [Column(TypeName = "bit")]
        public bool? AccPayeeOnly { get; protected set; }

        public long? BankAccountId { get; protected set; }

        public long? PaymentTypeLkpId { get; protected set; }

        public long? PostedlkpId { get; protected set; }

        public long? SourceCodeLkpId { get; protected set; }

        public long? SourceId { get; protected set; }
 
        [ForeignKey(nameof(PostedlkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValuesPostedPaymentLkp { get; protected set; }

        [ForeignKey(nameof(PaymentTypeLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesPaymentTypeLkp { get; protected set; }

        [ForeignKey(nameof(SourceCodeLkpId)), Column(Order = 2)]
        public FndLookupValues FndLookupValuesSourceCodePaymentLkp { get; protected set; }

        [ForeignKey(nameof(BankAccountId))]
        public ApBankAccounts ApBankAccounts { get; set; }

        public virtual ICollection<ApMiscPaymentLines> ApMiscPaymentLines { get; protected set; }

        public virtual ICollection<ApMiscPaymentDetails> ApMiscPaymentDetails { get; protected set; }

        public virtual ICollection<GeneralUnPost> GeneralUnPost { get; protected set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }

        #endregion
    }
}
