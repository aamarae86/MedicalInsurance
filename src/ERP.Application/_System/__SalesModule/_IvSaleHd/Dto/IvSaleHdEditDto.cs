using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__SalesModule._IvSaleHd.Dto
{
    [AutoMap(typeof(IvSaleHd))]
    public class IvSaleHdEditDto : EntityDto<long>
    {

        public string IvSaleDate { get; set; }

        [MaxLength(30)]
        public string LpoNo { get; set; }


        public long IvPriceListHdId { get; set; }
        [MaxLength(4000)]
        public string Comments { get; set; }


        public long IvWarehouseId { get; set; }


        public int CurrencyId { get; set; }


        public decimal CurrencyRate { get; set; }

        public long? FndSalesMenId { get; set; }


        public bool IsCash { get; set; }


        public long ArCustomerId { get; set; }

        public decimal? DeliveryCharges { get; set; }
        public decimal? Discount { get; set; }

        //public ICollection<IvSaleTrDto> IvSaleTrdetails { get; set; }
        public ICollection<IvSaleTrDto> IvSaleTrDetails { get; set; }
        public string PhoneNumber { get; set; }
        public string CreditCardRef { get;  set; }
    }
}
