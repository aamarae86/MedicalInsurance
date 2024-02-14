using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._FmEngineers.Dto
{
    [AutoMap(typeof(FmEngineers))]
    public class FmEngineersEditDto : EntityDto<long>
    {
        [Required]
        [MaxLength(100)]
        public string EngineerName { get; set; }

        public long StatusLkpId { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        [MaxLength(50)]
        public string Mobile1 { get; set; }

        [MaxLength(50)]
        public string Mobile2 { get; set; }

        public string HireDate { get; set; }

        public long? HrPersonsId { get; set; }
    }
}
