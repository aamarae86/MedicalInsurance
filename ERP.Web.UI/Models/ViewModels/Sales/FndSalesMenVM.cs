using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.Sales;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Authentications;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ERP.Web.UI.Models.ViewModels.Sales
{
    public class FndSalesMenVM : BaseAuditedEntityVM<long>
    {       
        public string Lang { get; set; }

        [Display(Name = nameof(FndSalesMen.SalesMenNum), ResourceType = typeof(FndSalesMen))]
        public string SalesManNo { get; set; }


        [Display(Name = nameof(FndSalesMen.NameAr), ResourceType = typeof(FndSalesMen))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        [Remote("CheckIsExistsSalesMenNameAr", "FndSalesMen", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "nameExist", ErrorMessageResourceType = typeof(Settings))]
        public string SalesManNameAr { get; set; }


        [Display(Name = nameof(FndSalesMen.NameEn), ResourceType = typeof(FndSalesMen))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        [Remote("CheckIsExistsSalesMenNameEn", "FndSalesMen", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "nameExist", ErrorMessageResourceType = typeof(Settings))]
        public string SalesManNameEn { get; set; }

        
        [Display(Name = nameof(FndSalesMen.IsActive), ResourceType = typeof(FndSalesMen))]
        public bool IsActive { get; set; }

        public long? UserId { get; set; }
        public UsersVM User { get; set; }
        public int? DiscountPercentageAllowed { get; set; }
    }
}