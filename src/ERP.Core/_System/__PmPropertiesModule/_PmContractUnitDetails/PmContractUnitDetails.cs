using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmContractUnitDetails
{
    public class PmContractUnitDetails : AuditedEntity<long>, IMustHaveTenant
    {
        public long PropertiesUnitId { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Amount { get; protected set; }

        public long PmContractId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [ForeignKey(nameof(PmContractId))]
        public PmContract PmContract { get; protected set; }

        [ForeignKey(nameof(PropertiesUnitId))]
        public PmPropertiesUnits PmPropertiesUnits { get; protected set; }

        public int TenantId { get; set; }

    }
}
