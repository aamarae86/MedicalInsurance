using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__CharityBoxes._TmSupervisors
{
    public class TmSupervisors : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string SupervisorNumber { get; protected set; }

        [MaxLength(200)]
        public string SupervisorName { get; protected set; }

        public long? SourceLkpId { get; protected set; }

        public long? StatusLkpId { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupValues { get; set; }

        public virtual ICollection<TmDamagedCharityBoxs> TmDamagedCharityBoxs { get; set; }
    }
}
