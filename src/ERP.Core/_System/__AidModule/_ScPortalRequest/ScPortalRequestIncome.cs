using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScPortalRequest
{
    public class ScPortalRequestIncome : AuditedEntity<long>,IMustHaveTenant
    {

        [Required]
        [MaxLength(200)]
        public string IncomeSourceName { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal MonthlyIncomeAmount { get; protected set; }

        public long PortalRequestId { get; protected set; }

        [ForeignKey(nameof(PortalRequestId))]
        public ScPortalRequest ScPortalRequest { get; set; }

        public int TenantId { get ; set ; }
    }
}
