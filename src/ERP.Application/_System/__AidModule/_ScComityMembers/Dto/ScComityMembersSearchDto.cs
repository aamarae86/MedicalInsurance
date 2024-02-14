using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ScComityMembers.Dto
{
    [AutoMapFrom(typeof(ScComityMembers))]
    public class ScComityMembersSearchDto
    {
        public string MemberNumber { get; set; }
        public string MemberName { get; set; }
        public long? MemberCategoryLkpId { get; set; }
        public override string ToString()
        {
            return $"Params.MemberNumber={MemberNumber}&Params.MemberName={MemberName}&Params.MemberCategoryLkpId={MemberCategoryLkpId}";
        }
    }
}
