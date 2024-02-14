using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._Counters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System._CountersDetails
{
    public class CountersDetails : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        public long CounterId { get; set; }
        public long Value { get; set; }
        public int? Year { get; set; }
        public bool IsActive { get; set; }
        public int TenantId { get; set; }
        [ForeignKey(nameof(CounterId))]
        public Counters Counters { get;protected set; }
    }
}
