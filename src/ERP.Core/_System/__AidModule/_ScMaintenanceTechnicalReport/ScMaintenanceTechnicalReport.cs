using Abp.Domain.Entities;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScMaintenanceQuotations;
using ERP._System.__AidModule._ScPortalRequest;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport
{
    public class ScMaintenanceTechnicalReport : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string TechnicalReportNumber { get; protected set; }

        public DateTime TechnicalReportDate { get; protected set; }

        public long? StatusLkpId { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndStatusLkp { get; protected set; }

        public long? PortalRequestId { get; protected set; }

        public long? ScCommitteeDetailId { get; protected set; }

        [ForeignKey(nameof(PortalRequestId))]
        public ScPortalRequest PortalRequest { get; protected set; }

        [ForeignKey(nameof(ScCommitteeDetailId))]
        public ScCommitteeDetail ScCommitteeDetail { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public int TenantId { get; set; }

        public virtual ICollection<ScMaintenanceTechnicalReportAttachments> Attachments { get; protected set; }

        public virtual ICollection<ScMaintenanceTechnicalReportDetail> Details { get; protected set; }

        public virtual ICollection<ScMaintenanceQuotations> ScMaintenanceQuotations { get; protected set; }
    }
}
