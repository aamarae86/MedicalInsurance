using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._GlCodeComDetails;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._GlMainAccounts
{
    public class GlMainAccounts : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        public long? AccountId { get; protected set; }

        [MaxLength(200)]
        public string ReferenceCode { get; protected set; }

        [MaxLength(4000)]
        public string Description { get; protected set; }

        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        public bool IsActive { get; set; }

        public int TenantId { get; set; }

        protected GlMainAccounts() { }

        public void SetAccountId(long? accountId)
        {
            this.AccountId = accountId;
        }
    }
}
