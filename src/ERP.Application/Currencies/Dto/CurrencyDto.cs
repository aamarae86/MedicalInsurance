using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ERP.Currencies.Dto
{
    [AutoMapFrom(typeof(Currency))]
    public class CurrencyDto : AuditedEntityDto<int>, IPassivable
    {
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        [MaxLength(4000)]
        public string DescriptionAr { get; set; }

        [Required]
        [MaxLength(4000)]
        public string DescriptionEn { get; set; }

        [Required]
        public decimal Rate { get; set; }

        public bool IsActive { get; set; }

        public bool IsLocalCurrency { get; set; }
    }
}
