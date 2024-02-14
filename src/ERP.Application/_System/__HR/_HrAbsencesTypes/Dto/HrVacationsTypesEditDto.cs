using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrAbsencesTypes.Dto
{
    [AutoMap(typeof(HrVacationsTypes))]
    public class HrVacationsTypesEditDto : EntityDto<long>
    {
        [MaxLength(200)]
        public string VacationsTypeName { get; set; }

        [MaxLength(4000)]
        public string VacationsTypeDesc { get; set; }

        public decimal? MaximumDaysPerYear { get; set; }

        public decimal? MaximumDays { get; set; }
    }
}
