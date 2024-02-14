using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues;
using ERP._System._FndLookupValues.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ArCustomers.Dto
{
    [AutoMapFrom(typeof(ArCustomers))]
    public class ArCustomersDto : AuditedEntityDto<long>
    {
        public long SourceCodeLkpId { get; set; }

        public long? SourceId { get; set; }

        public FndLookupValues FndLookupValuesSource { get; set; }

        [Required]
        public int CustomerNumber { get; set; } = 1;

        [Required]
        [MaxLength(200)]
        public string CustomerNameAr { get; set; }

        [Required]
        [MaxLength(200)]
        public string CustomerNameEn { get; set; }

        [Required]
        public long StatusLkpId { get; set; }
        public string TaxNo { get; set; }

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

        public long? PaymentTermsLkpId { get; set; }

        //[ForeignKey(nameof(PaymentTermsLkpId))]
        public FndLookupValuesForeginDto FndPaymentTermsLkp { get; protected set; }

        public FndLookupValuesForeginDto FndLookupValues { get; set; }

        public FndLookupValuesForeginDto FndLookupValuesCustType { get; set; }
    }
}
