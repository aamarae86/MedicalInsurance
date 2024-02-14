using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel.SubSystems.Conversion;
using ERP._System.__HR._HrPersons;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__HR._HrPersonsAdditionHd._HrPersonsAdditionTr
{
    public class HrPersonsAdditionTr : AuditedEntity<long>, IMustHaveTenant
    {
        public long? HrPersonAdditionHdId { get; protected set; }
        public long? HrPersonId { get; protected set; }
        public long? AdditionTypeLkpId { get; protected set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Amount { get; protected set; }
        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [ForeignKey(nameof(HrPersonAdditionHdId))]
        public HrPersonsAdditionHd HrPersonsAdditionHd { get; protected set; }

        [ForeignKey(nameof(HrPersonId))]
        public HrPersons HrPersons { get; protected set; }

        [ForeignKey(nameof(AdditionTypeLkpId))]
        public FndLookupValues FndLookupValuesHrPersonsAdditionHdAdditionTypeLkp { get; protected set; }
        public int TenantId { get; set; }
    }
}
