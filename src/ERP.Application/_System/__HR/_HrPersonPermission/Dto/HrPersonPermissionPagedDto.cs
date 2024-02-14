using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonPermission.Dto
{
   public class HrPersonPermissionPagedDto : PagedAndSortedResultRequestDto
    {
        public HrPersonPermissionSearchDto Params { get; set; }

    }
}
