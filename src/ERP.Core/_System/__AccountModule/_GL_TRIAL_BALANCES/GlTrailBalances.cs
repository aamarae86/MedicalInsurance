using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModule._GL_TRIAL_BALANCES
{
    public class GlTrailBalances : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(1)]
        public string Noa { get; protected set; }

        [MaxLength(100)]
        public string AccCode { get; protected set; }

        [MaxLength(100)]
        public string ParentCode { get; protected set; }

        [MaxLength(100)]
        public string ChildCode { get; protected set; }

        [MaxLength(1500)]
        public string AccDesc { get; protected set; }

        [MaxLength(1500)]
        public string AccAdesc { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? Dr { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? Cr { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? ObDr { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? ObCr { get; protected set; }

        public long UserId { get; protected set; }

        public int TenantId { get; set; }

        public bool? IsAccount { get; set; }
        
    }
}
