using Abp.Domain.Entities;
using ERP._System.__HR._HrAbsencesTypes;
using ERP._System.__HR._HrPersons;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._HrPersonVacations
{
    public class HrPersonVacations : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string OperationNumber { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal VacationBalance { get; protected set; }

        public DateTime OperationDate { get; protected set; }

        public DateTime StartDate { get; protected set; }

        public DateTime EndDate { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long HrVacationsTypeId { get; protected set; }

        public long HrPersonId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(HrVacationsTypeId))]
        public HrVacationsTypes HrVacationsTypes { get; protected set; }

        [ForeignKey(nameof(HrPersonId))]
        public HrPersons HrPersons { get; protected set; }

        public int TenantId { get; set; }
    }
}
