using ERP.ResourcePack.AccountsExtend;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ApVendorsVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(ApVendors.VendorNumber), ResourceType = typeof(ApVendors))]
        public string VendorNumber { get; set; }

        [Display(Name = nameof(ApVendors.VendorNameAr), ResourceType = typeof(ApVendors))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        [Remote(nameof(Controllers.Accounts.ApVendorsController.CheckIsExistsVendorNameAr), "ApVendors", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = nameof(Settings.nameExist), ErrorMessageResourceType = typeof(Settings))]
        public string VendorNameAr { get; set; }

        [Display(Name = nameof(ApVendors.VendorNameEn), ResourceType = typeof(ApVendors))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        [Remote(nameof(Controllers.Accounts.ApVendorsController.CheckIsExistsVendorNameEn), "ApVendors", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = nameof(Settings.nameExist), ErrorMessageResourceType = typeof(Settings))]
        public string VendorNameEn { get; set; }

        [Display(Name = nameof(ApVendors.StatusLkpId), ResourceType = typeof(ApVendors))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(ApVendors.VendorCategoryLkpId), ResourceType = typeof(ApVendors))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long VendorCategoryLkpId { get; set; }

        [Display(Name = nameof(ApVendors.Address), ResourceType = typeof(ApVendors))]
        [MaxLength(4000)]
        public string Address { get; set; }

        [Display(Name = nameof(ApVendors.Comments), ResourceType = typeof(ApVendors))]
        [MaxLength(4000)]
        public string Comments { get; set; }

        [Display(Name = nameof(ApVendors.WorkTel), ResourceType = typeof(ApVendors))]
        [MaxLength(50)]
        public string WorkTel { get; set; }

        [Display(Name = nameof(ApVendors.Mobile), ResourceType = typeof(ApVendors))]
        [MaxLength(50)]
        public string Mobile { get; set; }

        [Display(Name = nameof(ApVendors.Fax), ResourceType = typeof(ApVendors))]
        [MaxLength(50)]
        public string Fax { get; set; }

        [Display(Name = nameof(ResourcePack.Accounts.ApMiscPaymentHeaders.TaxNo), ResourceType = typeof(ResourcePack.Accounts.ApMiscPaymentHeaders))]
        [MaxLength(400)]
        public string TaxNo { get; set; }

        [Display(Name = nameof(ApVendors.Email), ResourceType = typeof(ApVendors))]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public FndLookupValuesVM FndVendorCategoryLkp { get; set; }
    }
}