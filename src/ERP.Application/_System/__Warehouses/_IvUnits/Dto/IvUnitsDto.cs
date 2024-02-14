using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvUnits.Dto
{
    [AutoMap(typeof(IvUnits))]
    public class IvUnitsDto : AuditedEntityDto<long>
    {
        [MaxLength(20)]
        public string UnitCode { get; set; }

        [MaxLength(200)]
        public string UnitName { get; set; }
    }
}
