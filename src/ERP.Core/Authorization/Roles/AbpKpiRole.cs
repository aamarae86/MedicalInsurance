using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP.Authorization.Roles
{
    public class AbpKpiRole : AuditedEntity<long>, IMustHaveTenant
    {
        public long KpiLkpId { get; set; }
        public long RoleId { get; set; }
        public int TenantId { get; set; }

        [ForeignKey(nameof(KpiLkpId)), Column(Order = 5)]
        public FndLookupValues FndKpisLkp { get; protected set; }
    }
}
