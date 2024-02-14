using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__HR._PyPayrollTypes.Dto
{
    [AutoMap(typeof(PyPayrollTypes))]
    public class PyPayrollTypesCreateDto
    {
        [MaxLength(200)]
        public string PayrollTypeNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string PyPayrollTypeName { get; set; }
    }
}
