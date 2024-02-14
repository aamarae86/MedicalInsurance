using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._TimeSheetType.Dto
{
   public class TimeSheetTypePagedDto : PagedAndSortedResultRequestDto
    {
        public TimeSheetTypeSearchDto Params { get; set; }
    }
}
