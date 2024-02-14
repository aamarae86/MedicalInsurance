using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvUserWarehousesPrivileges.Dto
{
    [AutoMap(typeof(IvUserWarehousesPrivileges))]
    public class IvUserWarehousesPrivilegesCreateDto
    {
        public long IvWarehouseId { get; set; }

        public long UserId { get; set; }

        public bool HasIssue { get; set; }

        public bool HasReceive { get; set; }
    }
}
