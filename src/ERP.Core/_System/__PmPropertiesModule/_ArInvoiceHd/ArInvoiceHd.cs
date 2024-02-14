using Abp.Domain.Entities;
using ERP._System.__PmPropertiesModule._ArInvoiceTr;
using ERP._System._ArCustomers;
using ERP._System._FndLookupValues;
using ERP.Currencies;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__PmPropertiesModule._ArInvoiceHd
{
    public class ArInvoiceHd : PostAuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string HdInvoiceNo { get; protected set; }

        public DateTime? HdDate { get; protected set; }

        [MaxLength(4000)]
        public string Comments { get; protected set; }

        public long? StatusLkpId { get; protected set; }

        public int? CurrancyId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? CurrancyRate { get; protected set; }

        public long? ArCustomerId { get; protected set; }

        public long? SourceLkpId { get; protected set; }

        public long? SourceId { get; protected set; }

        [MaxLength(30)]
        public string SourceNo { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValuesArInvoiceHdStatusLkp { get; protected set; }

        [ForeignKey(nameof(SourceLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesArInvoiceHdSourceLkp { get; protected set; }

        [ForeignKey(nameof(CurrancyId))]
        public Currency Currency { get; protected set; }

        [ForeignKey(nameof(ArCustomerId))]
        public ArCustomers ArCustomers { get; protected set; }
        public long? TenxMigrationId { get; set; }
        public virtual ICollection<ArInvoiceTr> ArInvoiceTr { get; protected set; }
    }
}
