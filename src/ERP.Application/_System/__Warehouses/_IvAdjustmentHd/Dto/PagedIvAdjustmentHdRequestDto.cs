using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvAdjustmentHd.Dto
{
    public class PagedIvAdjustmentHdRequestDto : PagedAndSortedResultRequestDto
    {
        public IvAdjustmentHdSearchDto Params { get; set; }
    }
}
