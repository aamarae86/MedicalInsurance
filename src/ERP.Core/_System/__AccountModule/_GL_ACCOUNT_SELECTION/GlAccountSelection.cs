using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._GL_ACCOUNT_SELECTION
{
    public class GlAccountSelection : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(100)]
        public string FlexField { get; protected set; }

        [MaxLength(1)]
        public string AccType { get; protected set; }

        [MaxLength(1)]
        public string YesNo { get; protected set; }

        [MaxLength(240)]
        public string FromValue { get; protected set; }

        [MaxLength(240)]
        public string ToValue { get; protected set; }

        public int? Seq { get; protected set; }

        public long UserId { get; protected set; }

        public int TenantId { get; set; }
    }
}
