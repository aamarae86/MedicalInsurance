using ERP._System._modules;
using ERP._System._TenantFreeModules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._TenantFreeModules.Dto
{
 
    public class TenantModuleDto
    {
        public HostTenancyDto TenantInfo { get; set; }
        public List<ModuleDto> TenantModules { get; set; }
    }


   public class ModuleDto
    {
        public long ModuleId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Selector { get; set; }
        public bool IsFree { get; set; }
        public int TenantId { get; set; }
        public List<Page> Pages { get;  set; }

    }
}
