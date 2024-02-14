using Abp.Domain.Entities;
using ERP._System.__AccountModule._ApInvoiceHd._ApInvoiceTr;
using ERP._System._ApVendors;
using ERP._System._FndLookupValues;
using ERP._System._GlCodeComDetails;
using ERP.Currencies;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModule._ApInvoiceHd
{
    public class ApInvoiceHd : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string HdInvNo { get; protected set; }

        public DateTime HdDate { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal CurrencyRate { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? PrepaidAmount { get; protected set; }

        [MaxLength(4000)]
        public string Comments { get; protected set; }

        public int? PrepaidPeriod { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long HdTypeLkpId { get; protected set; }

        public long VendorId { get; protected set; }

        public int CurrencyId { get; protected set; }

        public long? FromAccountId { get; protected set; }

        public long? ToAccountId { get; protected set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }

        [ForeignKey(nameof(VendorId))]
        public ApVendors ApVendors { get; protected set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(HdTypeLkpId)), Column(Order = 1)]
        public FndLookupValues FndHdTypeLkp { get; protected set; }

        [ForeignKey(nameof(FromAccountId)), Column(Order = 0)]
        public GlCodeComDetails FromGlCodeComDetails { get; protected set; }

        [ForeignKey(nameof(ToAccountId)), Column(Order = 1)]
        public GlCodeComDetails ToGlCodeComDetails { get; protected set; }

        public virtual ICollection<ApInvoiceTr> ApInvoiceTr { get; protected set; }

        public void SetAccounts(long? fromAccountId, long? toAccountId)
        {
            this.FromAccountId = fromAccountId;
            this.ToAccountId = toAccountId;
        }

    }
}
