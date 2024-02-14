using Abp.Application.Services.Dto;
using ERP.ResourcePack.Accounts;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Tenant
{
    public class TenantDetailEditVM : EntityDto<int>
    {
        public int TenantId { get; set; }

        public string LogoPath { get; set; }

        public string LogoPathBase64 { get; set; }

        public string LogoPathExt { get; set; }

        [Display(Name = nameof(ReportsAccounts.TenantNameAr), ResourceType = typeof(ReportsAccounts))]
        public string TenantNameAr { get; set; }

        [Display(Name = nameof(ReportsAccounts.TenantNameEn), ResourceType = typeof(ReportsAccounts))]
        public string TenantNameEn { get; set; }

        [Display(Name = nameof(ReportsAccounts.BoxNo), ResourceType = typeof(ReportsAccounts))]
        public string BoxNo { get; set; }

        [Display(Name = nameof(ReportsAccounts.Tel), ResourceType = typeof(ReportsAccounts))]
        public string Tel { get; set; }

        [Display(Name = nameof(ReportsAccounts.Fax), ResourceType = typeof(ReportsAccounts))]
        public string Fax { get; set; }

        [Display(Name = nameof(ReportsAccounts.Email), ResourceType = typeof(ReportsAccounts))]
        public string Email { get; set; }
        [Display(Name = nameof(ReportsAccounts.MobileNo), ResourceType = typeof(ReportsAccounts))]
        public string MobileNo { get; set; }
        [Display(Name = nameof(ReportsAccounts.FullName), ResourceType = typeof(ReportsAccounts))]

        public string FullName { get; set; }

        [Display(Name = nameof(ReportsAccounts.WebSite), ResourceType = typeof(ReportsAccounts))]
        public string WebSite { get; set; }

        [Display(Name = nameof(ReportsAccounts.ManagerName), ResourceType = typeof(ReportsAccounts))]
        public string ManagerName { get; set; }

        [Display(Name = nameof(ReportsAccounts.RepManagerName), ResourceType = typeof(ReportsAccounts))]
        public string RepManagerName { get; set; }
        [Display(Name = nameof(ReportsAccounts.Country), ResourceType = typeof(ReportsAccounts))]
        public string CountryAr { get;  set; }
        [Display(Name = nameof(ReportsAccounts.Country), ResourceType = typeof(ReportsAccounts))]
        public string CountryEn { get;  set; }
        [Display(Name = nameof(ReportsAccounts.Industry), ResourceType = typeof(ReportsAccounts))]
        public string IndustryAr { get;  set; }
        [Display(Name = nameof(ReportsAccounts.Industry), ResourceType = typeof(ReportsAccounts))]
        public string IndustryEn { get;  set; }
        [Display(Name = nameof(ReportsAccounts.Currency), ResourceType = typeof(ReportsAccounts))]
        public string CurrencyAr { get;  set; }
        [Display(Name = nameof(ReportsAccounts.Currency), ResourceType = typeof(ReportsAccounts))]
        public string CurrencyEn { get;  set; }
        [Display(Name = nameof(ReportsAccounts.CurrencyCode), ResourceType = typeof(ReportsAccounts))]
        public string CurrencyCode { get;  set; }
        [Display(Name = nameof(ReportsAccounts.BaseCurrency), ResourceType = typeof(ReportsAccounts))]
        public int CurrencyId { get; set; }
        
        [Display(Name = nameof(ReportsAccounts.CreationTime), ResourceType = typeof(ReportsAccounts))]
        public string CreationTime { get; set; }
        
        public int? BaseCurrency { get; set; }
        public string StripePublishablekey { get; set; }

        [Display(Name = nameof(ReportsAccounts.Name), ResourceType = typeof(ReportsAccounts))]

        public string Name { get; set; }

        [Display(Name = nameof(ReportsAccounts.Name), ResourceType = typeof(ReportsAccounts))]

        public string TenancyName { get; set; }


        [Display(Name = nameof(ReportsAccounts.EnterData), ResourceType = typeof(ReportsAccounts))]
        public string AdminSubEndDate { get; set; }

        [Display(Name = nameof(ReportsAccounts.AdminValue), ResourceType = typeof(ReportsAccounts))]
        public decimal? AdminValue { get; set; }

        [Display(Name = nameof(ReportsAccounts.UserValue), ResourceType = typeof(ReportsAccounts))]
        public decimal? UserValue { get; set; }

        [Display(Name = nameof(ReportsAccounts.RemainingDays), ResourceType = typeof(ReportsAccounts))]
        public string RemainingDays { get; set; }
        public string Filepath { get; set; }

        [Display(Name = nameof(ReportsAccounts.TaxRegNum), ResourceType = typeof(ReportsAccounts))]
        public string TaxRegNo { get; set; }
    }
}