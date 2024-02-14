using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ItemQtyPerWarehouseReport.Dto
{
    public class ItemQtyPerWarehousePagedDto : PagedAndSortedResultRequestDto
    {
        public ItemQtyPerWarehouseSearchDto Params { get; set; }
        //public SortModel OrderByValue { get; set; }
    }
}
