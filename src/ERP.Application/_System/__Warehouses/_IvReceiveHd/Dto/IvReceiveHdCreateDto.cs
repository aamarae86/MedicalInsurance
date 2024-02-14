using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvReceiveHd.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(IvReceiveHd))]
    public class IvReceiveHdCreateDto
    {
        [MaxLength(30)]
        public string HdReceiveNumber { get; set; }

        public string HdReceiveDate { get; set; }

        public decimal CurrencyRate { get; set; }

        [MaxLength(4000)]
        public string Comment { get; set; }

        public long IvWarehouseId { get; set; }

        public long StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_IvReceiveHd);

        public int CurrencyId { get; set; }

        public long VendorId { get; set; }

        //public long ReceiveTypeLkpId { get; set; }

        public long? PoPurchaseOrderHdId { get; set; }

        public ICollection<IvReceiveTrDto> IvReceiveDetails { get; set; }
    }
}
