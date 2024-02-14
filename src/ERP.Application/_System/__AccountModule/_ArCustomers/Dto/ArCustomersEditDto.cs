using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ArCustomers.Dto
{
    [AutoMapFrom(typeof(ArCustomers))]
    public class ArCustomersEditDto : EntityDto<long>
    {
        [Required]
        [MaxLength(200)]
        public string CustomerNameAr { get; set; }

        [Required]
        [MaxLength(200)]
        public string CustomerNameEn { get; set; }

        [Required]
        public long StatusLkpId { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? CreditLimit { get; set; }

        [Required]
        public long CustomerTypeLkpId { get; set; }

        [MaxLength(4000)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string HomeTel { get; set; }

        [MaxLength(50)]
        public string WorkTel { get; set; }

        [MaxLength(50)]
        public string Mobile { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Website { get; set; }
        public string TaxNo { get; set; }

        public long? PaymentTermsLkpId { get; set; }

    }
}
