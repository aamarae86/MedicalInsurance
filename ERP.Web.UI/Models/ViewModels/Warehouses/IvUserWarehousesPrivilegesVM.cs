using ERP.ResourcePack.Common;
using ERP.ResourcePack.Warehouses;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Authentications;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Warehouses
{
    public class IvUserWarehousesPrivilegesVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(IvUserWarehousesPrivileges.IvWarehouseId), ResourceType = typeof(IvUserWarehousesPrivileges))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long IvWarehouseId { get; set; }

        [Display(Name = nameof(IvUserWarehousesPrivileges.UserId), ResourceType = typeof(IvUserWarehousesPrivileges))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long UserId { get; set; }

        [Display(Name = nameof(IvUserWarehousesPrivileges.HasIssue), ResourceType = typeof(IvUserWarehousesPrivileges))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public bool HasIssue { get; set; }

        public bool HasIssueAlt { get; set; }

        [Display(Name = nameof(IvUserWarehousesPrivileges.HasReceive), ResourceType = typeof(IvUserWarehousesPrivileges))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public bool HasReceive { get; set; }

        public bool HasReceiveAlt { get; set; }

        public IvWarehousesVM IvWarehouses { get; set; }

        public UsersVM User { get; set; }
    }
}