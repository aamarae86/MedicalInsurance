using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__Warehouses._IvInventorySetting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
namespace ERP._System._FndTaxType
{
    [AutoMap(typeof(FndTaxType))]
    public class FndTaxTypeCreateDto
    {
       
        [MaxLength(30)]
        public string TaxTypeNumber { get; set; }
        [MaxLength(200)]
        [Required]
        public string TaxNameAr { get; set; }
        [Required]
        [MaxLength(200)]
        public string TaxNameEn { get; set; }
        [Required]
        public decimal Percentage { get; set; }


    }
}
