using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ApVendors.Dto
{
    public class PagedApVendorsResultRequestDto : PagedAndSortedResultRequestDto
    {
        public ApVendorsSearchDto Params { get; set; }

    }
}
