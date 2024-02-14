using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPermissionType
{
   public  class HrPermissionTypePagedDto : PagedAndSortedResultRequestDto
    {
        public HrPermissionTypeSearchDto Params { get; set; }
    }
}
