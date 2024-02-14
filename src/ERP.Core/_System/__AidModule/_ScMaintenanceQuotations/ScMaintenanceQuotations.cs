using Abp.Domain.Entities;
using ERP._System.__AidModule._ScMaintenanceContract;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport;
using ERP._System._ApVendors;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScMaintenanceQuotations
{
    public class ScMaintenanceQuotations : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string QuotationNumber { get; protected set; }

        public DateTime QuotationDate { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long ScMaintenanceTechnicalReportId { get; protected set; }

        public long VendorId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [ForeignKey(nameof(ScMaintenanceTechnicalReportId))]
        public ScMaintenanceTechnicalReport ScMaintenanceTechnicalReport { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(VendorId))]
        public ApVendors ApVendors { get; protected set; }

        public virtual ICollection<ScMaintenanceQuotationDetails> ScMaintenanceQuotationDetails { get; protected set; }

        public virtual ICollection<ScMaintenanceQuotationAttachments> ScMaintenanceQuotationAttachments { get; protected set; }

        public virtual ICollection<ScMaintenanceContract> ScMaintenanceContract { get; protected set; }

        public int TenantId { get; set; }
    }
}
