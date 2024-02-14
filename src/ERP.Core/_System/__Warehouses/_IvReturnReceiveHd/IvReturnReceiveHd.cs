using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP._System.__Warehouses._IvReceiveHd;
using System;
using ERP.Currencies;

namespace ERP._System.__Warehouses._IvReturnReceiveHd
{
   public class IvReturnReceiveHd : PostAuditedEntity<long>, IMustHaveTenant
    {
       [Required]
        public long IvReceiveHdId { get; protected set; }
        [Required]
        [MaxLength(30)]
        public string IvReturnReceiveNumber { get; protected set; }
        [Required]
        public long StatusLkpId { get; protected set; }
        [Required]
        public DateTime IvReturnReceiveDate { get; protected set; }
        [MaxLength(4000)]
        public string Comments { get; protected set; }
        [Required]
        public int CurrencyId { get; protected set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal CurrencyRate { get; protected set; }


        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupStatusLkp { get; protected set; }

        [ForeignKey(nameof(IvReceiveHdId))]
        public IvReceiveHd IvReceiveHd { get; set; }
        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; protected set; }
        public virtual ICollection<IvReturnReceiveTr> IvReturnReceiveTrs { get; protected set; }
        public int TenantId { get; set; }
    }
}
