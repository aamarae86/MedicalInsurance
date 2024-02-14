using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__HR._HrPersons;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._HrPersonsDeduction
{
    public class HrPersonsDeductionTr : AuditedEntity<long>, IMustHaveTenant
    {
        public long HrPersonDeductionHdId { get; protected set; }

        public long HrPersonId { get; protected set; }

        public long DeductionTypeLkpId { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Amount { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [ForeignKey(nameof(HrPersonDeductionHdId))]
        public HrPersonsDeductionHd HrPersonsDeductionHd { get; protected set; }

        [ForeignKey(nameof(HrPersonId))]
        public HrPersons HrPersons { get; protected set; }

        [ForeignKey(nameof(DeductionTypeLkpId))]
        public FndLookupValues FndDeductionTypeLkp { get; protected set; }

        public int TenantId { get; set; }

    }
}
