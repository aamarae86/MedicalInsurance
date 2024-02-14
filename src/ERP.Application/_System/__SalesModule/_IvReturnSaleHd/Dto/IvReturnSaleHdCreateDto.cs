using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__Warehouses._IvInventorySetting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__SalesModule._IvReturnSaleHd.Dto
{
    [AutoMap(typeof(IvReturnSaleHd))]
   public class IvReturnSaleHdCreateDto
    {

        [Required]
        public long IvSaleHdId { get;  set; }
    
        [MaxLength(30)]
        public string IvReturnSaleNumber { get;  set; }

        [Required]
        public long StatusLkpId => Convert.ToInt64(_FndLookupValues.Dto.FndEnum.FndLkps.New_IvReturnSaleHdStatus);


        [Required]
        public string IvReturnSaleDate { get;  set; }

        [MaxLength(4000)]
        public string Comments { get;  set; }

        [Required]
        public int CurrencyId { get; set; }

        [Required]
        public decimal CurrencyRate { get; set; }
        public decimal ReturnCurrencyRate { get; set; }

        public ICollection<IvReturnSaleTrDto> IvReturnSaleTrdetails { get; set; }















    }
}
