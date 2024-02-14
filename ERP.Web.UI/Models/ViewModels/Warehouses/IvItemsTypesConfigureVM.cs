using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.Warehouses;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Controllers.Warehouses;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ERP.Web.UI.Models.ViewModels.Warehouses
{
    public class IvItemsTypesConfigureVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(IvItemsTypesConfigure.ConfigureCode), ResourceType = typeof(IvItemsTypesConfigure))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Remote(nameof(IvItemsTypesConfigureController.CheckIsExistsCode), "IvItemsTypesConfigure", AdditionalFields = nameof(Id), HttpMethod = "POST", ErrorMessageResourceName = nameof(ArCustomers.codeExist), ErrorMessageResourceType = typeof(ArCustomers))]
        public string ConfigureCode { get; set; }

        [Display(Name = nameof(IvItemsTypesConfigure.NameEn), ResourceType = typeof(IvItemsTypesConfigure))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Remote(nameof(IvItemsTypesConfigureController.CheckIsExistsNameEn), "IvItemsTypesConfigure", AdditionalFields = nameof(Id), HttpMethod = "POST", ErrorMessageResourceName = nameof(Settings.nameExist), ErrorMessageResourceType = typeof(Settings))]
        public string NameEn { get; set; }

        [Display(Name = nameof(IvItemsTypesConfigure.NameAr), ResourceType = typeof(IvItemsTypesConfigure))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Remote(nameof(IvItemsTypesConfigureController.CheckIsExistsNameAr), "IvItemsTypesConfigure", AdditionalFields = nameof(Id), HttpMethod = "POST", ErrorMessageResourceName = nameof(Settings.nameExist), ErrorMessageResourceType = typeof(Settings))]
        public string NameAr { get; set; }

        [Display(Name = nameof(IvItemsTypesConfigure.ParentId), ResourceType = typeof(IvItemsTypesConfigure))]
        public long? ParentId { get; set; }

        [Display(Name = nameof(IvItemsTypesConfigure.ParentId), ResourceType = typeof(IvItemsTypesConfigure))]
        public string ParentPath { get; set; }

        public IvItemsTypesConfigureVM Parent { get; set; }
    }
}