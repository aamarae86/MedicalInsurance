using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__Warehouses.Dto;
using ERP.Users.Dto;

namespace ERP._System.__Warehouses._IvUserWarehousesPrivileges.Dto
{
    [AutoMap(typeof(IvUserWarehousesPrivileges))]
    public class IvUserWarehousesPrivilegesDto : AuditedEntityDto<long>
    {
        public long IvWarehouseId { get; set; }

        public long UserId { get; set; }

        public bool HasIssue { get; set; }

        public bool HasReceive { get; set; }

        public IvWarehousesDto IvWarehouses { get; set; }

        public UserDto User { get; set; }
    }
}
