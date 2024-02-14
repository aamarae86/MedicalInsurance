using Abp.Domain.Entities;
using ERP._System.__AidModule._ScMaintenanceContract;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScMaintenancePayments
{
    public class ScMaintenancePayments : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string MaintenancePaymentNumber { get; protected set; }

        public DateTime MaintenancePaymentDate { get; protected set; }

        public DateTime MaturityDate { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long ScMaintenanceContractPaymentId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal AchievementRate { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Amount { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(StatusLkpId))]
        public virtual FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(ScMaintenanceContractPaymentId))]
        public virtual ScMaintenanceContractPayments ScMaintenanceContractPayments { get; protected set; }
    }
}
