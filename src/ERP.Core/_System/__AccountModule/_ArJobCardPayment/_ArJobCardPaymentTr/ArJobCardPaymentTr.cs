using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentHd;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System._FndLookupValues;
using ERP._System._GlCodeComDetails;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentTr
{
    public class ArJobCardPaymentTr : AuditedEntity<long>, IMustHaveTenant
    {
        
        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }

        [Required]
        public long SourceId { get; set; }

        [Required]
        public long SourceTypeLkpId { get; set; }

        [ForeignKey(nameof(SourceTypeLkpId))]
        public FndLookupValues FndJobCardPaymentSourceTypeLkp { get; set; }

        [Required]
        public long ArJobCardPaymentHdId { get;  set; }

        [ForeignKey(nameof(ArJobCardPaymentHdId))]
        public ArJobCardPaymentHd ArJobCardPaymentHd { get; protected set; }



    }
}
