using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__SalesModule._IvReturnSaleHd.Dto
{
    [AutoMap(typeof(IvReturnSaleHd))]
    public class IvReturnSaleHdEditDto : EntityDto<long>
    {

        [Required]
        public long IvSaleHdId { get;  set; }

        [Required]
        [MaxLength(30)]
        public string IvReturnSaleNumber { get;  set; }

        [Required]
        public long StatusLkpId { get;  set; }

        [Required]
        public string IvReturnSaleDate { get;  set; }

        [MaxLength(4000)]
        public string Comments { get;  set; }

        [Required]
        public int CurrencyId { get;  set; }

        [Required]
        
        public decimal CurrencyRate { get;  set; }

        public virtual ICollection<IvReturnSaleTrDto> IvReturnSaleTrdetails { get;  set; }
      




    }
}
