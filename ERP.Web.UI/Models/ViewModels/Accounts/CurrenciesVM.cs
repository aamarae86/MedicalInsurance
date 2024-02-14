using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class CurrenciesVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(Code), ResourceType = typeof(ERP.ResourcePack.Accounts.Currencies))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(20)]
        public string Code { get; set; }

        [Display(Name = nameof(DescriptionAr), ResourceType = typeof(ERP.ResourcePack.Accounts.Currencies))]
        [Required]
        [MaxLength(4000)]
        public string DescriptionAr { get; set; }

        [Display(Name = nameof(DescriptionEn), ResourceType = typeof(ERP.ResourcePack.Accounts.Currencies))]
        [Required]
        [MaxLength(4000)]
        public string DescriptionEn { get; set; }

        [Display(Name = nameof(Rate), ResourceType = typeof(ERP.ResourcePack.Accounts.Currencies))]
        [Required]
        public decimal Rate { get; set; }

        [Display(Name = nameof(IsLocalCurrency), ResourceType = typeof(ERP.ResourcePack.Accounts.Currencies))]
        public bool IsLocalCurrency { get; set; }

        [Display(Name = nameof(IsLocalCurrency), ResourceType = typeof(ERP.ResourcePack.Accounts.Currencies))]
        public bool IsLocalCurrencyAlt { get; set; }

        [Display(Name = nameof(IsActive), ResourceType = typeof(ERP.ResourcePack.Accounts.Currencies))]
        public bool IsActive { get; set; }

        [Display(Name = nameof(IsActive), ResourceType = typeof(ERP.ResourcePack.Accounts.Currencies))]
        public bool IsActiveAlt { get; set; }

        [Display(Name = nameof(ShowOrder), ResourceType = typeof(ERP.ResourcePack.Accounts.Currencies))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public int ShowOrder { get; set; }
    }
}