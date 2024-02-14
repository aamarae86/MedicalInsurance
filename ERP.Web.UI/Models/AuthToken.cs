using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERP.MultiTenancy.Dto;

namespace ERP.WebUI.Models
{
    public class AuthToken
    {
        public string AccessToken { get; set; }

        public string EncryptedAccessToken { get; set; }

        public int ExpireInSeconds { get; set; }

        public long UserId { get; set; }

        public string UserName { get; set; }
        public bool IsHost { get; set; }
        public bool IsTenentAdmin { get; set; }

        public TenantDetailDto TenantDetail { get; set; }
    }

    public class TenantDetailDto
    {
        public int TenantId { get; set; }

        public string LogoPath { get; set; }

        public string TenantNameAr { get; set; }

        public string TenantNameEn { get; set; }

        public string BoxNo { get; set; }

        public string Tel { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }
        public string ManagerName { get; set; }

        public string RepManagerName { get; set; }

        public string TaxRegNo { get; set; }


    }
}