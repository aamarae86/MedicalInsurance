using Abp.Domain.Entities;
using ERP._System.__AccountModule._GeneralUnPost;
using ERP._System.__AidModule._ScCommitteesCheck;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScCommittee
{
    public class ScCommittee : PostAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        [Required]
        [MaxLength(30)]
        public string CommitteeNumber { get; protected set; }

        public DateTime CommitteeDate { get; protected set; }

        public long StatusLkpId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string CommitteeName { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupStatusValues { get; protected set; }

        public virtual ICollection<ScCommitteeMemberDetail> CommitteeMembersDetails { get; protected set; }
        public virtual ICollection<ScCommitteeDetail> CommitteeDetails { get; protected set; }
        public virtual ICollection<ScCommitteesCheck> ScCommitteesCheck { get; protected set; }
        public virtual ICollection<GeneralUnPost> GeneralUnPost { get; protected set; }
    }
}
