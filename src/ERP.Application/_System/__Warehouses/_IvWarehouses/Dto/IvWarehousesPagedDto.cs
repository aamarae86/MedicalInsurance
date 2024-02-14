using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses.Dto
{
    public class IvWarehousesPagedDto : PagedAndSortedResultRequestDto
    {
        public IvWarehousesSearchDto Params { get; set; }
    }
}
