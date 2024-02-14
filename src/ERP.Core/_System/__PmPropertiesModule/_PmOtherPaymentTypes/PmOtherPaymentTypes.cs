using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._PmOtherContractPayments;
using ERP._System._GlCodeComDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmOtherPaymentTypes
{
    public class PmOtherPaymentTypes : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        [MaxLength(200)]
        public string PaymentTypeName { get; protected set; }

        public long AccountId { get; protected set; }

        public bool IsActive { get; set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        public virtual ICollection<PmOtherContractPayments> PmOtherContractPayments { get; protected set; }
}
}