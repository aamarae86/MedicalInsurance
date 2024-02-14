using Abp.Domain.Entities;
using ERP._System.__AidModule._ScMaintenanceQuotations;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScMaintenanceContract
{
    public class ScMaintenanceContract : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string MaintenanceContractNumber { get; protected set; }

        public DateTime MaintenanceContractDate { get; protected set; }

        public long ScMaintenanceQuotationId { get; protected set; }

        public long StatusLkpId { get; protected set; }

        [MaxLength(200)]
        public string DurationOfImplementation { get; protected set; }

        public DateTime? StartDate { get; protected set; }

        [MaxLength(4000)]
        public string ContractTerms { get; protected set; }

        [MaxLength(4000)]
        public string OtherContractTerms { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(StatusLkpId))]
        public virtual FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(ScMaintenanceQuotationId))]
        public virtual ScMaintenanceQuotations ScMaintenanceQuotations { get; protected set; }

        public virtual ICollection<ScMaintenanceContractPayments> ScMaintenanceContractPayments { get; protected set; }
    }
}
