using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    [AutoMap(typeof(ScCommittee))]
    public class ScCommitteeEditDto : EntityDto<long>
    {
        public string CommitteeDate { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        [MaxLength(200)]
        public string CommitteeName { get; set; }

        public virtual ICollection<ScCommitteeMemberDetailEditDto> CommitteeMembersDetailEditList { get; set; }

        public virtual ICollection<ScCommitteeDetailEditDto> CommitteeDetailEditList { get; set; }

        public string ListMembersStr { get; set; }

        public string ListStudiesStr { get; set; }

        public virtual ICollection<ScCommitteeMemberDetailEditDto> ListEditMembers { get; set; }

        public virtual ICollection<ScCommitteeDetailEditDto> ListEditStudies { get; set; }
    }
}
