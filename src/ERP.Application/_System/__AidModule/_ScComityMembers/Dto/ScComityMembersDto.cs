using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._ScComityMembers.Dto
{
    [AutoMapFrom(typeof(ScComityMembers))]
    public class ScComityMembersDto : EntityDto<long>, IPassivable
    {
        [MaxLength(30)]
        public string MemberNumber { get; set; }

        [MaxLength(200)]
        public string MemberName { get; set; }

        public long MemberCategoryLkpId { get; set; }

        public string MemberCategoryAr { get; set; }

        public string MemberCategoryEn { get; set; }

        public FndLookupValues FndLookupValues { get; set; }

        public bool IsActive { get; set; }
    }
}
