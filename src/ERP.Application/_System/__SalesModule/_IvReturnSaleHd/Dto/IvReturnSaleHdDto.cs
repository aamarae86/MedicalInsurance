using Abp.AutoMapper;
using ERP._System.__SalesModule._FndSalesMen;
using ERP._System.__SalesModule._IvSaleHd;
using ERP._System.__Warehouses;
using ERP._System.__Warehouses._IvInventorySetting;
using ERP._System.__Warehouses._IvPriceListHd;
using ERP._System._ApBankAccounts;
using ERP._System._ApBankAccounts.Dto;
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
namespace ERP._System.__SalesModule._IvReturnSaleHd.Dto
{
    [AutoMap(typeof(IvReturnSaleHd))]
    public class IvReturnSaleHdDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        [Required]
        public long IvSaleHdId { get; set; }

        [MaxLength(30)]
        public string IvReturnSaleNumber { get; set; }


        public long StatusLkpId { get; set; }

        public FndLookupValues FndLookupStatusLkp { get; set; }

        [Required]
        public string IvReturnSaleDate { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        [Required]
        public decimal CurrencyRate { get; set; }
        public decimal ReturnCurrencyRate { get; set; }
        
        public Currency Currency { get; set; }
        public ArCustomers ArCustomers { get; set; }
        public IvWarehouses IvWarehouses { get; set; }
        public IvSaleHd IvSaleHd { get; set; }
        public ICollection<IvReturnSaleTrDto> IvReturnSaleTrdetails { get; set; }

        public decimal? Amount { get; set; }
        public long? PaymentMethodLkpId { get; set; }
        public FndLookupValues FndLookupPaymentMethodLkp { get; set; }
        public long? BankAccountId { get; set; }
        public ApBankAccounts ApBankAccounts { get; set; }

    }
}
