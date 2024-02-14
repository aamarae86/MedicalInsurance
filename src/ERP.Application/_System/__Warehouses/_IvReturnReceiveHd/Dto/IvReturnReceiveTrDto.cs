using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__SalesModule._IvSaleHd;
using ERP._System.__SalesModule._IvSaleHd.Dto;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__Warehouses._IvReceiveHd.Dto;
using ERP._System.__Warehouses.Dto;
using ERP._System._FndLookupValues;
using ERP._System._FndTaxType;
using ERP.Helpers.Core;
using ERP.Users.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._IvReturnReceiveHd.Dto
{
   public class IvReturnReceiveTrDto : EntityDto<long>, IDetailRowStatus
    {

        [Required]
        public long IvReturnReceiveHdId { get;  set; }
        [Required]
        public long IvReceiveTrId { get;  set; }
        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal RQty { get;  set; }
        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal UnitPrice { get;  set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? TaxAmount { get;  set; }
        public decimal? AvailableQty { get; set; }
        public decimal? Percentage { get; set; }

        public long? FndTaxtypeId { get;  set; }


        [ForeignKey(nameof(FndTaxtypeId))]
        public FndTaxTypeDto FndTaxType { get;  set; }

        [ForeignKey(nameof(IvReturnReceiveHdId))]
        public IvReturnReceiveHd IvReturnReceiveHd { get;  set; }

        [ForeignKey(nameof(IvReceiveTrId))]
        public IvReceiveTrDto IvReceiveTr { get;  set; }

        public string ItemName { get; set; }
        public long IvItemId { get; set; }

        public decimal? totbeforetax { get; set; }

        public decimal? Totalamount { get; set; }



        public string rowStatus { get; set; }
    }
}
