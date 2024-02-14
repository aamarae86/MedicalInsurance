using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._HrPersons._HrPersonIdentityCard
{
    public class HrPersonIdentityCard : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(3)]
        public string Segment1 { get; protected set; }

        [MaxLength(4)]
        public string Segment2 { get; protected set; }

        [MaxLength(7)]
        public string Segment3 { get; protected set; }

        [MaxLength(1)]
        public string Segment4 { get; protected set; }

        [MaxLength(50)]
        public string IdNumber { get; protected set; }

        [MaxLength(50)]
        public string CardNo { get; protected set; }

        public DateTime? DateOfExpiry { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public long HrPersonId { get; protected set; }

        [ForeignKey(nameof(HrPersonId))]
        public HrPersons HrPersons { get; protected set; }

        public int TenantId { get; set; }

    }
}
