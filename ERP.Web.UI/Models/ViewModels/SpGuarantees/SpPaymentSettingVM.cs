using ERP.ResourcePack.Common;
using ERP.ResourcePack.SpGuarantees;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.SpGuarantees
{
    public class SpPaymentSettingVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(SponsorCategoryLkpId), ResourceType = typeof(SpPaymentSetting))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long SponsorCategoryLkpId { get; set; }

        [Display(Name = nameof(ManagementPercentage), ResourceType = typeof(SpPaymentSetting))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal ManagementPercentage { get; set; }

        [Display(Name = nameof(Settings.FromDate), ResourceType = typeof(Settings))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string FromDate { get; set; }

        [Display(Name = nameof(Settings.ToDate), ResourceType = typeof(Settings))]
        public string ToDate { get; set; }

        public FndLookupValuesVM FndSponsorCategoryLkp { get; set; }
    }
}