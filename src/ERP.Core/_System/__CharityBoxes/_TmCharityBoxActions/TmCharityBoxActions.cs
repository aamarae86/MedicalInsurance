using Abp.Domain.Entities;
using ERP._System.__CharityBoxes._TmCharityBoxActions._TmCharityBoxActionDetails;
using ERP._System.__CharityBoxes._TmSupervisors;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__CharityBoxes._TmCharityBoxActions
{
    public class TmCharityBoxActions : PostAuditedEntity<long>, IMustHaveTenant
    {

        public DateTime ActionsDate { get; protected set; }

        [Required]
        [MaxLength(30)]
        public string ActionsNumber { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long TmSupervisorId { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(TmSupervisorId))]
        public TmSupervisors TmSupervisors { get; protected set; }

        public virtual ICollection<TmCharityBoxActionDetails> TmCharityBoxActionDetailsCollection { get; protected set; }

        public int TenantId { get; set; }
    }
}
