using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Authentications
{
    public class RolePermissionsVM
    {
        public int Id { get; set; }
        public List<PagePermissionVM> Pages { get; set; }

        public List<FlatPermissionVM> Permissions { get; set; }
        public List<string> GrantedPermissionNames { get; set; }

        private string ViewPermissionName;
        private string InsertPermissionName;
        private string UpdatePermissionName;
        private string DeltePermissionName;
        private string PostPermissionName;
        private string UnPostPermissionName;
        private string AuditPermissionName;

        private void SetPermissionNames(string pageName)
        {
            try
            {
                ViewPermissionName = Permissions.FirstOrDefault(p => p.Name.EndsWith(pageName)).Name;
                pageName = pageName + ".";
                InsertPermissionName = Permissions.FirstOrDefault(p => p.Name.Contains(pageName) && p.Name.ToLower().EndsWith("insert"))?.Name;
                UpdatePermissionName = Permissions.FirstOrDefault(p => p.Name.Contains(pageName) && p.Name.ToLower().EndsWith("update"))?.Name;
                DeltePermissionName = Permissions.FirstOrDefault(p => p.Name.Contains(pageName) && p.Name.ToLower().EndsWith("delete"))?.Name;
                PostPermissionName = Permissions.FirstOrDefault(p => p.Name.Contains(pageName) && p.Name.ToLower().EndsWith("post"))?.Name;
                UnPostPermissionName = Permissions.FirstOrDefault(p => p.Name.Contains(pageName) && p.Name.ToLower().EndsWith("unpost"))?.Name;
                AuditPermissionName = Permissions.FirstOrDefault(p => p.Name.Contains(pageName) && p.Name.ToLower().EndsWith("audit"))?.Name;
            }
            catch (Exception)
            {
                throw;
            }        
        }

        internal void FillPages()
        {
            var distinctPages = Permissions.Select(p => p.Name.Replace("Host.","").Replace("Tenant.", "").Split(new char[] { '.' })[1]).Distinct();
            Pages = new List<PagePermissionVM>();

            foreach (string distinctPage in distinctPages)
            {
                try
                {
                    SetPermissionNames(distinctPage);

                    Pages.Add(new PagePermissionVM(
                            distinctPage,
                            ViewPermissionName,
                            InsertPermissionName,
                            UpdatePermissionName,
                            DeltePermissionName,
                            PostPermissionName,
                            UnPostPermissionName,
                            AuditPermissionName,
                            GrantedPermissionNames));
                }
                catch (Exception)
                {

                    //throw;
                }
            }
        }

        internal void SetRoleId(int id)
        {
            Id = id;
        }
    }
}