using Abp.Application.Services.Dto;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Web.UI.Models.ViewModels.Tenant
{
    public class CreateTenantVM : EntityDto<int>
    {
        [Required]
        
        public string TenancyName { get; set; }

        [Required]
        [Display(Name = nameof(@ERP.ResourcePack.Common.Settings.UsrName), ResourceType = typeof(Settings))]
        public string Name { get; set; }

        [Required]
        [Display(Name = nameof(ReportsAccounts.FullName), ResourceType = typeof(ReportsAccounts))]
        public string FullName { get; set; }

        [Required]
        [Display(Name = nameof(ReportsAccounts.Email), ResourceType = typeof(ReportsAccounts))]
        public string AdminEmailAddress { get; set; }

        [Required]
        [Display(Name = nameof(ReportsAccounts.MobileNo), ResourceType = typeof(ReportsAccounts))]
        public string MobileNo { get; set; }

       
        public string ConnectionString { get; set; }

        [Required]
        [Display(Name = nameof(ReportsAccounts.Country), ResourceType = typeof(ReportsAccounts))]
        public long CountryLkpId { get; set; }

        [Required]
        [Display(Name = nameof(ReportsAccounts.Industry), ResourceType = typeof(ReportsAccounts))]
        public long IndustryLkpId { get; set; }

        public bool IsActive { get; set; }
        public string Baseurl { get; set; }
    }
}
