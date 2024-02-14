using System.Collections.Generic;

namespace ERP.Web.UI.Models.ViewModels.Authentications
{
    public class PagePermissionVM
    {
        public string Name { get; set; }
        //public string Name { get; set; }

        public PermissionState ViewPermission { get; set; }

        public PermissionState InsertPermission { get; set; }

        public PermissionState UpdatePermission { get; set; }

        public PermissionState DeletePermission { get; set; }

        public PermissionState PostPermission { get; set; }

        public PermissionState UnPostPermission { get; set; }

        public PermissionState AuditPermission { get; set; }

        public PagePermissionVM(string pageName, string viewPermissionName, string insertPermissionName, string updatePermissionName, string deletePermissionName, string postPermissionName, string unPostPermissionName, string auditPermissionName, List<string> grantedPermissionNames)
        {
            Name = ResourcePack.Common.Menu.ResourceManager.GetString(pageName);
            ViewPermission = new PermissionState(viewPermissionName, grantedPermissionNames.Contains(viewPermissionName));
            InsertPermission = new PermissionState(insertPermissionName, grantedPermissionNames.Contains(insertPermissionName));
            UpdatePermission = new PermissionState(updatePermissionName, grantedPermissionNames.Contains(updatePermissionName));
            DeletePermission = new PermissionState(deletePermissionName, grantedPermissionNames.Contains(deletePermissionName));
            PostPermission = new PermissionState(postPermissionName, grantedPermissionNames.Contains(postPermissionName));
            UnPostPermission = new PermissionState(unPostPermissionName, grantedPermissionNames.Contains(unPostPermissionName));
            AuditPermission = new PermissionState(auditPermissionName, grantedPermissionNames.Contains(auditPermissionName));
        }
    }
}