using Abp.Domain.Entities;
using ERP._System._FndLookupValues;
using ERP._System._GlPeriods;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._HrPersonsAdditionHd
{
    public class HrPersonsAdditionHd : PostAuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string AdditionNumber { get; protected set; }

        [MaxLength(200)]
        public string AdditionName { get; protected set; }

        public long? PeriodId { get; protected set; }

        public long? StatusLkpId { get; protected set; }

        [ForeignKey(nameof(PeriodId))]
        public GlPeriodsDetails GlPeriodsDetails { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupValuesHrPersonsAdditionHdStatusLkp { get; protected set; }

        public virtual ICollection<_HrPersonsAdditionTr.HrPersonsAdditionTr> HrPersonsAdditionTr { get; protected set; }

        public int TenantId { get; set; }
    }
}
