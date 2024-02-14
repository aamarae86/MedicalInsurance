using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._PyPayrollOperations
{
    public class PyPayrollOperationPersonDetails : AuditedEntity<long>, IMustHaveTenant
    {
        public long PyPayrollOperationPersonId { get; protected set; }

        public long SourceCodeLkpId { get; protected set; }

        public long? SourceId { get; protected set; }

        [MaxLength(200)]
        public string SourceName { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? EarningAmount { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? DeductionAmount { get; protected set; }

        [ForeignKey(nameof(SourceCodeLkpId))]
        public FndLookupValues FndSourceCodeLkp { get; protected set; }

        [ForeignKey(nameof(PyPayrollOperationPersonId))]
        public PyPayrollOperationPersons PyPayrollOperationPersons { get; protected set; }

        public int TenantId { get; set; }
    }
}
