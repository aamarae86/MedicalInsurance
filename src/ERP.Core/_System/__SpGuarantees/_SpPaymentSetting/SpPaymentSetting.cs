using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpPaymentSetting
{
    public class SpPaymentSetting : AuditedEntity<long>, IMustHaveTenant
    {
        public long SponsorCategoryLkpId { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal ManagementPercentage { get; protected set; }

        public DateTime FromDate { get; protected set; }

        public DateTime? ToDate { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(SponsorCategoryLkpId))]
        public FndLookupValues FndSponsorCategoryLkp { get; protected set; }
    }
}
