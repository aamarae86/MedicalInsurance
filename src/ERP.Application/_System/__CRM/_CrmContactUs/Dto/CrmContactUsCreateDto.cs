using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CRM._CrmContactUs.Dto
{
    [AutoMap(typeof(CrmContactUs))]
    public class CrmContactUsCreateDto
    {
        [Required]
        [MaxLength(200)]
        public string HeaderNameAr { get; set; }

        [Required]
        [MaxLength(200)]
        public string HeaderNameEn { get; set; }

        [Required]
        [MaxLength(4000)]
        public string ContentAr { get; set; }

        [Required]
        [MaxLength(4000)]
        public string ContentEn { get; set; }

        [MaxLength(50)]
        public string Phone1 { get; set; }

        [MaxLength(50)]
        public string Phone2 { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }

        [MaxLength(30)]
        public string WorkingHours { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(4000)]
        public string FilePath { get; set; }

        [MaxLength(4000)]
        public string Address { get; set; }
    }
}
