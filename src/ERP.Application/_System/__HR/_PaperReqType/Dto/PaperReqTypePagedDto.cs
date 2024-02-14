using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._PaperReqType.Dto
{
  public  class PaperReqTypePagedDto : PagedAndSortedResultRequestDto
    {
        public PaperReqTypeSearchDto Params { get; set; }

    }
}
