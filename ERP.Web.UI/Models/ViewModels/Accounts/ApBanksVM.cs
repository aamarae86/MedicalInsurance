using ERP.Front.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ApBanksVM : BaseAuditedEntityVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(ApBanks.BankNameAr), ResourceType = typeof(ApBanks))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string BankNameAr { get; set; }

        [Display(Name = nameof(ApBanks.BankNameEn), ResourceType = typeof(ApBanks))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string BankNameEn { get; set; }

        [Display(Name = nameof(ApBanks.BankTypeLkpId), ResourceType = typeof(ApBanks))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long BankTypeLkpId { get; set; }

        public string ListApBankAccounts { get; set; }

        public List<ListApBankAccounts> ListApBankAccountsDetails =>
            string.IsNullOrEmpty(ListApBankAccounts) ?
            new List<ListApBankAccounts>() :
            Helper<List<ListApBankAccounts>>.Convert(ListApBankAccounts);


        public FndLookupValuesVM FndLookupValues { get; set; }

        [Display(Name = nameof(ApBanks.IsActive), ResourceType = typeof(ApBanks))]
        public bool IsActive { get; set; }
        public bool IsActiveAlt { get; set; }

    }
}