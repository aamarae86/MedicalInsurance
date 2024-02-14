using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScFndAidRequestTypeVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(AidRequestTypeLkpId), ResourceType = typeof(ScFndAidRequestType))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long AidRequestTypeLkpId { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }

        [Display(Name = nameof(ScFndAidRequestType.IsMaintenance), ResourceType = typeof(ScFndAidRequestType))]
        public bool IsMaintenance { get; set; }

        [Display(Name = nameof(ScFndAidRequestType.IsElectronics), ResourceType = typeof(ScFndAidRequestType))]
        public bool IsElectronics { get; set; }

        public bool IsMaintenanceAlt { get; set; }

        public bool IsElectronicsAlt { get; set; }

        [Display(Name = nameof(ScFndAidRequestType.IsAll), ResourceType = typeof(ScFndAidRequestType))]
        public bool IsAll { get; set; }

        public FndLookupValuesVM FndLookupValues { get; set; }
    }
}