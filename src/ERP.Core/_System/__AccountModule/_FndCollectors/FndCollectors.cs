using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._ArMiscReceiptHeaders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System._FndCollectors
{
    public class FndCollectors : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        public int? CollectorNumber { get;protected set; } = 1;
        [Column(TypeName = "nvarchar(200)")]
        [MaxLength(200)]
        public string CollectorNameAr { get; protected set; }
        [Column(TypeName = "nvarchar(200)")]
        [MaxLength(200)]
        public string CollectorNameEn { get; protected set; }
        public bool IsActive { get; set; }
        public int TenantId { get; set; }

        public virtual ICollection<ArMiscReceiptHeaders> ArMiscReceiptHeaders { get; set; } 
    }
}
