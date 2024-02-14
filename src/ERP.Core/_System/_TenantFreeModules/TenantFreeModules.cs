using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.MultiTenancy;
using ERP._System._modules;
using ERP.MultiTenancy;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._TenantFreeModules
{
    public class TenantFreeModules : AuditedEntity<long> 
    {

        public int Tenant_ID { get;  set; }
        [ForeignKey(nameof(Tenant_ID))]
        public Tenant Tenant { get; private set; }

        public int Module_ID { get;  set; }
        [ForeignKey(nameof(Module_ID))]
        public Module Modules { get; private set; }
         
    }
}
