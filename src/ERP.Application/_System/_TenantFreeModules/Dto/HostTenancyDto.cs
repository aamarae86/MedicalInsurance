using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._TenantFreeModules.Dto
{
   public class HostTenancyDto
    {
        public int Id { get; set; }
        public string CreationTime { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get;  set; }
        public string FullName { get; set; }
        public string Tel { get; set; }
        public string TenantNameAr { get; set; }
        public string TenantNameEn { get; set; }
        public string WebSite { get; set; }
        public string RepManagerName { get; set; }
        public string ManagerName { get; set; }
        public string LogoPath { get; set; }
        public string Fax { get; set; }
        public string BoxNo { get; set; }
        public string BaseCurrency { get; set; }
        public long CountryLkpId { get; set; }
        public long IndustryLkpId { get; set; }
        public long TenantDetailId { get; set; }


        public string AdminSubEndDate { get; set; }
        public string RemainingDays { get; set; }
        public decimal AdminValue { get; set; }
        public decimal UserValue { get; set; }


    }
}
