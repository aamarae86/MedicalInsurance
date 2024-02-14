using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__Warehouses._IvItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__Warehouses._IvUnits
{
    public class IvUnits : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(20)]
        public string UnitCode { get; protected set; }
        [MaxLength(200)]
        public string UnitName { get; protected set; }
        public int TenantId { get; set; }

        public virtual ICollection<IvItems> IvItems { get; protected set; }
        public virtual ICollection<_IvReceiveHd._IvReceiveTr.IvReceiveTr> IvReceiveTr { get; protected set; }

    }
}
