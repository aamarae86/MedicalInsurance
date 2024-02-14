using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._PmProperties;
using ERP._System._GlCodeComDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmPropertiesRevenueAccounts
{
    public class PmPropertiesRevenueAccounts : AuditedEntity<long>, IMustHaveTenant
    {
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Percentage { get; protected set; }

        public long AccountId { get; protected set; }

        public long AdvanceAccountId { get; protected set; }

        public long PropertyId { get; protected set; }

        [ForeignKey(nameof(PropertyId))]
        public PmProperties PmProperties { get; protected set; }

        [ForeignKey(nameof(AccountId)),Column(Order = 0)]
        public GlCodeComDetails AccountGlCodeComDetails { get; set; }

        [ForeignKey(nameof(AdvanceAccountId)), Column(Order = 1)]
        public GlCodeComDetails AdvanceAccountGlCodeComDetails { get; set; }

        public int TenantId { get; set; }

    }
}
