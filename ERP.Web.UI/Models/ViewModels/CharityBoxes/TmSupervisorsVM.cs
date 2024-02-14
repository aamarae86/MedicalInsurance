using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.CharityBoxes
{
    public class TmSupervisorsVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(ArCustomers.SupervisorNumber), ResourceType = typeof(ArCustomers))]
        public string SupervisorNumber { get; set; }

        [Display(Name = nameof(ArCustomers.SupervisorName), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string SupervisorName { get; set; }

        public long? SourceLkpId { get; set; }

        [Display(Name = nameof(ArCustomers.Status), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? StatusLkpId { get; set; }

        public FndLookupValuesVM FndLookupValues { get; set; }

        public string Lang { get; set; }
    }
}