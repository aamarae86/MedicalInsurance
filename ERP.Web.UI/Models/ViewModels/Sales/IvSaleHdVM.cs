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
    public class IvSaleHdVM : BasePostAuditedVM<long>
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

        [Required]
        [Display(Name = nameof(IvSaleHd.CurrencyRate), ResourceType = typeof(IvSaleHd))]
        public decimal CurrencyRate { get; set; }
        public string CustomerCurrencyRate { get; set; }
        [Display(Name = nameof(IvSaleHd.FndSalesMenId), ResourceType = typeof(IvSaleHd))]
        public long FndSalesMenId { get; set; }

        public FndSalesMenVM FndSalesMen { get; set; }
        [Display(Name = nameof(IvSaleHd.FndSalesMenId), ResourceType = typeof(IvSaleHd))]
        public long? SearchFndSalesMenId { get; set; }
        [Required]
        public bool IsCash { get; set; }

        [Required]
        [Display(Name = nameof(IvSaleHd.ArCustomerId), ResourceType = typeof(IvSaleHd))]
        public long ArCustomerId { get; set; }
        public string CustomerName { get; set; }
        public ArCustomersVM ArCustomers { get; set; }

        [Display(Name = nameof(IvSaleHd.Amount), ResourceType = typeof(IvSaleHd))]
        public decimal? Amount { get; set; }
        [Display(Name = nameof(IvSaleHd.Phone), ResourceType = typeof(IvSaleHd))]
        public string Phone { get; set; }
        [Display(Name = nameof(IvSaleHd.Mobile), ResourceType = typeof(IvSaleHd))]
        public string Mobile { get; set; }
        [Display(Name = nameof(IvSaleHd.Outstanding), ResourceType = typeof(IvSaleHd))]
        public string Outstanding { get; set; }
        [Display(Name = nameof(IvSaleHd.Limit), ResourceType = typeof(IvSaleHd))]
        public string Limit { get; set; }
        #region details

        //public IvSaleHd IvSaleHd { get; set; }
        [Display(Name = nameof(IvItems.ItemBarcode), ResourceType = typeof(IvItems))]
        [MaxLength(50)]
        public string ItemBarcode { get; set; }
        [Required]
        [Display(Name = nameof(IvSaleHd.Itemname), ResourceType = typeof(IvSaleHd))]
        public long IvItemId { get; set; }

        public string IvItemName { get; set; }
        public IvItems IvItems { get; set; }

        [Required]
        [Display(Name = nameof(IvSaleHd.Qtys), ResourceType = typeof(IvSaleHd))]
        public decimal Qty { get; set; }

        [Required]
        [Display(Name = nameof(IvSaleHd.Unitprice), ResourceType = typeof(IvSaleHd))]
        public decimal UnitPrice { get; set; }
        [Required]
        [Display(Name = nameof(IvSaleHd.TrCost), ResourceType = typeof(IvSaleHd))]
        public decimal TrCost { get; set; }
        [Display(Name = nameof(IvSaleHd.Taxamount), ResourceType = typeof(IvSaleHd))]
        public decimal? TaxAmount { get; set; }
        [Display(Name = nameof(IvSaleHd.totbeforetax), ResourceType = typeof(IvSaleHd))]
        public decimal? Totbeforetax { get; set; }
        [Display(Name = nameof(IvSaleHd.Avilablequantity), ResourceType = typeof(IvSaleHd))]
        public decimal? Avilablequantity { get; set; }
        public decimal? Total { get; set; }
        public decimal? Percentage { get; set; }
        public long? FndTaxtypeId { get; set; }
        public FndTaxTypeVM FndTaxType { get; set; }

        public string rowStatus { get; set; }








        #endregion

        [Display(Name = nameof(IvSaleHd.PaymentMethod), ResourceType = typeof(IvSaleHd))]
        public long PaymentMethod { get; set; }
        public string SaleHdDetailsListStr { get; set; }

        public long? PaymentMethodLkpId { get;  set; }
        
        public FndLookupValuesVM FndLookupPaymentMethodLkp { get;  set; }

        public long? BankAccountId { get; set; }
        public ApBankAccountsVM ApBankAccounts { get; set; }

        public long? BankId { get; set; }

        public ApBanksVM BanksVM { get; set; }

        public bool? IsPOS { get;  set; }
        public decimal? DeliveryCharges { get;  set; }
        public decimal? Discount { get;  set; }
        public ICollection<IvSaleTrDto> IvSaleTrdetails => string.IsNullOrEmpty(SaleHdDetailsListStr) ?
                new List<IvSaleTrDto>() : Helper<List<IvSaleTrDto>>.Convert(SaleHdDetailsListStr);

        public ICollection<IvSaleTrDto> IvSaleTrList { get; set; }
        public string PhoneNumber { get; set; }
        public decimal? Profit { get; set; }
        public decimal? ProfitPercentage { get; set; }
        public decimal? TotalCost { get; set; }
        public string BankName { get; set; }
        public string CreditCardRef { get; set; }

    }
}