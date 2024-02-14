using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._ApInvoiceHd;
using ERP._System.__AccountModuleExtend._ApPaymentsTransactions;
using ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders;
using ERP._System.__AidModule._ScMaintenanceQuotations;
using ERP._System.__Warehouses._IvReceiveHd;
using ERP._System._FndLookupValues;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ApVendors
{
    public class ApVendors : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string VendorNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string VendorNameAr { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string VendorNameEn { get; protected set; }

        public long StatusLkpId { get; protected set; }

        [MaxLength(4000)]
        public string Comments { get; protected set; }

        [MaxLength(4000)]
        public string Address { get; protected set; }

        [MaxLength(20)]
        public string WorkTel { get; protected set; }

        [MaxLength(20)]
        public string Mobile { get; protected set; }

        [MaxLength(20)]
        public string Fax { get; protected set; }

        [MaxLength(200)]
        public string Email { get; protected set; }

        [MaxLength(400)]
        public string TaxNo { get; protected set; }

        public long VendorCategoryLkpId { get; protected set; }

        public int TenantId { get; set; }
        public long? TenxMigrationId { get; set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(VendorCategoryLkpId)), Column(Order = 1)]
        public FndLookupValues FndVendorCategoryLkp { get; protected set; }

        public virtual ICollection<ApInvoiceHd> ApInvoiceHd { get; protected set; }

        public virtual ICollection<ApPaymentsTransactions> ApPaymentsTransactions { get; protected set; }

        public virtual ICollection<IvReceiveHd> IvReceiveHd { get; protected set; }

        public virtual ICollection<GlJeIntegrationLines> GlJeIntegrationLines { get; protected set; }

        public virtual ICollection<ScMaintenanceQuotations> ScMaintenanceQuotations { get; protected set; }
    }
}
