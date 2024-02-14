using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._PortalUserData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._Portal._PortalUserIncomes
{
    public class PortalUserIncomes : AuditedEntity<long>
    {
        [Required]
        [MaxLength(200)]
        public string IncomeSourceName { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal MonthlyIncomeAmount { get; protected set; }

        public long PortalUserDataId { get; protected set; }

        [ForeignKey(nameof(PortalUserDataId))]
        public PortalUserData PortalUserData { get; set; }
    }
}
