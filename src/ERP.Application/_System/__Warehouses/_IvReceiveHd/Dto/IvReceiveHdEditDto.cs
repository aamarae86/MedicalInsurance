using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvReceiveHd.Dto
{
    [AutoMap(typeof(IvReceiveHd))]
    public class IvReceiveHdEditDto : EntityDto<long>
    {
        public string HdReceiveDate { get; set; }

        public decimal CurrencyRate { get; set; }

        [MaxLength(4000)]
        public string Comment { get; set; }

        public long IvWarehouseId { get; set; }

        public int CurrencyId { get; set; }

        public long VendorId { get; set; }

        public ICollection<IvReceiveTrDto> IvReceiveDetails { get; set; }
    }
}
