using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._ScComityMembers.Dto
{
    [AutoMap(typeof(ScComityMembers))]
    public class ScComityMembersEditDto : EntityDto<long>
    {
        [MaxLength(200)]
        public string MemberName { get; set; }

        public long MemberCategoryLkpId { get; set; }

        public bool IsActive { get; set; }
    }
}
