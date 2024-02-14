using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonTimeSheet.Dto
{
   public  class HrPersonTimeSheetPagedDto : PagedAndSortedResultRequestDto
    {
        public HrPersonTimeSheetSearchDto Params { get; set; }

    }
}
