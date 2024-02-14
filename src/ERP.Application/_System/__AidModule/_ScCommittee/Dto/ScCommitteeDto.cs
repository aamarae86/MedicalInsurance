using Abp.AutoMapper;
using Abp.Domain.Entities;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    [AutoMapFrom(typeof(ScCommittee))]
    public class ScCommitteeDto : PostAuditedEntityDto<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        [MaxLength(30)]
        public string CommitteeNumber { get; set; }

        public string CommitteeDate { get; set; }

        public long StatusLkpId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        [MaxLength(200)]
        public string CommitteeName { get; set; }

        public FndLookupValuesDto FndLookupStatusValues { get; set; }

        public virtual ICollection<ScCommitteeMemberDetailDto> CommitteeMembersDetails { get; set; }

        public virtual ICollection<ScCommitteeDetailDto> CommitteeDetails { get; set; }

    }
}
