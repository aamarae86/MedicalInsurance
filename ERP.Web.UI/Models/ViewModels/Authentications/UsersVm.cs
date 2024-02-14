using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Authentications
{
    public class UsersVM : UsersEditVM
    {
        [Display(Name = nameof(FndUsers.Title), ResourceType = typeof(FndUsers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PortalUserId { get; set; }
    }

    public class UsersEditVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(UserName), ResourceType = typeof(ResourcePack.Authentications.Users))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(256)]
        public string UserName { get; set; }

        [Display(Name = nameof(Name), ResourceType = typeof(ResourcePack.Authentications.Users))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(64)]
        public string Name { get; set; }

        [Display(Name = nameof(SurName), ResourceType = typeof(ResourcePack.Authentications.Users))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(64)]
        public string SurName { get; set; }

        [Display(Name = nameof(FullName), ResourceType = typeof(ResourcePack.Authentications.Users))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(256)]
        public string FullName { get; set; }

        [Display(Name = nameof(EmailAddress), ResourceType = typeof(ResourcePack.Authentications.Users))]
        [EmailAddress(ErrorMessageResourceName = "InvalidMail", ErrorMessageResourceType = typeof(ResourcePack.Authentications.Users))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(256)]
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = nameof(IsActive), ResourceType = typeof(ResourcePack.Authentications.Users))]
        public bool IsActiveAlt { get; set; }

        [Display(Name = nameof(ShowOrder), ResourceType = typeof(ResourcePack.Authentications.Users))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]

        public int ShowOrder { get; set; }

        [Display(Name = nameof(UserValue), ResourceType = typeof(ResourcePack.Accounts.ReportsAccounts))]
        public string UserValue { get; set; }

        public string SubEndDate { get;  set; }

        public string BaseUrl { get; set; }
    }
}