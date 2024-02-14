using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System._ScComityMembers.Dto
{
    [AutoMapFrom(typeof(ScComityMembers))]
    [AutoMapTo(typeof(ScComityMembers))]
    [AutoMap(typeof(ScComityMembers))]
    public class CreateScComityMembersDto
    {
        [MaxLength(30)]
        public string MemberNumber { get; set; } = "1";
        [MaxLength(200)]
        public string MemberName { get; set; }
        public long MemberCategoryLkpId { get; set; }
        public bool IsActive { get; set; }
    }
}
