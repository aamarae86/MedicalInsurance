using Abp.Application.Services.Dto;
using ERP._System._modules;
using ERP.MultiTenancy.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System._TenantFreeModules.Dto
{
    public class TenantFreeModulesDto  :EntityDto<long>
    {
        public long Tenant_ID { get; set; }

        public TenantDto Tenant { get; set; }

        public long Module_ID { get; set; }
 
        public ModuleDto Modules { get; set; }
        public List<ModuleDto> AppModules { get; set; }


    }
}
