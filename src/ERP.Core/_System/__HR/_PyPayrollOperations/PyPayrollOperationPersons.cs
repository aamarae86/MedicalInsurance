using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._PyPayrollOperations
{
    public class PyPayrollOperationPersons : AuditedEntity<long>, IMustHaveTenant
    {
        public long PyPayrollOperationId { get; protected set; }

        public long? BankLkpId { get; protected set; }

        public long? HrPersonId { get; protected set; }

        [MaxLength(50)]
        public string AccountNumber { get; protected set; }

        [ForeignKey(nameof(HrPersonId))]
        public _HrPersons.HrPersons HrPersons { get; protected set; }

        [ForeignKey(nameof(BankLkpId))]
        public FndLookupValues FndBankLkp { get; protected set; }

        [ForeignKey(nameof(PyPayrollOperationId))]
        public PyPayrollOperations PyPayrollOperations { get; protected set; }

        public virtual ICollection<PyPayrollOperationPersonDetails> PyPayrollOperationPersonDetails { get; protected set; }

        public int TenantId { get; set; }


    }
}
