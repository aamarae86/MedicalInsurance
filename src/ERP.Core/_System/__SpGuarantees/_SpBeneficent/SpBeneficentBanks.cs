using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
//using ERP._System.__SpGuarantees._SpBeneficentsCheckDetails;
//using ERP._System.__SpGuarantees._ScPortalRequestStudy;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpBeneficent
{
    public class SpBeneficentBanks : AuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public long SpBeneficentId { get; protected set; }

        [Required]
        public long BankLkpId { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string AccountNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string AccountOwnerName { get; protected set; }

        public bool IsDefault { get; protected set; }

        [ForeignKey(nameof(SpBeneficentId))]
        public SpBeneficent Beneficent { get; protected set; }

        [ForeignKey(nameof(BankLkpId))]
        public FndLookupValues LookupBankValues { get; protected set; }
    }
}
