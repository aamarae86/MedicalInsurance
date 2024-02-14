using Abp.MultiTenancy;
using ERP._System._FndLookupValues;
using ERP._System._TenantFreeModules;
using ERP.Authorization.Users;
using ERP.Currencies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }

        public int? TenantDetailId { get; set; }

        [ForeignKey(nameof(TenantDetailId))]
        public TenantDetail TenantDetail { get; protected set; }

        public long? CountryLkpId { get; protected set; }
        [ForeignKey(nameof(CountryLkpId)), Column(Order = 0)]
        public FndLookupValues FndCountryLkp { get; protected set; }

        public long? IndustryLkpId { get; protected set; }

        [ForeignKey(nameof(IndustryLkpId)), Column(Order = 1)]
        public FndLookupValues FndIndustryLkp { get; protected set; }

        [MaxLength(100)]
        public string LogoPath { get; protected set; }

        [MaxLength(100)]
        public string TenantNameAr { get; protected set; }

        [MaxLength(100)]
        public string TenantNameEn { get; protected set; }

        [MaxLength(100)]
        public string BoxNo { get; protected set; }

        [MaxLength(100)]
        public string Tel { get; protected set; }

        [MaxLength(100)]
        public string MobileNo { get; protected set; }
        [MaxLength(200)]
        public string FullName { get; protected set; }

        [MaxLength(100)]
        public string Fax { get; protected set; }

        [MaxLength(100)]
        public string Email { get; protected set; }

        [MaxLength(100)]
        public string WebSite { get; protected set; }

        [MaxLength(200)]
        public string ManagerName { get; protected set; }

        [MaxLength(200)]
        public string RepManagerName { get; protected set; }

        [ForeignKey(nameof(BaseCurrency))]
        public Currency Currency { get; protected set; }
        public int? BaseCurrency { get; protected set; }
        public decimal? AdminValue { get; protected set; }
        public decimal? UserValue { get; protected set; }
        public string Filepath { get; protected set; }

        [MaxLength(30)]
        public string TaxRegNo { get; protected set; }
        [NotMapped]
        public DateTime? AdminSubEndDate { get;  set; }
        public virtual ICollection<TenantFreeModules> TenantFreeModules { get; protected set; }
        public virtual ICollection<TenantRenewalHistory> TenantRenewalHistories { get; protected set; }
        
        internal void SetDetails(TenantDetail tenantDetail, int currencyId)
        {
            LogoPath = tenantDetail.LogoPath;
            TenantNameAr = tenantDetail.TenantNameAr;
            TenantNameEn = tenantDetail.TenantNameEn;
            BoxNo = tenantDetail.BoxNo;
            Tel = tenantDetail.Tel;
            Fax = tenantDetail.Fax;
            Email = tenantDetail.Email;
            WebSite = tenantDetail.WebSite;
            ManagerName = tenantDetail.ManagerName;
            RepManagerName = tenantDetail.RepManagerName;
            BaseCurrency = currencyId;
        }

        public void SetPaymentValues(decimal AdminValue, decimal UserValue)
        {
            this.UserValue = UserValue;
            this.AdminValue = AdminValue;
        }

        public void SetSubEndDateValue(DateTime AdminSubEndDate)
        {
            this.AdminSubEndDate = AdminSubEndDate;
        }

        public void SetTenancyName(string TenantName)
        {
            this.TenantNameAr = TenantName;
            this.TenantNameEn = TenantName;
        }

    }
}
