using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues;
using ERP.Authorization.Roles;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Roles.Dto
{
    [AutoMap(typeof(AbpKpiRole))]
    public class AbpKpiRoleDto : AuditedEntityDto<long>
    {
        //[{"index":1,"kpiLkpId":"11580","kpi":"صافي الربح السنوي","roleId":"34","rowStatus":"New","id":0}]
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        public long KpiLkpId { get; set; }
        public string Kpi { get; set; }
        public long RoleId { get; set; }
        public int TenantId { get; set; }
        public FndLookupValues FndKpisLkp { get; set; }
        public string rowStatus { get; set; } = DetailRowStatus.RowStatus.NoAction.ToString();
    }

    [AutoMap(typeof(AbpKpiRole))]
    public class AbpKpiRoleCreateDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        public virtual ICollection<AbpKpiRoleDto> RoleKpi { get;  set; }
    }
}
