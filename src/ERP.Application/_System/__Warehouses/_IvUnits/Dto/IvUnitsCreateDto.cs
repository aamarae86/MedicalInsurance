using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__Warehouses._IvUnits.Dto
{
    [AutoMap(typeof(IvUnits))]
    public class IvUnitsCreateDto
    {
        [MaxLength(20)]
        public string UnitCode { get; set; }
        [MaxLength(200)]
        public string UnitName { get; set; }
    }
}
