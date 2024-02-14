using Abp.AutoMapper;
using ERP._System.__AccountModule._ApVendors.Dto;
using ERP._System.__Warehouses._PoPurchaseOrder.Dto;
using ERP._System.__Warehouses.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Currencies.Dto;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvReceiveHd.Dto
{
    [AutoMap(typeof(IvReceiveHd))]
    public class IvReceiveHdDto : PostAuditedEntityDto<long>
    {
        public string EncId => Core.Helpers.Core.CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string HdReceiveNumber { get; set; }

        public string HdReceiveDate { get; set; }

        public decimal CurrencyRate { get; set; }

        [MaxLength(4000)]
        public string Comment { get; set; }

        public long IvWarehouseId { get; set; }

        public long StatusLkpId { get; set; }

        public int CurrencyId { get; set; }

        public long VendorId { get; set; }

        //public long ReceiveTypeLkpId { get; set; }

        public long? PoPurchaseOrderHdId { get; set; }

        public IvWarehousesDto IvWarehouses { get; set; }

        public ApVendorsDto ApVendors { get; set; }

        public PoPurchaseOrderDto PoPurchaseOrderHd { get; set; }

        public CurrencyDto Currency { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public FndLookupValuesDto FndReceiveTypeLkp { get; set; }

        public ICollection<IvReceiveTrDto> IvReceiveDetails { get; set; }
        public ICollection<IvReceiveTrDto> IvReceiveTr { get; set; }
    }
}
