using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__Warehouses._IvItemsTypesConfigure.Dto;
using ERP._System.__Warehouses._IvUnits;
using ERP._System.__Warehouses._IvUnits.Dto;
using ERP._System.__Warehouses._IvWarehouseItems;
using ERP._System._FndLookupValues;
using ERP._System._FndTaxType;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvItems.Dto
{
    [AutoMap(typeof(IvItems))]
    public class IvItemsDto : AuditedEntityDto<long>
    {
        public long? IvItemsTypesConfigureId { get; set; }

        [MaxLength(20)]
        public string ItemNumber { get; set; }

        [MaxLength(200)]
        public string ItemName { get; set; }

        [MaxLength(50)]
        public string ItemBarcode { get; set; }

        [MaxLength(30)]
        public string ItemRef1 { get; set; }

        [MaxLength(30)]
        public string ItemRef2 { get; set; }

        public long? IvUnitId { get; set; }

        public decimal? ItemOrdQty { get; set; }

        public decimal? ItemMaxStk { get; set; }

        public decimal? ItemMinStk { get; set; }

        public decimal? ItemQtys { get; set; }

        public decimal? AvgCost { get; set; }

        public decimal? LastCost { get; set; }

        public bool? IsItemObsolete { get; set; }

        public DateTime? ObsoleteDate { get; set; }

        public decimal? CurrentOnHand { get; set; }
        public bool? IsDonationItem { get; set; }
        public long? TaxPercentageLkpId { get; set; }
        public long? FndTaxtypeId { get;  set; }
        public decimal? price { get; set; }
        public decimal? Percentage { get; set; }

        public decimal? Avilablequantity { get; set; }
        public string UnitName { get; set; }
        public decimal? UnitPrice { get; set; }
        public IvItemsTypesConfigureDto IvItemsTypesConfigure { get; set; }

        public FndTaxTypeDto FndTaxType { get;  set; }
        //public IvWarehouseItemsDto IvWarehouseItems { get; set; }
        public IvUnitsDto IvUnits { get; set; }
        public FndLookupValues FndLookupValues { get;  set; }
    }
}
