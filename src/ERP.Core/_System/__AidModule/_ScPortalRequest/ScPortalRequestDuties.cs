using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScPortalRequest
{
    public class ScPortalRequestDuties : Abp.Domain.Entities.Auditing.AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(200)]
        public string DutyType { get; protected set; }

        [MaxLength(200)]
        public string DutyDescription { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal MonthlyAmount { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? TotalAmount { get; protected set; }

        public long PortalRequestId { get; protected set; }

        [ForeignKey(nameof(PortalRequestId))]
        public ScPortalRequest ScPortalRequest { get; protected set; }

        public int TenantId { get; set; }
    }
}
