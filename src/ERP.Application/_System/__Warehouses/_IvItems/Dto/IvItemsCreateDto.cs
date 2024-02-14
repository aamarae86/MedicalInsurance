using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__Warehouses._IvItems.Dto
{
    [AutoMap(typeof(IvItems))]
    public class IvItemsCreateDto
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
        public long? FndTaxtypeId { get;  set; }
        public long? TaxPercentageLkpId { get; set; }
        public bool? IsDonationItem { get; set; }
    }
}
