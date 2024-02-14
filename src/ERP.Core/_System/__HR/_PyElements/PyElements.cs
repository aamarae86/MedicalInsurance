using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__HR._HrPersons._HrPersonSalaryElements;
using ERP._System._FndLookupValues;
using ERP._System._GlCodeComDetails;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._PyElements
{
    public class PyElements : AuditedEntity<long>, IMustHaveTenant
    {
        public int ElementSerial { get; protected set; }

        [MaxLength(200)]
        public string ElementName { get; protected set; }

        public long ElementTypeLkpId { get; protected set; }

        [MaxLength(4000)]
        public string Description { get; protected set; }

        public long? DebitAccountId { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(DebitAccountId)), Column(Order = 0)]
        public GlCodeComDetails CrGlCodeComDetailsDebitAccount { get; protected set; }

        [ForeignKey(nameof(ElementTypeLkpId))]
        public FndLookupValues FndLookupValuesElementTypeLkp { get; protected set; }

        public virtual ICollection<HrPersonSalaryElements> HrPersonSalaryElements { get; protected set; }
    }
}
