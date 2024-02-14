
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._ArCustomers;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SalesModule.ArInvoiceSettlement
{
    public class ArInvoiceSettlementHd : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        public DateTime SettlementDate { get; set; }

        [Required]
        public long StatusLkpId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal SettlementAmount { get; set; }

        [Required]
        public string SettlementNumber { get; set; }

        [Required]
        public long ArCustomerId { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }
        public int TenantId { get; set; }

        [ForeignKey(nameof(ArCustomerId))]
        public ArCustomers ArCustomers { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 5)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        public virtual ICollection<ArInvoiceSettlementCr> ArInvoiceSettlementCr { get; protected set; }
        public virtual ICollection<ArInvoiceSettlementDr> ArInvoiceSettlementDr { get; protected set; }
    }
}
