using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Authentications;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ApUserBankAccessVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(ApUserBankAccess.BankAccount), ResourceType = typeof(ApUserBankAccess))]
        public long? BankAccountId { get; set; }

        [Display(Name = nameof(ApUserBankAccess.IsPrimaryCash), ResourceType = typeof(ApUserBankAccess))]
        public bool IsPrimaryCash { get; set; }

        [Display(Name = nameof(ArCustomers.UserName), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long UserId { get; set; }

        public ApBanksVM ApBanksDto { get; set; }

        public ApBankAccountsVM ApBankAccounts { get; set; }

        public bool IsPrimaryCashAlt { get; set; }

        public UsersVM User { get; set; }
    }
}