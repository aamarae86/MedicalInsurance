using Abp.AutoMapper;
using ERP._System.__SalesModule._FndSalesMen;
using ERP._System.__SalesModule._IvSaleHd;
using ERP._System.__Warehouses;
using ERP._System.__Warehouses._IvInventorySetting;
using ERP._System.__Warehouses._IvPriceListHd;
using ERP._System.__Warehouses._IvReceiveHd;
using ERP._System._ArCustomers;
using ERP._System._FndLookupValues;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Core;
using ERP.Currencies;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ERP._System.__Warehouses._IvReturnReceiveHd.Dto
{
    [AutoMap(typeof(IvReturnReceiveHd))]
    public class IvReturnReceiveHdDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

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

        public decimal ReturnCurrencyRate { get; set; }
        public IvReceiveHd IvReceiveHd { get; set; }
        public IvWarehouses IvWarehouses { get; set; }

        public Currency Currency { get; set; }
        public FndLookupValues FndLookupStatusLkp { get; set; }
        public ICollection<IvReturnReceiveTrDto> IvReturnReceivedetails { get; set; }

        public decimal Amount { get; set; }
        


    }
}
