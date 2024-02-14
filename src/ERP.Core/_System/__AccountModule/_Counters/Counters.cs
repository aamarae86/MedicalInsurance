using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._CountersDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System._Counters
{
    public class Counters : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
   
        [Column(TypeName = "nvarchar(200)")]
        [MaxLength(200)]
        public string CounterName { get; set; }

        public long CounterTypeLkp { get; set; }

        public bool IsActive { get; set; }

        public int TenantId { get; set; }

        public virtual ICollection<CountersDetails> CountersDetails { get; protected set; }
    }
}
