using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP.MultiTenancy.Dto
{
    [AutoMap(typeof(Tenant))]
    public class TenantDetailEditDto : EntityDto<int>
    {
        public int TenantId { get; set; }

        public string LogoPath { get; set; }

        public string LogoPathBase64 { get; set; }

        public string LogoPathExt { get; set; }

        public string TenantNameAr { get; set; }

        public string TenantNameEn { get; set; }

        public string BoxNo { get; set; }

        public string Tel { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }

        public string ManagerName { get;  set; }

        public string RepManagerName { get;  set; }

        public string CountryAr { get; set; }
        public string CountryEn { get; set; }
        public string IndustryAr { get; set; }
        public string IndustryEn { get; set; }
        public string CurrencyAr { get; set; }
        public string CurrencyEn { get; set; }
        public string CurrencyCode { get; set; }
        public int CurrencyId { get; set; }
        public int? BaseCurrency { get; set; }
        public string StripePublishablekey { get; set; }
        public string Filepath { get; set; }
        public string TaxRegNo { get; set; }

        public string AdminSubEndDate { get; set; }
        public decimal? AdminValue { get; set; }
        public decimal? UserValue { get; set; }
 
    }
}
