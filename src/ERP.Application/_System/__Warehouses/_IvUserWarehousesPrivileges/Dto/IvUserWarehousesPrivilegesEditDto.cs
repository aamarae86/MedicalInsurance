using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System.__Warehouses._IvUserWarehousesPrivileges.Dto
{
    [AutoMap(typeof(IvUserWarehousesPrivileges))]
    public class IvUserWarehousesPrivilegesEditDto : EntityDto<long>
    {
        public long IvWarehouseId { get; set; }

        public long UserId { get; set; }

        public bool HasIssue { get; set; }

        public bool HasReceive { get; set; }
    }
}
