using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__Warehouses._IvInventorySetting;
using ERP._System.__Warehouses._IvReceiveHd;
using ERP.Currencies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvReturnReceiveHd.Dto
{
    [AutoMap(typeof(IvReturnReceiveHd))]
    public class IvReturnReceiveHdCreateDto
    {

        [Required]
        public long IvReceiveHdId { get;  set; }
   
        [MaxLength(30)]
        public string IvReturnReceiveNumber { get;  set; }

        [Required]
        public long StatusLkpId => Convert.ToInt64(_FndLookupValues.Dto.FndEnum.FndLkps.New_IvReturnReceiveHdStatus);

        [Required]
        public string IvReturnReceiveDate { get;  set; }

        [MaxLength(4000)]
        public string Comments { get;  set; }


        [Required]
        public int CurrencyId { get;  set; }

        [Required]
      
        public decimal CurrencyRate { get;  set; }
        public decimal ReturnCurrencyRate { get; set; }
        public Currency Currency { get; set; }
        public IvReceiveHd IvReceiveHd { get; set; }
        public ICollection<IvReturnReceiveTrDto> IvReturnReceivedetails { get; set; }

    }
}
