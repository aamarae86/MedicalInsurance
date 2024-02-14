using ERP._System.__SalesModule._IvReturnSaleHd;
using ERP._System.__SalesModule._IvReturnSaleHd.Dto;
using ERP._System.__SalesModule._IvSaleHd.Dto;
using ERP._System.__Warehouses._IvReturnReceiveHd;
using ERP._System.__Warehouses._IvReturnReceiveHd.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.HR;
using ERP.ResourcePack.Warehouses;

using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using ERP.Web.UI.Models.ViewModels.Warehouses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Warehouses
{
    public class IvReturnReceiveHdVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Required]
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.IvReceiveHdId), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public long IvReceiveHdId { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.IvReturnReceiveNumber), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public string IvReturnReceiveNumber { get; set; }

        [Required]
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.StatusLkpId), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public long StatusLkpId { get; set; }
        public FndLookupValuesVM FndLookupStatusLkp { get; set; }
        [Required]
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.IvReturnReceiveDate), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public string IvReturnReceiveDate { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.Comments), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public string Comments { get; set; }

        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.StatusLkpId), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public string Status { get; set;} 
        [Required]
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.Currency), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public int CurrencyId { get; set; }

        [Required]
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.CurrencyRate), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public decimal CurrencyRate { get; set; }
        public string ReturnCurrencyRate { get; set; }
        public CurrenciesVM Currency { get; set; }
        public IvReceiveHdVM IvReceiveHd { get; set; }

        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.VendorNumber), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public string VendorNumber { get; set; }

        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.VendorName), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public string VendorName { get; set; }

        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.IvWarehouseName), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public string IvWarehouseName { get; set; }
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.Itemcode), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public long IvItemId { get; set; }

        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.Avilablequantity), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public decimal? Avilablequantity { get; set; }
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.totbeforetax), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public decimal? Totbeforetax { get; set; }
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.Totalamount), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public decimal? Total { get; set; }
        

        #region details
        [Required]
        public long IvReturnReceiveHdId { get;  set; }
        public long IvReceiveTrId { get; set; }
        [Required]
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.Qtys), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public decimal RQty { get; set; }
        [Required]
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.Unitprice), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public decimal UnitPrice { get; set; }
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.Taxamount), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public decimal? TaxAmount { get; set; }
        public decimal? Percentage { get; set; }
        public long? FndTaxtypeId { get; set; }
        [Display(Name = nameof(ResourcePack.Warehouses.IvReturnReceiveHd.Amount), ResourceType = typeof(ResourcePack.Warehouses.IvReturnReceiveHd))]
        public decimal? Amount { get; set; }

        public FndLookupValuesVM FndTaxPercentageLookupValues { get; set; }
        public IvReturnReceiveHdVM IvReturnReceiveHd { get;set; }

        #endregion
       

        public string ReturnReceiveDetailsListStr { get; set; }
        public ICollection<IvReturnReceiveTrDto> IvReturnReceivedetails => string.IsNullOrEmpty(ReturnReceiveDetailsListStr) ?
                new List<IvReturnReceiveTrDto>() : Helper<List<IvReturnReceiveTrDto>>.Convert(ReturnReceiveDetailsListStr);
        public string rowStatus { get; set; }
    }
}