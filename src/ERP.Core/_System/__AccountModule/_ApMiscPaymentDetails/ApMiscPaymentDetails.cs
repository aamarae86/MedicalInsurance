using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._ApMiscPaymentHeaders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System._ApMiscPaymentDetails
{
    public class ApMiscPaymentDetails : AuditedEntity<long>, IMustHaveTenant
    {
        #region Props
        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        public string CheckNumber { get; protected set; }

        [MaxLength(200)]
        public string BeneficiaryName { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Amount { get; protected set; }

        [Column(TypeName = "nvarchar(4000)")]
        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public DateTime? MaturityDate { get; protected set; }

        public long? MiscPaymentId { get; protected set; }

        [ForeignKey(nameof(MiscPaymentId))]
        public ApMiscPaymentHeaders ApMiscPaymentHeaders { get; protected set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }
        #endregion

        protected ApMiscPaymentDetails(string checkNumber,
           string beneficiaryName, decimal? amount, DateTime? maturityDate,
           long? miscPaymentId, string notes)
        {
            this.CheckNumber = checkNumber;
            this.BeneficiaryName = beneficiaryName;
            this.Amount = amount;
            this.MaturityDate = maturityDate;
            this.MiscPaymentId = miscPaymentId;
            this.Notes = notes;
        }

        public static ApMiscPaymentDetails Create(string checkNumber,
           string beneficiaryName, decimal? amount, DateTime? maturityDate,
           long? miscPaymentId, string notes)
        {
            return new ApMiscPaymentDetails(checkNumber,
                beneficiaryName, amount, maturityDate,
                miscPaymentId,  notes);
        }
    }
}
