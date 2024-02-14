using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using ERP._System._ScComityMembers.Dto;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    [AutoMapFrom(typeof(ScCommitteeMemberDetail))]
    public class ScCommitteeMemberDetailDto : EntityDto<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public long CommitteeId { get; set; }
        public long CommitteeMemberId { get; set; }
        #region Flat Properties
        public string MemberNumber { get; set; }

        public string MemberName { get; set; }

        public string MemberCategoryEn { get; set; }

        public string MemberCategoryAr { get; set; }

        //public string CommitteeMemberId { get; set; }
        #endregion
    }

}
