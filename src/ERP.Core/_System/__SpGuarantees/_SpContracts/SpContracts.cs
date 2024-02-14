using Abp.Domain.Entities;
using ERP._System.__SpGuarantees._SpBeneficent;
using ERP._System.__SpGuarantees._SpContracts._SpContractAttachments;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpContracts
{
    public class SpContracts : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string ContractNumber { get; protected set; }

        public DateTime ContractDate { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long? PaymentTypeLkpId { get;protected set; }

        public long? DeductedLkpId { get;protected set; }

        public long SpBeneficentId { get; protected set; }

        [ForeignKey(nameof(SpBeneficentId))]
        public SpBeneficent SpBeneficent { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(PaymentTypeLkpId))]
        public FndLookupValues FndPaymentTypeLkp { get; protected set; }

        [ForeignKey(nameof(DeductedLkpId))]
        public FndLookupValues FndDeductedLkp { get; protected set; }

        public int TenantId { get; set; }

        public virtual ICollection<SpContractAttachments> SpContractAttachments { get; protected set; }
        public virtual ICollection<SpContractDetails> SpContractDetails { get; protected set; }

    }
}
