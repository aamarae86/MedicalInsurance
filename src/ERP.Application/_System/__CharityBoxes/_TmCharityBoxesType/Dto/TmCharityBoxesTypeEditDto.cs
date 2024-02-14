using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._TmCharityBoxesType.Dto
{
    [AutoMap(typeof(TmCharityBoxesType))]
    public class TmCharityBoxesTypeEditDto : EntityDto<long>
    {
        [MaxLength(20)]
        [Required]
        public string TypeCode { get; set; }

        [Required]
        [MaxLength(200)]
        public string CharityBoxTypeName { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public bool IsActive { get; set; }
    }
}
