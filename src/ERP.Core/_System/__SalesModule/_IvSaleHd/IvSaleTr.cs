using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__Warehouses._IvPriceListHd;
using ERP._System._FndLookupValues;
using ERP.Authorization.Users;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Currencies;
using ERP._System.__SalesModule._FndSalesMen;
using ERP._System._ArCustomers;
using ERP._System._FndTaxType;

namespace ERP._System.__SalesModule._IvSaleHd
{
    public class IvSaleTr : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        public long IvSaleHdId { get; protected set; }
        [ForeignKey(nameof(IvSaleHdId))]
        public IvSaleHd IvSaleHd { get; protected set; }

        [Required]
        public long IvItemId { get; protected set; }
        [ForeignKey(nameof(IvItemId))]
        public IvItems IvItems { get; protected set; }
     
        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Qty { get; protected set; }
        
        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal UnitPrice { get; protected set; }
       
        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal TrCost { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? TaxAmount { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Avilablequantity { get; protected set; }
        public long? FndTaxtypeId { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? AvgCost { get; protected set; }

        [ForeignKey(nameof(FndTaxtypeId))]
        public FndTaxType FndTaxType { get; set; }
        public decimal? Discount { get; protected set; }

        public int TenantId { get; set; }
    }
}
