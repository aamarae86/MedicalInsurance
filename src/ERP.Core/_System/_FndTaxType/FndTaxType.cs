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
using ERP._System._ApMiscPaymentLines;

namespace ERP._System._FndTaxType
{
   public class FndTaxType : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string TaxTypeNumber { get; protected set; }
        [MaxLength(200)]
        [Required]
        public string TaxNameAr { get; protected set; }
        [Required]
        [MaxLength(200)]
        public string TaxNameEn { get; protected set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Percentage { get; protected set; }
        public int TenantId { get; set; }

        public virtual ICollection<ApMiscPaymentLines> ApMiscPaymentLines { get; protected set; }

    }
}
