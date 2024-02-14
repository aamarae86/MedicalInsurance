using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._ArJobCardHd;
using ERP._System.__AccountModule._ArReceipts;
using ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System.__SalesModule.ArInvoiceSettlement;
using ERP._System._ArDrCrHd;
using ERP._System._ArPdcInterface;
using ERP._System._ArSecurityDepositInterface;
using ERP._System._FndLookupValues;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ArCustomers
{
    public class ArCustomers : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        [Required]
        public int CustomerNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string CustomerNameAr { get; set; }

        [Required]
        [MaxLength(200)]
        public string CustomerNameEn { get; set; }

        [Required]
        public long StatusLkpId { get; set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValues { get; protected set; }


        [Column(TypeName = "decimal(18, 6)")]
        public decimal? CreditLimit { get; protected set; }
        public string TaxNo { get; set; }
        [Required]
        public long CustomerTypeLkpId { get; set; }

        [ForeignKey(nameof(CustomerTypeLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesCustType { get; protected set; }

        public long SourceCodeLkpId { get; set; }

        public long? SourceId { get; set; }

        [ForeignKey(nameof(SourceCodeLkpId)), Column(Order = 2)]
        public FndLookupValues FndLookupValuesSource { get; protected set; }

        public virtual ICollection<ArPdcInterface> ArPdcInterface { get; protected set; }

        public virtual ICollection<ArDrCrHd> ArDrCrHd { get; protected set; }

        public virtual ICollection<ArInvoiceHd> ArInvoiceHd { get; protected set; }

        public virtual ICollection<ArSecurityDepositInterface> ArSecurityDepositInterface { get; protected set; }

        public virtual ICollection<GlJeIntegrationLines> GlJeIntegrationLines { get; protected set; }


        [MaxLength(4000)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string HomeTel { get; set; }

        [MaxLength(50)]
        public string WorkTel { get; set; }

        [MaxLength(50)]
        public string Mobile { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Website { get; set; }

        public bool IsActive { get; set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }

        public long? PaymentTermsLkpId { get; set; }

        [ForeignKey(nameof(PaymentTermsLkpId))]
        public FndLookupValues FndPaymentTermsLkp { get; protected set; }

        [InverseProperty(nameof(ArReceipts.ArCustomer))]
        public virtual ICollection<ArReceipts> ArReceiptCustomers { get; protected set; }

        [InverseProperty(nameof(ArJobCardHd.ArCustomers))]
        public virtual ICollection<ArJobCardHd> ArJobCardCollection { get; protected set; }

        [InverseProperty(nameof(ArInvoiceSettlementHd.ArCustomers))]
        public virtual ICollection<ArInvoiceSettlementHd> ArInvoiceSettlementHdCollection { get; protected set; }

    }
}
