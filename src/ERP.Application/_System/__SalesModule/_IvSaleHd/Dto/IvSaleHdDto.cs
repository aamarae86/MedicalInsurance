using Abp.AutoMapper;
using ERP._System.__SalesModule._FndSalesMen;
using ERP._System.__Warehouses;
using ERP._System.__Warehouses._IvInventorySetting;
using ERP._System.__Warehouses._IvPriceListHd;
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


namespace ERP._System.__SalesModule._IvSaleHd.Dto
{
    [AutoMap(typeof(IvSaleHd))]
    public class IvSaleHdDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string IvSaleNumber { get; set; }

        public long StatusLkpId { get; set; }

        public FndLookupValues FndLookupStatusLkp { get; set; }

        [Required]
        public string IvSaleDate { get; set; }

        [MaxLength(30)]
        public string LpoNo { get; set; }

        [Required]
        public long IvPriceListHdId { get; set; }

        public IvPriceListHd IvPriceListHd { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }


        public long IvWarehouseId { get; set; }

        public IvWarehouses IvWarehouses { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        public Currency Currency { get; set; }

        [Required]

        public decimal CurrencyRate { get; set; }

        public long? FndSalesMenId { get; set; }

        public FndSalesMen FndSalesMen { get; set; }

        [Required]
        public bool IsCash { get; set; }

        [Required]
        public long ArCustomerId { get; set; }

        public ArCustomers ArCustomers { get; set; }

        //public decimal? Amount { get; set; }
        public ICollection<IvSaleTrDto> IvSaleTrDetails { get; set; }
        public ICollection<IvSaleTrDto> IvSaleTrList { get; set; }

        public long? PaymentMethodLkpId { get;  set; }
        
        public FndLookupValues FndLookupPaymentMethodLkp { get;  set; }

        public long? BankAccountId { get; set; }
        public ApBankAccountsDto ApBankAccounts { get; set; }
        public decimal? DeliveryCharges { get; set; }
        public decimal? Discount { get; set; }
        public bool? IsPOS { get;  set; }
        public decimal? Amount { get; set; }
        public string PhoneNumber { get; set; }


        //
        public decimal? Profit { get; set; }
        public decimal? ProfitPercentage { get; set; }
        public decimal? TotalCost { get; set; }
        public string BankName { get; set; }
        public string CreditCardRef { get; set; }
    }
}
