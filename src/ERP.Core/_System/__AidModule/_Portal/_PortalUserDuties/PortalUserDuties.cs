using ERP._System.__AidModule._PortalUserData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._Portal._PortalUserDuties
{
    public class PortalUserDuties : Abp.Domain.Entities.Auditing.AuditedEntity<long>
    {
        [Required]
        [MaxLength(200)]
        public string DutyType { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string DutyDescription { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal MonthlyAmount { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? TotalAmount { get; protected set; }

        public long PortalUserDataId { get; protected set; }

        [ForeignKey(nameof(PortalUserDataId))]
        public PortalUserData PortalUserData { get; protected set; }

    }
}
