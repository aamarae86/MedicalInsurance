using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using ERP.ResourcePack.AccountsExtend;
using ERP.ResourcePack.Common;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AccountsExtend
{
    public class FaAssetsVM : PostAuditedEntity<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        #region Search Params
        [Display(Name = nameof(FaAsset.Desc), ResourceType = typeof(FaAsset))]
        public string Search_Description { get; set; }
        [Display(Name = nameof(FaAsset.AssetNumber), ResourceType = typeof(FaAsset))]
        public string Search_AssetNumber { get; set; }
        [Display(Name = nameof(FaAsset.FaAssetCategoryId), ResourceType = typeof(FaAsset))]
        public long? Search_FaAssetCategoryId { get; set; }
        [Display(Name = nameof(FaAsset.AssetTypeLkpId), ResourceType = typeof(FaAsset))]
        public long? Search_AssetTypeLkpId { get; set; }
        [Display(Name = nameof(FaAsset.StatusId), ResourceType = typeof(FaAsset))]
        public long? Search_StatusId { get; set; }
        #endregion

        #region Master Properties

        [Display(Name = nameof(FaAsset.Desc), ResourceType = typeof(FaAsset))]
        public string Description { get; set; }

        [Display(Name = nameof(FaAsset.TagNumber), ResourceType = typeof(FaAsset))]
        public string TagNumber { get; set; }

        [Display(Name = nameof(FaAsset.SerialNumber), ResourceType = typeof(FaAsset))]
        public string SerialNumber { get; set; }

        [Display(Name = nameof(FaAsset.AssetTypeLkpId), ResourceType = typeof(FaAsset))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long AssetTypeLkpId { get; set; }

        [Display(Name = nameof(FaAsset.AssetKey), ResourceType = typeof(FaAsset))]
        public string AssetKey { get; set; }

        [Display(Name = nameof(FaAsset.FaAssetCategoryId), ResourceType = typeof(FaAsset))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long FaAssetCategoryId { get; set; }

        [Display(Name = nameof(FaAsset.Units), ResourceType = typeof(FaAsset))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long Units { get; set; }

        [Display(Name = nameof(FaAsset.ParentAssetId), ResourceType = typeof(FaAsset))]
        public long? ParentAssetId { get; set; }

        [Display(Name = nameof(FaAsset.Manufacturer), ResourceType = typeof(FaAsset))]
        public string Manufacturer { get; set; }

        [Display(Name = nameof(FaAsset.Model), ResourceType = typeof(FaAsset))]
        public string Model { get; set; }

        [Display(Name = nameof(FaAsset.WarrantyNumber), ResourceType = typeof(FaAsset))]
        public string WarrantyNumber { get; set; }

        [Display(Name = nameof(FaAsset.InUse), ResourceType = typeof(FaAsset))]
        public bool? InUse { get; set; }
        [Display(Name = nameof(FaAsset.InUse), ResourceType = typeof(FaAsset))]
        public bool? InUseAlt { get; set; }

        [Display(Name = nameof(FaAsset.InPhysicalInventory), ResourceType = typeof(FaAsset))]
        public bool? InPhysicalInventory { get; set; }
        [Display(Name = nameof(FaAsset.InPhysicalInventory), ResourceType = typeof(FaAsset))]
        public bool? InPhysicalInventoryAlt { get; set; }

        [Display(Name = nameof(FaAsset.OwnershipLkpId), ResourceType = typeof(FaAsset))]
        public long? OwnershipLkpId { get; set; }

        [Display(Name = nameof(FaAsset.BoughtLkpId), ResourceType = typeof(FaAsset))]
        public long? BoughtLkpId { get; set; }

        [Display(Name = nameof(FaAsset.DatePlacedInService), ResourceType = typeof(FaAsset))]
        public string DatePlacedInService { get; set; }

        [Display(Name = nameof(FaAsset.BookingTypeLkpId), ResourceType = typeof(FaAsset))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long BookingTypeLkpId { get; set; }

        [Display(Name = nameof(FaAsset.BookingName), ResourceType = typeof(FaAsset))]
        public string BookingName { get; set; }

        [Display(Name = nameof(FaAsset.CurrentCost), ResourceType = typeof(FaAsset))]
        public decimal? CurrentCost { get; set; }

        [Display(Name = nameof(FaAsset.OriginalCost), ResourceType = typeof(FaAsset))]
        public decimal? OriginalCost { get; set; }

        [Display(Name = nameof(FaAsset.SalvageValueTypeLkpId), ResourceType = typeof(FaAsset))]
        public long? SalvageValueTypeLkpId { get; set; }

        [Display(Name = nameof(FaAsset.SalvageValue), ResourceType = typeof(FaAsset))]
        public decimal? SalvageValue { get; set; }

        [Display(Name = nameof(FaAsset.DeprenMethodLkpId), ResourceType = typeof(FaAsset))]
        public long? DeprenMethodLkpId { get; set; }

        [Display(Name = nameof(FaAsset.LifeInMonths), ResourceType = typeof(FaAsset))]
        public int? LifeInMonths { get; set; }

        [Display(Name = nameof(FaAsset.IsDepreciate), ResourceType = typeof(FaAsset))]
        public bool? IsDepreciate { get; set; }
        [Display(Name = nameof(FaAsset.IsDepreciate), ResourceType = typeof(FaAsset))]
        public bool? IsDepreciateAlt { get; set; }

        [Display(Name = nameof(FaAsset.ProrateConversionCode), ResourceType = typeof(FaAsset))]
        public string ProrateConversionCode { get; set; }

        [Display(Name = nameof(FaAsset.ProrateDate), ResourceType = typeof(FaAsset))]
        public string ProrateDate { get; set; }

        [Display(Name = nameof(FaAsset.AmortizationStartDate), ResourceType = typeof(FaAsset))]
        public string AmortizationStartDate { get; set; }

        [Display(Name = nameof(FaAsset.StatusId), ResourceType = typeof(FaAsset))]
        public long StatusLkpId { get; set; }


        #endregion

        #region Master Mapped Properties
        [Display(Name = nameof(FaAsset.AssetNumber), ResourceType = typeof(FaAsset))]
        public string AssetNumber { get; set; }
        public string AssetTypeLkpAr { get; set; }
        public string AssetTypeLkpEn { get; set; }
        public string StatusEn { get; set; }
        public string StatusAr { get; set; }
        public string FaAssetCategoryAr { get; set; }
        public string FaAssetCategoryEn { get; set; }
        public string ParentAssetDescription { get; set; }
        public string ParentAssetNumber { get; set; }
        public string OwnershipLkpAr { get; set; }
        public string OwnershipLkpEn { get; set; }
        public string BoughtLkpAr { get; set; }
        public string BoughtLkpEn { get; set; }
        public string BookingTypeLkpAr { get; set; }
        public string BookingTypeLkpEn { get; set; }
        public string SalvageValueTypeLkpAr { get; set; }
        public string SalvageValueTypeLkpEn { get; set; }
        public string DeprenMethodLkpAr { get; set; }
        public string DeprenMethodLkpEn { get; set; }

        public string Status => FaAsset.NewStatus;
        #endregion
    }
}