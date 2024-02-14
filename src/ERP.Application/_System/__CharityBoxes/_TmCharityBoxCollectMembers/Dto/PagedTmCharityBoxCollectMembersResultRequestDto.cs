using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollectMembers.Dto
{
    public class PagedTmCharityBoxCollectMembersResultRequestDto: PagedAndSortedResultRequestDto
    {
        public TmCharityBoxCollectMembersSearchDto Params { get; set; }

    }
}
