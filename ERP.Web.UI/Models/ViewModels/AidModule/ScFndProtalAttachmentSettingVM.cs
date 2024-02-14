using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScFndProtalAttachmentSettingVM : BaseAuditedEntityVM<long>
    {

        [Display(Name = nameof(AttachmentNameAr), ResourceType = typeof(ScFndProtalAttachmentSetting))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string AttachmentNameAr { get; set; }


        [Display(Name = nameof(AttachmentNameEn), ResourceType = typeof(ScFndProtalAttachmentSetting))]
        public string AttachmentNameEn { get; set; }


        [Display(Name = nameof(RequestTypeId), ResourceType = typeof(ScFndProtalAttachmentSetting))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long RequestTypeId { get; set; }

        [Display(Name = nameof(OrderBy), ResourceType = typeof(ScFndProtalAttachmentSetting))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public int OrderBy { get; set; }

        [Display(Name = nameof(IsRequired), ResourceType = typeof(ScFndProtalAttachmentSetting))]
        public bool IsRequired { get; set; }
        public bool IsRequiredAlt { get; set; }


        [Display(Name = nameof(IsActive), ResourceType = typeof(ScFndProtalAttachmentSetting))]
        public bool IsActive { get; set; }
        public bool IsActiveAlt { get; set; }

        [Display(Name = nameof(Notes), ResourceType = typeof(ScFndProtalAttachmentSetting))]
        public string Notes { get; set; }


        public ScFndAidRequestTypeVM ScFndAidRequestType { get; set; }

    }
}