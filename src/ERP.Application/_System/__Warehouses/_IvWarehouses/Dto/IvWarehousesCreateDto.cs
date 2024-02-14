using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses.Dto
{
    [AutoMap(typeof(IvWarehouses))]
    public class IvWarehousesCreateDto
    {
        [MaxLength(20)]
        public string WarehouseNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string WarehouseName { get; set; }

        public long CityLkpId { get; set; }

        public bool IsDefault { get; set; }

        [MaxLength(200)]
        public string WarehouseAddress { get; set; }
    }
}
