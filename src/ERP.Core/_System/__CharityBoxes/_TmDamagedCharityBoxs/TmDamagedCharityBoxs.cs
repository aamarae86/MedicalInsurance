using Abp.Domain.Entities;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs._TmDamagedCharityBoxDetails;
using ERP._System.__CharityBoxes._TmSupervisors;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__CharityBoxes._TmDamagedCharityBoxs
{
    public class TmDamagedCharityBoxs : PostAuditedEntity<long>, IMustHaveTenant
    {
        public DateTime DamagedCharityBoxsDate { get; protected set; }

        [Required]
        [MaxLength(30)]
        public string DamagedCharityBoxsNumber { get; protected set; }

        public long TmSupervisorId { get; protected set; }

        public long StatusLkpId { get; protected set; }

        [ForeignKey(nameof(TmSupervisorId))]
        public TmSupervisors TmSupervisors { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndStatusLookup { get; protected set; }

        public string Notes { get; protected set; }

        public int TenantId { get; set; }

        public virtual ICollection<TmDamagedCharityBoxDetails> TmDamagedCharityBoxDetails { get; protected set; }
    }
}
