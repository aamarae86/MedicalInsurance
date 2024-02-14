using Abp.Domain.Entities;
using ERP._System._FndLookupValues;
using ERP._System._GlPeriods;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._PyPayrollOperations
{
    public class PyPayrollOperations : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(20)]
        public string OperationNumber { get; protected set; }

        public DateTime OperationDate { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long StatusLkpId { get; protected set; }

        public long PeriodId { get; protected set; }

        public long PyPayrollTypeId { get; protected set; }

        public long? HrPersonId { get; protected set; }

        public long? JobLkpId { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(JobLkpId)), Column(Order = 1)]
        public FndLookupValues FndJobLkp { get; protected set; }

        [ForeignKey(nameof(PeriodId))]
        public GlPeriodsDetails Periods { get; protected set; }

        [ForeignKey(nameof(HrPersonId))]
        public _HrPersons.HrPersons HrPersons { get; protected set; }

        [ForeignKey(nameof(PyPayrollTypeId))]
        public _PyPayrollTypes.PyPayrollTypes PyPayrollTypes { get; protected set; }

        public int TenantId { get; set; }

        public virtual ICollection<PyPayrollOperationPersons> PyPayrollOperationPersons { get; protected set; }

        protected PyPayrollOperations() { }
    }
}
