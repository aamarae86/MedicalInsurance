using Abp.Domain.Entities;
using ERP._System.__AidModule._ScCommittee;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScDeliveryOtherAids
{
    public class ScDeliveryOtherAids : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string OperationNumber { get; protected set; }

        public DateTime OperationDate { get; protected set; }

        public DateTime? MaturityDate { get; set; }

        public long StatusLkpId { get; protected set; }

        public long? CommitteeId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(CommitteeId))]
        public ScCommittee ScCommittee { get; protected set; }

        public virtual ICollection<ScDeliveryOtherAidDetails> ScDeliveryOtherAidDetails { get; protected set; }
    }
}
