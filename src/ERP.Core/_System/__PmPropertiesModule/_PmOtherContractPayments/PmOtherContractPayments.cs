using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System.__PmPropertiesModule._PmOtherPaymentTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmOtherContractPayments
{
    public class PmOtherContractPayments : AuditedEntity<long>, IMustHaveTenant
    {
        public long OtherPaymentTypesId { get; protected set; }

        public long PmContractId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Amount { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [ForeignKey(nameof(PmContractId))]
        public PmContract PmContract { get; protected set; }

        [ForeignKey(nameof(OtherPaymentTypesId))]
        public PmOtherPaymentTypes PmOtherPaymentTypes { get; protected set; }

        public int TenantId { get; set; }
    }
}
