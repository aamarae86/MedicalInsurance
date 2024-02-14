using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__HR._HrPersonVacations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._HrAbsencesTypes
{
    public class HrVacationsTypes : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string VacationsTypeNumber { get; protected set; }

        [MaxLength(200)]
        public string VacationsTypeName { get; protected set; }

        [MaxLength(4000)]
        public string VacationsTypeDesc { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? MaximumDaysPerYear { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? MaximumDays { get; protected set; }

        public int TenantId { get; set; }

        public virtual ICollection<HrPersonVacations> HrPersonVacations { get; protected set; }
    }
}
