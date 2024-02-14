using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvUserWarehousesPrivileges.Dto
{
    public class IvUserWarehousesPrivilegesSearchDto
    {
        public long? IvWarehouseId { get; set; }
        public long? UserId { get; set; }
        public override string ToString() => $"Params.IvWarehouseId={IvWarehouseId}&Params.UserId={UserId}";
    }
}
