using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollectMembers.Dto
{
    public class TmCharityBoxCollectMembersSearchDto
    {
        public string MemberNumber { get; set; }

        public string MemberName { get; set; }

        public long? MemberCategoryLkpId { get; set; }

        public
            override
            string
            ToString()
            => $"Params.MemberNumber={MemberNumber}&Params.MemberName={MemberName}&Params.MemberCategoryLkpId={MemberCategoryLkpId}";
    }
}
