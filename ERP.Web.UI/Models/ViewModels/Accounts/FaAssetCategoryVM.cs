using ERP.Helpers.Parameters;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class FaAssetCategoryVM: BaseAuditedEntityVM<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        [Display(Name = nameof(FaAssetCategory.AssetCategoryNumber), ResourceType = typeof(FaAssetCategory))]
        [MaxLength(30)]
        public string AssetCategoryNumber { get; set; }
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(FaAssetCategory.AssetCategoryNameAr), ResourceType = typeof(FaAssetCategory))]
        [MaxLength(200)]
        public string AssetCategoryNameAr { get; set; }
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(FaAssetCategory.AssetCategoryNameEn), ResourceType = typeof(FaAssetCategory))]
        [MaxLength(200)]
        public string AssetCategoryNameEn { get; set; }
        [Display(Name = nameof(FaAssetCategory.Description), ResourceType = typeof(FaAssetCategory))]
        public string Description { get; set; }
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(FaAssetCategory.NoMonthsDepreciation), ResourceType = typeof(FaAssetCategory))]
        public long? NoMonthsDepreciation { get; set; }

        public long? AssetCostAccountId { get; set; }
        public long? AssetClearingAccountId { get; set; }
        public long? AccDeprenAccountId { get; set; }
        public long? DeprenAccountId { get; set; }

        public string codeComUtilityIds { get; set; }
        public string codeComUtilityTexts { get; set; }

        public string codeComUtilityIds_alt1 { get; set; }
        public string codeComUtilityTexts_alt1 { get; set; }

        public string codeComUtilityIds_alt2 { get; set; }
        public string codeComUtilityTexts_alt2 { get; set; }

        public string codeComUtilityIds_alt3 { get; set; }
        public string codeComUtilityTexts_alt3 { get; set; }
        
        public string Lang { get; set; }
    }
}