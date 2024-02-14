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
using ERP._System.__SalesModule._IvSaleHd;

namespace ERP._System.__SalesModule._IvReturnSaleHd
{
   public class IvReturnSaleHd : PostAuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        public long IvSaleHdId { get; protected set; }

        [Required]
        [MaxLength(30)]
        public string IvReturnSaleNumber { get; protected set; }

        [Required]
        public long StatusLkpId { get; protected set; }

        [Required]
        public DateTime IvReturnSaleDate { get; protected set; }

        [MaxLength(4000)]
        public string Comments { get; protected set; }

        [Required]
        public int CurrencyId { get; protected set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal CurrencyRate { get; protected set; }


        [ForeignKey(nameof(IvSaleHdId))]
        public IvSaleHd IvSaleHd { get; set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupStatusLkp { get; protected set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; protected set; }

        public virtual ICollection<IvReturnSaleTr> IvReturnSaleTrs { get; protected set; }
        public int TenantId { get; set; }

    }
}
