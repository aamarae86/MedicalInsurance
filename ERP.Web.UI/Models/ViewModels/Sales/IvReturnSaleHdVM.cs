using ERP._System.__SalesModule._IvReturnSaleHd;
using ERP._System.__SalesModule._IvReturnSaleHd.Dto;
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
namespace ERP.Web.UI.Models.ViewModels.Sales
{
    public class IvReturnSaleHdVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Required]
        [Display(Name = nameof(ReturnSale.IvSaleHdId), ResourceType = typeof(ReturnSale))]
        public long IvSaleHdId { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(ReturnSale.IvReturnSaleNumber), ResourceType = typeof(ReturnSale))]
        public string IvReturnSaleNumber { get; set; }

        [Display(Name = nameof(ReturnSale.StatusLkpId), ResourceType = typeof(ReturnSale))]
        public string Status { get; set; }
        [Display(Name = nameof(ReturnSale.StatusLkpId), ResourceType = typeof(ReturnSale))]
        public long StatusLkpId { get; set; }

        public FndLookupValuesVM FndLookupStatusLkp { get; set; }

        [Required]
        [Display(Name = nameof(ReturnSale.IvReturnSaleDate), ResourceType = typeof(ReturnSale))]
        public string IvReturnSaleDate { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ReturnSale.Comments), ResourceType = typeof(ReturnSale))]
        public string Comments { get; set; }

        [Required]
        [Display(Name = nameof(ReturnSale.Currency), ResourceType = typeof(ReturnSale))]
        public int CurrencyId { get; set; }

        [Required]
        [Display(Name = nameof(ReturnSale.CurrencyRate), ResourceType = typeof(ReturnSale))]
        public decimal CurrencyRate { get; set; }
        public string ReturnCurrencyRate { get; set; }
        public CurrenciesVM Currency { get; set; }

        public IvSaleHdVM IvSaleHd { get; set; }
        public IvWarehousesVM IvWarehouses { get; set; }
      
        #region details 
        [Required]
        public long IvReturnSaleHdId { get; set; }
        [Required]
        [Display(Name = nameof(ReturnSale.RQty), ResourceType = typeof(ReturnSale))]
        public decimal RQty { get; set; }
        [Required]
        [Display(Name = nameof(ReturnSale.UnitPrice), ResourceType = typeof(ReturnSale))]
        public decimal UnitPrice { get; set; }
        [Required]
        public decimal TrCost { get; set; }
        [Display(Name = nameof(ReturnSale.TaxAmount), ResourceType = typeof(ReturnSale))]
        public decimal? TaxAmount { get; set; }
        [Display(Name = nameof(ReturnSale.Amount), ResourceType = typeof(ReturnSale))]
        public decimal? Amount { get; set; }
        public long? FndTaxtypeId { get; set; }
        public decimal? Percentage { get; set; }
        public FndTaxTypeVM FndTaxType { get; set; }
        [Display(Name = nameof(ReturnSale.Avilablequantity), ResourceType = typeof(ReturnSale))]
        public decimal? Avilablequantity { get; set; }
        [Display(Name = nameof(ReturnSale.IvItemId), ResourceType = typeof(ReturnSale))]
        public long IvItemId { get; set; }
        public long IvSaleTrId { get; set; }
        [Display(Name = nameof(ReturnSale.Totbeforetax), ResourceType = typeof(ReturnSale))]
        public decimal? Totbeforetax { get; set; }
        [Display(Name = nameof(ReturnSale.Total), ResourceType = typeof(ReturnSale))]
        public decimal? Total { get; set; }
     
        public FndLookupValuesVM FndTaxPercentageLookupValues { get; set; }

        #endregion
        [Display(Name = nameof(ReturnSale.IvWarehouseName), ResourceType = typeof(ReturnSale))]
        public string IvWarehouseName { get; set; }

        [Display(Name = nameof(ReturnSale.CustomerName), ResourceType = typeof(ReturnSale))]
        public string CustomerName { get; set; }
        [Display(Name = nameof(ReturnSale.CustomerNumber), ResourceType = typeof(ReturnSale))]
        public string CustomerNumber { get; set; }
        public ArCustomersVM ArCustomers { get; set; }
        public string ReturnSaleDetailsListStr { get; set; }
        public ICollection<IvReturnSaleTrDto> IvReturnSaleTrdetails => string.IsNullOrEmpty(ReturnSaleDetailsListStr) ?
                new List<IvReturnSaleTrDto>() : Helper<List<IvReturnSaleTrDto>>.Convert(ReturnSaleDetailsListStr);
        [Display(Name = nameof(ReturnSale.PaymentMethodLkpId), ResourceType = typeof(ReturnSale))]
        public long? PaymentMethodLkpId { get; set; }
        public FndLookupValuesVM FndLookupPaymentMethodLkp { get; set; }

        public long? BankAccountId { get; set; }

        public ApBankAccountsVM ApBankAccounts { get; set; }
        public string rowStatus { get; set; }
    }
}