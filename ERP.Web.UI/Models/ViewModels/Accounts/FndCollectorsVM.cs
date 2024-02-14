using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class FndCollectorsVM : BaseAuditedEntityVM<long>
    {
       public string Lang { get; set; }

        [Display(Name = nameof(FndCollectors.Collectornum), ResourceType = typeof(FndCollectors))]
        public int? CollectorNumber { get; set; }

        [Display(Name = nameof(FndCollectors.nameAr), ResourceType = typeof(FndCollectors))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        [Remote("CheckIsExistsCollectorNameAr", "FndCollectors", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "nameExist", ErrorMessageResourceType = typeof(Settings))]
        public string CollectorNameAr { get; set; }

        [Display(Name = nameof(FndCollectors.nameEn), ResourceType = typeof(FndCollectors))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        [Remote("CheckIsExistsCollectorNameEn", "FndCollectors", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "nameExist", ErrorMessageResourceType = typeof(Settings))]
        public string CollectorNameEn { get; set; }
        
    }
}