using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.Currencies.Dto
{
    [AutoMapFrom(typeof(Currency))]
    public class CreateCurrencyDto
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
