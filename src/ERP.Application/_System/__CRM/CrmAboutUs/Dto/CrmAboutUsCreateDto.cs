using Abp.AutoMapper;
using ERP._System.__CRM.AboutUs;
using ERP._System.__CRM.AboutUs.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CRM._CrmAboutUs.Dto
{
    [AutoMap(typeof(CrmAboutUs))]
    public class CrmAboutUsCreateDto
    {
        [StringLength(200)]
        [Required]
        public string HeaderNameAr { get; set; }

        [StringLength(200)]
        [Required]
        public string HeaderNameEN { get; set; }

        [StringLength(4000)]
        public string ContentAr { get; set; }
        [StringLength(4000)]
        public string ContentEn { get; set; }
        [StringLength(4000)]
        public string AboutUsFilepath { get; set; }

        public ICollection<AboutUSSliderDto> AboutUSSliderDtoList { get; set; }

    }
}
