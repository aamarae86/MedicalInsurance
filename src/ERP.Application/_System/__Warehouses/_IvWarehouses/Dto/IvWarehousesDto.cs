using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses.Dto
{
    [AutoMap(typeof(IvWarehouses))]
    public class IvWarehousesDto : AuditedEntityDto<long>
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

        public FndLookupValuesDto FndCityLkp { get; set; }
    }
}
