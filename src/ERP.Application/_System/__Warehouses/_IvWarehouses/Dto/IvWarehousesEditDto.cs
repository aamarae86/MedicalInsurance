using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvWarehouses.Dto
{
    [AutoMap(typeof(IvWarehouses))]
    public class IvWarehousesEditDto : EntityDto<long>
    {
        [Required]
        [MaxLength(200)]
        public string WarehouseName { get; set; }

        public long CityLkpId { get; set; }

        public bool IsDefault { get; set; }

        [MaxLength(200)]
        public string WarehouseAddress { get; set; }
    }
}
