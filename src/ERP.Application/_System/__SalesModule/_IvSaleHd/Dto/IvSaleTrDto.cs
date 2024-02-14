using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__Warehouses.Dto;
using ERP._System._FndLookupValues;
using ERP._System._FndTaxType;
using ERP.Helpers.Core;
using ERP.Users.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SalesModule._IvSaleHd.Dto
{
    public class IvSaleTrDto : EntityDto<long>, IDetailRowStatus
    {

        [Required]
        public long IvSaleHdId { get; set; }

        [Required]
        public long IvItemId { get; set; }
        public string ItemName { get; set; }
        public IvItems IvItems { get; set; }

        [Required]
        public decimal Qty { get; set; }
        public decimal? totbeforetax { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public decimal TrCost { get; set; }
        public decimal? Total { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? Totalamount { get; set; }
       
        public decimal? TotalCost { get; set; }
        public decimal? LastCost { get; set; }
        public decimal? AvgCost { get; set; }
        public decimal? profit { get; set; }

        public decimal? profitamount { get; set; }
        public decimal? Avilablequantity { get; set; }
        public long? FndTaxtypeId { get; set; }

        public string UnitName { get; set; }
        [ForeignKey(nameof(FndTaxtypeId))]
        public FndTaxTypeDto FndTaxType { get; set; }
        public string ItemNumber { get; set; }
        public decimal? Discount { get;  set; }
        public string rowStatus { get; set; }
      
    }
}
