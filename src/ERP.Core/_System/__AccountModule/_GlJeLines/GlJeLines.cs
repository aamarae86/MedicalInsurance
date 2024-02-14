using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using ERP._System._GlAccounts;
using ERP._System._GlCodeComDetails;
using ERP._System._GlJeHeaders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System._GlJeLines
{
    public class GlJeLines : AuditedEntity<long>, IMustHaveTenant
    {
        #region Props

        [Column(TypeName = "decimal(18, 6)")]
        public decimal DebitAmount { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal CreditAmount { get; protected set; }

        public long AccountId { get; protected set; }

        public long GlJeHeaderId { get; protected set; }

        public long? JeDtlSourceLkpId { get; protected set; }

        public long? JeSourceId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }


        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        [ForeignKey(nameof(GlJeHeaderId))]
        public GlJeHeaders GlJeHeaders { get; protected set; }

        [ForeignKey(nameof(JeDtlSourceLkpId))]
        public FndLookupValues JeSourceFndLookupValues { get; protected set; }
        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }

        #endregion

        protected GlJeLines(
            decimal debitAmount,
            decimal creditAmount,
            long accountId,
            long glJeHeaderId,
            long? jeDtlSourceLkpId = null,
            long? jeSourceId = null,
            string notes = "")
        {
            this.DebitAmount = debitAmount;
            this.CreditAmount = creditAmount;
            this.AccountId = accountId;
            this.GlJeHeaderId = glJeHeaderId;
            this.JeDtlSourceLkpId = jeDtlSourceLkpId;
            this.JeSourceId = jeSourceId;
            this.Notes = notes;
        }

        public static GlJeLines Create(decimal debitAmount,
            decimal creditAmount,
            long accountId,
            long glJeHeaderId,
            long? jeDtlSourceLkpId = null,
            long? jeSourceId = null,
            string notes = "")
        {
            return new GlJeLines(debitAmount, creditAmount, accountId, glJeHeaderId, jeDtlSourceLkpId, jeSourceId, notes);
        }
    }
}
