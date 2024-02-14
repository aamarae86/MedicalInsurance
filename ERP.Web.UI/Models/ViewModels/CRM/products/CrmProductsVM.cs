using System.ComponentModel.DataAnnotations;
using ERP.ResourcePack.CRM.products;
using ERP.Web.UI.Controllers.Base;

namespace ERP.Web.UI.Models.ViewModels.CRM.Products
{
    public class CrmProductsVM : BasePostAuditedVM<long>
    {
        [Display(Name = nameof(products.IsActive), ResourceType = typeof(products))]

        public bool IsActive { get; set; }
        [StringLength(200)]
        [Required]
        [Display(Name = nameof(products.ProductNameAr), ResourceType = typeof(products))]
        public string ProductNameAr { get; set; }
        [StringLength(200)]
        [Required]
        [Display(Name = nameof(products.ProductNameEn), ResourceType = typeof(products))]
        public string ProductNameEn { get; set; }


        [StringLength(4000)]
        [Display(Name = nameof(products.ContentAr), ResourceType = typeof(products))]
        public string ContentAr { get; set; }
        [StringLength(4000)]
        [Display(Name = nameof(products.ContentEn), ResourceType = typeof(products))]
        public string ContentEn { get; set; }
        [StringLength(500)]
        [Display(Name = nameof(products.Filepath), ResourceType = typeof(products))]
        public string Filepath { get; set; }

    }
}