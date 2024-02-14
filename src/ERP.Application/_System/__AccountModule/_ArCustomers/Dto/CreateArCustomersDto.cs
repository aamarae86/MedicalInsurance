using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System._ArCustomers.Dto
{
    [AutoMapFrom(typeof(ArCustomers))]
    public class CreateArCustomersDto
    {
        public long SourceCodeLkpId { get; set; } = Convert.ToInt64(FndEnum.FndLkps.Manual_ArCustomersSource);
        public long SourceId { get; set; } = 0;
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
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? CreditLimit { get; set; }
        public string TaxNo { get; set; }

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

        public string Lang { get; set; }
    }
}
