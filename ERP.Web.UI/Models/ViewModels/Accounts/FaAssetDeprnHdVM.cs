using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class FaAssetDeprnHdVM : BasePostAuditedVM<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [Display(Name = nameof(FaAssetDeprnHd.AssetDeprnDate), ResourceType = typeof(FaAssetDeprnHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string AssetDeprnDate { get;  set; }

        [Display(Name = nameof(Settings.StartDate), ResourceType = typeof(Settings))]
        public string StartDate { get; set; }

        [Display(Name = nameof(Settings.EndDate), ResourceType = typeof(Settings))]
        public string EndDate { get; set; }

        #region Master Properties
        [Display(Name = nameof(FaAssetDeprnHd.AssetDeprnName), ResourceType = typeof(FaAssetDeprnHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string AssetDeprnName { get; set; }

        [Display(Name = nameof(FaAssetDeprnHd.AssetId), ResourceType = typeof(FaAssetDeprnHd))]
        public long? AssetId { get; set; }

        [Display(Name = nameof(FaAssetDeprnHd.StatusId), ResourceType = typeof(FaAssetDeprnHd))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(FaAssetDeprnHd.PeriodId), ResourceType = typeof(FaAssetDeprnHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PeriodId { get; set; }
        #endregion

        #region Master Mapped Properties
        [Display(Name = nameof(FaAssetDeprnHd.AssetDeprnNumber), ResourceType = typeof(FaAssetDeprnHd))]
        public string AssetDeprnNumber { get; set; }
        public string StatusEn { get; set; }
        public string StatusAr { get; set; }
        public string AssetDescription { get; set; }
        public string PeriodAr { get; set; }
        public string PeriodEn { get; set; }
        public string Status => FaAssetDeprnHd.NewStatus;
        #endregion
    }
}