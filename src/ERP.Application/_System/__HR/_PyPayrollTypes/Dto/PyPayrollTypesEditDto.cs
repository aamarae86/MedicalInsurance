using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._PyPayrollTypes.Dto
{
    [AutoMap(typeof(PyPayrollTypes))]
    public class PyPayrollTypesEditDto : EntityDto<long>
    {
        [Required]
        [MaxLength(200)]
        public string PyPayrollTypeName { get; set; }
    }
}
