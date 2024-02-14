using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._VendorItemsReport.Dto
{
    public class VendorItemPagedDto : PagedAndSortedResultRequestDto
    {
        public VendorItemSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
