using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__SpGuarantees._SpBeneficent.Dto
{
    [AutoMapTo(typeof(SpBeneficent))]
    public class SpBeneficentCreateDto
    {
        //public int TenantId { get; set; }

        //[Required]
        [MaxLength(20)]
        public string BeneficentNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string BeneficentName { get; set; }

        [Required]
        public long FirstTitleLkpId { get; set; }

        public long? CityLkpId { get; set; }

        public long? GenderLkpId { get; set; }

        public long? NationalityLkpId { get; set; }

        [MaxLength(50)]
        public string MobileNumber1 { get; set; }

        [MaxLength(50)]
        public string MobileNumber2 { get; set; }

        public long? LastTitleLkpId { get; set; }

        [MaxLength(32)]
        public string Fax { get; set; }

        [MaxLength(256)]
        public string EmailAddress { get; set; }

        [MaxLength(100)]
        public string PoBox { get; set; }

        [MaxLength(200)]
        public string JobDescription { get; set; }

        [MaxLength(200)]
        public string Job { get; set; }

        [MaxLength(4000)]
        public string Address { get; set; }

        public virtual ICollection<SpBeneficentAttachmentsDto> ListOfAttachments { get; set; }

        public virtual ICollection<SpBeneficentBankEditDto> ListOfBanks { get; set; }
    }
}
