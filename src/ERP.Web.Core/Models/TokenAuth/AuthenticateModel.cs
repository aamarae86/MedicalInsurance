using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;

namespace ERP.Models.TokenAuth
{
    public class AuthenticateModel
    {
        [Required]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string UserNameOrEmailAddress { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        public string Password { get; set; }

        [Required]
        public int TenantId { get; set; }

        public bool HostManager { get; set; }

        public bool RememberClient { get; set; }

    }
}
