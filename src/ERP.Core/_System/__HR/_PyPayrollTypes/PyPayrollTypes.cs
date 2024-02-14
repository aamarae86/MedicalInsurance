using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__HR._HrPersons;
using ERP._System.__HR._PyPayrollOperations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._PyPayrollTypes
{
    public class PyPayrollTypes : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string PayrollTypeNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string PyPayrollTypeName { get; protected set; }

        public int TenantId { get; set; }

        public virtual ICollection<HrPersons> HrPersons { get; protected set; }

        public virtual ICollection<PyPayrollOperations> PyPayrollOperations { get; protected set; }

    }
}
