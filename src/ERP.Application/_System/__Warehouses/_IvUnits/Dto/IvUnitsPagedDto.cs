using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvUnits.Dto
{
    public class IvUnitsPagedDto : PagedAndSortedResultRequestDto
    {
        public IvUnitsSearchDto Params { get; set; }
    }
}
