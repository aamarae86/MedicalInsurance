using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__Warehouses._IvInventorySetting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__SalesModule._IvSaleHd.Dto
{
    [AutoMap(typeof(IvSaleHd))]
    public class IvSaleHdCreateDto
    {
        [MaxLength(30)]
        public string IvSaleNumber { get; set; }

        [Required]
        public long StatusLkpId => Convert.ToInt64(_FndLookupValues.Dto.FndEnum.FndLkps.New_IvSaleHdStatus);


        public string IvSaleDate { get; set; }

        public string saledateToday { get; set; }
        

        [MaxLength(30)]
        public string LpoNo { get; set; }

        [Required]
        public long IvPriceListHdId { get; set; }
        [MaxLength(4000)]
        public string Comments { get; set; }

        [Required]
        public long IvWarehouseId { get; set; }

        [Required]
        public int CurrencyId { get; set; }
        [Required]

        public decimal CurrencyRate { get; set; }

        public decimal? CustomerCurrencyRate { get; set; }

        public long? FndSalesMenId { get; set; }

        [Required]
        public bool IsCash { get; set; }

        [Required]
        public long ArCustomerId { get; set; }

        public long? PaymentMethodLkpId { get; set; }
        public long? BankAccountId { get; set; }

        public decimal? DeliveryCharges { get; set; }
        public decimal? Discount { get; set; }
        public bool? IsPOS { get; set; }
        public string PhoneNumber { get;  set; }
        public ICollection<IvSaleTrDto> IvSaleTrdetails { get; set; }
        public string CreditCardRef { get; set; }
    }
}
