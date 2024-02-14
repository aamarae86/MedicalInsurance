using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CRM._ActivityMeeting.Dto
{
    public class PagedActivityMeetingRequestDto : PagedAndSortedResultRequestDto
    {
        public ActivityMeetingSearchDto Params { get; set; }
    }
}
