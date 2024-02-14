using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    [AutoMapTo(typeof(ScCommittee))]
    public class ScCommitteeCreateDto
    {
        public int TenantId { get; set; }

        [MaxLength(30)]
        public string CommitteeNumber { get; set; }

        public string CommitteeDate { get; set; }

        public long StatusLkpId { get; set; } = (long)FndEnum.FndLkps.New_ScCommittee;

        [MaxLength(4000)]
        public string Notes { get; set; }

        [Required]
        [MaxLength(200)]
        public string CommitteeName { get; set; }

        public virtual ICollection<ScCommitteeMemberDetailCreateDto> CommitteeMembersDetails { get; set; }

        public virtual ICollection<ScCommitteeDetailCreateDto> CommitteeDetails { get; set; }

        public virtual ICollection<ScCommitteeMemberDetailCreateDto> ListMembers { get; set; }

        public virtual ICollection<ScCommitteeDetailCreateDto> ListStudies { get; set; }
    }
}
