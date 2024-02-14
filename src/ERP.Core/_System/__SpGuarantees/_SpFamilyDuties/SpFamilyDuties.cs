using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__SpGuarantees._SpFamilies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpFamilyDuties
{
    public class SpFamilyDuties : AuditedEntity<long>, IMustHaveTenant
    {
        public long SpFamilyId { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string DutyType { get; protected set; }

        [MaxLength(200)]
        public string DutyDescription { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal MonthlyAmount { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? TotalAmount { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(SpFamilyId))]
        public SpFamilies SpFamilies { get; protected set; }
    }
}
