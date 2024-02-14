using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonsAdditionHd.Dto
{
    public class PagedHrPersonsAdditionHdRequestDto : PagedAndSortedResultRequestDto
    {
        public HrPersonsAdditionHdSearchDto Params { get; set; }
    }
}
