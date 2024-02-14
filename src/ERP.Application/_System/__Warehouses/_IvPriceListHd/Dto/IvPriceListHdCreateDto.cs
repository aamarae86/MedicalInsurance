using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ERP._System.__Warehouses._IvPriceListHd.Dto
{
    [AutoMap(typeof(IvPriceListHd))]
    public class IvPriceListHdCreateDto
    {
        [MaxLength(20)]
        public string PriceListNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string PriceListName { get; set; }
        public ICollection<IvPriceListTrDto> PriceListDetails { get; set; }
    }
}
