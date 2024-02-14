using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using ERP._System._GlCodeComDetails;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModule._ApInvoiceHd._ApInvoiceTr
{
    public class ApInvoiceTr : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(4000)]
        public string Desc { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Amount { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal TaxAmount { get; protected set; }

        public long ApInvoiceHdId { get; protected set; }

        public long AccountId { get; protected set; }

        public long? TaxPercentageLkpId { get; protected set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }

        [ForeignKey(nameof(ApInvoiceHdId))]
        public ApInvoiceHd ApInvoiceHd { get; protected set; }

        [ForeignKey(nameof(TaxPercentageLkpId))]
        public FndLookupValues FndTaxPercentageLkp { get; protected set; }

        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        public static decimal GetTaxAmount(long? taxPercentageLkpId ,decimal amount)
        {
            decimal? taxtPerc = 0;

            switch (taxPercentageLkpId)
            {
                case 10995: taxtPerc = 0; break;
                case 10996: taxtPerc = 5; break;
                case 10997: taxtPerc = 0; break;
                default: taxtPerc = 0; break;
            }

            return taxtPerc == 0 ? 0 : (((decimal)taxtPerc / 100) * amount);
        }

    }
}
