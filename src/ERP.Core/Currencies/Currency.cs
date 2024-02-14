using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System.__AccountModule._ArReceipts;
using ERP._System._ApBankAccounts;
using ERP._System._ArDrCrHd;
using ERP._System._GlJeHeaders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ERP._System.__AccountModule._ApInvoiceHd;
using ERP._System.__Warehouses._IvReceiveHd;
using ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders;
using ERP._System.__AccountModule._ApDrCrHd;

namespace ERP.Currencies
{
    public class Currency : AuditedEntity<int>, IMustHaveTenant, IPassivable
    {
        [Required]
        [MaxLength(20)]
        public string Code { get; protected set; }

        [Required]
        [MaxLength(4000)]
        public string DescriptionAr { get; protected set; }

        [Required]
        [MaxLength(4000)]
        public string DescriptionEn { get; protected set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Rate { get; protected set; }

        [MaxLength(50)]
        public string MainCurrencyNameAr { get; protected set; }


        [MaxLength(50)]
        public string MainCurrencyNameEn { get; protected set; }

        [MaxLength(50)]
        public string SubCurrencyNameAr { get; protected set; }

        [MaxLength(50)]
        public string SubCurrencyNameEn { get; protected set; }

        [MaxLength(20)]
        public string AndNameEn { get; protected set; }

        [MaxLength(20)]
        public string AndNameAr { get; protected set; }

        [MaxLength(50)]
        public string LastWordEn { get; protected set; }

        [MaxLength(50)]
        public string LastWordAr { get; protected set; }


        public bool IsLocalCurrency { get; protected set; }

        public int TenantId { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<GlJeHeaders> GlJeHeaders { get; protected set; }
        public virtual ICollection<ApBankAccounts> ApBankAccounts { get; protected set; }
        public virtual ICollection<ArDrCrHd> ArDrCrHd { get; protected set; }
        public virtual ICollection<ApDrCrHd> ApDrCrHd { get; protected set; }
        public virtual ICollection<ArInvoiceHd> ArInvoiceHd { get; protected set; }
        public virtual ICollection<ApInvoiceHd> ApInvoiceHd { get; protected set; }
        public virtual ICollection<IvReceiveHd> IvReceiveHd { get; protected set; }
        public virtual ICollection<GlJeIntegrationHeaders> GlJeIntegrationHeaders { get; protected set; }


        [InverseProperty(nameof(ArReceipts.Currency))]
        public virtual ICollection<ArReceipts> ArReceiptCurrencies { get; protected set; }
    }
}
