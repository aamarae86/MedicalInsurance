using ERP._System.__SalesModule._IvSaleHd.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.HR;
using ERP.ResourcePack.Sales;
using ERP.ResourcePack.Warehouses;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using ERP.Web.UI.Models.ViewModels.Warehouses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Web.UI.Models.ViewModels.Sales
{
    public class IvPosHdVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

      
        [MaxLength(30)]
        [Display(Name = nameof(IvSaleHd.IvSaleNumber), ResourceType = typeof(IvSaleHd))]
        public string IvSaleNumber { get; set; }
        public string Status { get; set;} 
        [Required]
        [Display(Name = nameof(IvSaleHd.StatusLkpId), ResourceType = typeof(IvSaleHd))]
        public long StatusLkpId { get; set; }

        public string StatusName { get; set; }
        public FndLookupValuesVM FndLookupStatusLkp { get; set; }

       
        [Display(Name = nameof(IvSaleHd.IvSaleDate), ResourceType = typeof(IvSaleHd))]
        public string IvSaleDate { get; set; }

        public string SaleDateToday { get; set; }
        
        [MaxLength(30)]
        [Display(Name = nameof(IvSaleHd.LpoNo), ResourceType = typeof(IvSaleHd))]
        public string LpoNo { get; set; }

        [Required]
        [Display(Name = nameof(IvSaleHd.IvPriceListHdId), ResourceType = typeof(IvSaleHd))]
        public long IvPriceListHdId { get; set; }

        public IvPriceListHdVM IvPriceListHd { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        [Required]
        [Display(Name = nameof(IvSaleHd.IvWarehouseId), ResourceType = typeof(IvSaleHd))]
        public long IvWarehouseId { get; set; }

        public string WarehouseName { get; set; }

        public IvWarehousesVM IvWarehouses { get; set; }

        [Required]
        [Display(Name = nameof(IvSaleHd.currency), ResourceType = typeof(IvSaleHd))]
        public int CurrencyId { get; set; }

        public CurrenciesVM Currency { get; set; }

        [Display(Name = nameof(IvSaleHd.FndSalesMenId), ResourceType = typeof(IvSaleHd))]
        public long FndSalesMenId { get; set; }

        public FndSalesMenVM FndSalesMen { get; set; }

        public bool IsCash { get; set; }

        [Required]
        [Display(Name = nameof(IvSaleHd.ArCustomerId), ResourceType = typeof(IvSaleHd))]
        public long ArCustomerId { get; set; }
        public string CustomerName { get; set; }
        public ArCustomersVM ArCustomers { get; set; }


        [Display(Name = nameof(IvSaleHd.PaymentMethod), ResourceType = typeof(IvSaleHd))]
        public long PaymentMethod { get; set; }
        public string SaleHdDetailsListStr { get; set; }

        public long? PaymentMethodLkpId { get;  set; }
        
        public FndLookupValuesVM FndLookupPaymentMethodLkp { get;  set; }

        public long? BankAccountId { get; set; }
        public ApBankAccountsVM ApBankAccounts { get; set; }

        public bool? IsPOS { get;  set; }
        public decimal DeliveryCharges { get; set; }
        public decimal Discount { get; set; }
        public ICollection<IvSaleTrDto> IvSaleTrdetails => string.IsNullOrEmpty(SaleHdDetailsListStr) ?
                new List<IvSaleTrDto>() : Helper<List<IvSaleTrDto>>.Convert(SaleHdDetailsListStr);

        public string PhoneNumber { get; set; }
        public string CreditCardRef { get; set; }


    }
}