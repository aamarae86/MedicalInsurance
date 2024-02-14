using ERP._System._TenantFreeModules.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Tenant
{

    public class TenantModuleVM
    {
        public HostTenancyDto TenantInfo { get; set; }
        public List<ModuleVM> TenantModules { get; set; }
    }

    public class ModuleVM 
    {
        public long ModuleId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Selector { get; set; }
        public bool IsFree { get; set; }
        public int TenantId { get; set; }
    }
}