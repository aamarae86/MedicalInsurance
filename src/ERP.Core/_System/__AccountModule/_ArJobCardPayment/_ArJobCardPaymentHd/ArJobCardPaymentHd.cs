using Abp.Domain.Entities;
using ERP._System.__AccountModule._ArJobCardHd;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentTr;
using ERP._System.__PmPropertiesModule._ArInvoiceTr;
using ERP._System._ArCustomers;
using ERP._System._FndLookupValues;
using ERP.Currencies;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentHd
{
    public class ArJobCardPaymentHd : PostAuditedEntity<long>, IMustHaveTenant
    {
        
        public int TenantId { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [MaxLength(30)]
        public string TransactionNumber { get; set; }

        [Required]
        public long StatusLkpId { get; set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndJobCardPaymenStatusLkp { get; set; }
        
        [Required]
        public long ArJobCardHdId { get; set; }

        [ForeignKey(nameof(ArJobCardHdId))]
        public ArJobCardHd ArJobCardHd { get; set; }

        public long? TenxMigrationId { get; set; }
        public virtual ICollection<ArJobCardPaymentTr> ArJobCardPaymentTr { get; protected set; }
    }
}
