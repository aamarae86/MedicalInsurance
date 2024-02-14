using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._FndTaxType
{
    [AutoMap(typeof(FndTaxType))]
    public class FndTaxTypeEditDto : EntityDto<long>
    {
        [MaxLength(30)]
        public string TaxTypeNumber { get; set; }
        [MaxLength(200)]
        public string TaxNameAr { get; set; }
        [MaxLength(200)]
        public string TaxNameEn { get; set; }
        public decimal Percentage { get; set; }
    }
}
