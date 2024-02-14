using Abp.Domain.Entities;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System._FndLookupValues;
using ERP._System._GlCodeComDetails;
using ERP.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__PmPropertiesModule._PmCancellationContracts
{
    public class PmCancellationContracts : PostAuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string CancellationNumber { get; protected set; }

        public DateTime? CancellationDate { get; protected set; }

        public long? StatusLkpId { get; protected set; }

        public long? PmContractId { get; protected set; }

        public int? FinePeriodPerDays { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? FineAmount { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public long? AccountId { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupValues { get; set; }

        [ForeignKey(nameof(PmContractId))]
        public PmContract PmContract { get; set; }

        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails GlCodeComDetails { get; set; }

        public void UpdateData(long accountId, long? pmContractId, int? finePeriodPerDays,
           decimal? fineAmount, string cancellationDate, string notes)
        {
            this.AccountId = accountId;
            this.PmContractId = pmContractId;
            this.FineAmount = fineAmount;
            this.CancellationDate = DateTimeController.ConvertToDateTime(cancellationDate);
            this.FinePeriodPerDays = finePeriodPerDays;
            this.Notes = notes;
        }
    }
}
