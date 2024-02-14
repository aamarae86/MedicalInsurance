using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPaperRequest.Dto
{
  public  class HrPaperRequestPagedDto : PagedAndSortedResultRequestDto
    {
        public HrPaperRequestSearchDto Params { get; set; }

    }
}
