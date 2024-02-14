using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._PyElements;
using ERP._System._GlPeriods;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._HrPersons._HrPersonSalaryElements
{
    public class HrPersonSalaryElements : AuditedEntity<long>, IMustHaveTenant
    {
        public long PyElementId { get; protected set; }

        public long StartPeriodId { get; protected set; }

        public long? EndPeriodId { get; protected set; }

        public long HrPersonId { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Amount { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [ForeignKey(nameof(HrPersonId))]
        public HrPersons HrPersons { get; protected set; }

        [ForeignKey(nameof(PyElementId))]
        public PyElements PyElements { get; protected set; }

        [ForeignKey(nameof(StartPeriodId)), Column(Order = 0)]
        public GlPeriodsDetails StartPeriods { get; protected set; }

        [ForeignKey(nameof(EndPeriodId)), Column(Order = 1)]
        public GlPeriodsDetails EndPeriods { get; protected set; }

        public int TenantId { get; set; }
    }
}
