using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using ERP._System._GlPeriods;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._HrPersonsDeduction
{
    public class HrPersonsDeductionHd : PostAuditedEntity<long>, IMustHaveTenant
    {

        [Required]
        [MaxLength(30)]
        public string DeductionNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string DeductionName { get; protected set; }

        public long PeriodId { get; protected set; }

        public long StatusLkpId { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(PeriodId))]
        public GlPeriodsDetails Periods { get; protected set; }

        public virtual ICollection<HrPersonsDeductionTr> HrPersonsDeductionTr { get; protected set; }

        public int TenantId { get; set; }
    }
}
