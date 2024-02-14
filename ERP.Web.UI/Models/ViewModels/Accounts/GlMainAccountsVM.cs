using ERP.Helpers.Parameters;
using ERP.ResourcePack.Accounts;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class GlMainAccountsVM : BaseAuditedEntityVM<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        [Display(Name = nameof(GlMainAccounts.ReferenceCode), ResourceType = typeof(GlMainAccounts))]
        public string ReferenceCode { get; set; }

        [Display(Name = nameof(GlMainAccounts.Account), ResourceType = typeof(GlMainAccounts))]
        public long? AccountId { get; set; }

        [Display(Name = nameof(GlMainAccounts.Description), ResourceType = typeof(GlMainAccounts))]
        public string Description { get; set; }

        [Display(Name = nameof(GlMainAccounts.IsActive), ResourceType = typeof(GlMainAccounts))]
        public bool IsActive { get; set; }
        public bool IsActiveAlt { get; set; }
        public long DescriptionSearchId { get; set; }

        public string NameArDetails { get; set; }
        public string NameEnDetails { get; set; }
        public string CodesDetails { get; set; }

        public string codeComUtilityIds { get; set; }
        public string codeComUtilityTexts { get; set; }
    }
}