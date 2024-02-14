using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__AidModule._FndSpell
{
    public class FndSpell : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string OnesAr { get; protected set; }

        [Required]
        [MaxLength(30)]
        public string OnesEn { get; protected set; }


        [MaxLength(30)]
        public string TensAr { get; protected set; }

        [MaxLength(30)]
        public string TensEn { get; protected set; }


        [MaxLength(30)]
        public string HunsAr { get; protected set; }

        [MaxLength(30)]
        public string HunsEn { get; protected set; }

        public int TenantId { get ; set ; }
    }
}
