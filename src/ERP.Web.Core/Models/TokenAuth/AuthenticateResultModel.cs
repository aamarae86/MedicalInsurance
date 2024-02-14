using ERP.MultiTenancy;
using ERP.MultiTenancy.Dto;

namespace ERP.Models.TokenAuth
{
    public class AuthenticateResultModel
    {
        public string AccessToken { get; set; }

        public string EncryptedAccessToken { get; set; }

        public int ExpireInSeconds { get; set; }

        public long UserId { get; set; }

        public bool IsHost { get; set; }
        public bool IsTenentAdmin { get; set; }


        public string UserName { get; set; }
        public TenantDetailDto TenantDetail { get; set; }
    }
}
