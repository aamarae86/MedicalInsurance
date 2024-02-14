using ERP.ResourcePack.Common;
using System.ComponentModel.DataAnnotations;

namespace ERP.Front.Helpers.Parameters.Login
{
    public class LoginParms
    {
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string UserNameOrEmailAddress { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public int TenantId { get; set; }

        public bool HostManager { get; set; }

        public bool RememberClient { get; set; }
    }
}
