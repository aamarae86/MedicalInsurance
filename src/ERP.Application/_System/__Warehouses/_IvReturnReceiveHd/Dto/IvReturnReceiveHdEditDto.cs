using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvReturnReceiveHd.Dto
{
     public class IvReturnReceiveHdEditDto : EntityDto<long>
    {
        [Required]
        public long IvReceiveHdId { get; set; }
        [Required]
        [MaxLength(30)]
        public string IvReturnReceiveNumber { get; set; }

        [Required]
        public long StatusLkpId { get; set; }

        [Required]
        public string IvReturnReceiveDate { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }


        [Required]
        public int CurrencyId { get; set; }

        [Required]

        public decimal CurrencyRate { get; set; }
        public ICollection<IvReturnReceiveTrDto> IvReturnReceivedetails { get; set; }
    }
}
