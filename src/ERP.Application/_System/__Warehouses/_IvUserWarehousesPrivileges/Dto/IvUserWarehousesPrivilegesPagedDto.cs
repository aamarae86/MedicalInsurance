using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvUserWarehousesPrivileges.Dto
{
    public class IvUserWarehousesPrivilegesPagedDto : PagedAndSortedResultRequestDto
    {
        public IvUserWarehousesPrivilegesSearchDto Params { get; set; }
    }
}
