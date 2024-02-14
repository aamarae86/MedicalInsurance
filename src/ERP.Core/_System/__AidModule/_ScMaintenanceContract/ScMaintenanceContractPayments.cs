using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._ScMaintenancePayments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScMaintenanceContract
{
    public class ScMaintenanceContractPayments : AuditedEntity<long>, IMustHaveTenant
    {
        public long ScMaintenanceContractId { get; protected set; }

        public int PayemtNo { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Amount { get; protected set; }

        [MaxLength(4000)]
        public string PaymentCondition { get; protected set; }

        public DateTime MaturityDate { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(ScMaintenanceContractId))]
        public virtual ScMaintenanceContract ScMaintenanceContract { get; protected set; }

        public virtual ICollection<ScMaintenancePayments> ScMaintenancePayments { get; protected set; }
    }
}
